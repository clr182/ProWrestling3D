using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField]
    PlayerManager PM;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pole"))
        {
            PM.rb.transform.position = other.gameObject.transform.GetChild(0).position;
            PM.rb.velocity = Vector3.zero;
        }
    }
}
