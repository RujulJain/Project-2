using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //detect if player is in volume
        PlayerHealth playerHealth =
            other.gameObject.GetComponent<PlayerHealth>();
        //subtract current amount of health from player 

        if(playerHealth != null)
        {
            playerHealth.DamagePlayer(20);
        }
    }
}
