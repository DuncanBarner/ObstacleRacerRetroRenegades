using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;

    public void respawn()
    {
        player.transform.position = respawnPoint.transform.position;
    }
}
