using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    internal PlayerMovement playerMovement;

    [SerializeField]
    internal PlayerCollisions playerCollisions;

    [SerializeField]
    internal Animator anim;

    [SerializeField]
    internal Rigidbody rb;

    internal string currentState;


    private void Awake()
    {
        anim = transform.Find("toyWithoutPackaging").GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCollisions = GetComponent<PlayerCollisions>();
    }

    internal void ChangeState(string newState)
    {
        if(newState != currentState)
        {
            anim.Play(newState);
            currentState = newState;
        }
    }


}
