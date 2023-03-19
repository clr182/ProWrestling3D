using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    PlayerManager PM;

    
    public float speed, sensitivity, maxForce, runSpeed;


    private Vector2 move;
    public float rotationRate = 6;
    private Vector3 targetVel;

    Vector3 lastKnowPosition, anchorPointPos;
    bool anchored = false;


    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }



    //move the child object rotation
    private void Look()
    {
        Quaternion desiredRotation = Quaternion.LookRotation(targetVel);
        if (targetVel != Vector3.zero) {
            transform.Find("toyWithoutPackaging").transform.rotation = 
                Quaternion.Slerp(transform.Find("toyWithoutPackaging").transform.rotation, desiredRotation, Time.deltaTime * rotationRate);
        }
    }

    private void Move()
    {
        if (!anchored)
        {
            Vector3 currentVel = PM.rb.velocity;
            targetVel = new Vector3(move.x, 0, move.y);
            
            targetVel *= speed;

            targetVel = transform.TransformDirection(targetVel);

            Vector3 velocityChange = (targetVel - currentVel);

            Vector3.ClampMagnitude(velocityChange, maxForce);

            PM.rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        Move();
        Look();
    }




    private void AnchorPlayer()
    {
        if (!anchored)
        {
            anchored = true;
        }
        else
        {

        }
    }

    private void jumpOffRopes()
    {
        
    }
}
