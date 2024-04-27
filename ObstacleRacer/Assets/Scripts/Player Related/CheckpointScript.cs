using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private RespawnScript respawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Player2"))
        {
            respawn = collision.gameObject.GetComponent<RespawnScript>();

            respawn.respawnPoint = this.gameObject;
        }
    }
}
