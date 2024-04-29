using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject player;
    public GameObject respawnPoint;

    public void respawn()
    {
        player.transform.position = new Vector3(respawnPoint.transform.position.x,respawnPoint.transform.position.y);
    }
}
