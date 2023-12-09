using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        BringPlayer();
    }

    public void BringPlayer()
    {
        player.transform.position = transform.position;
    }
}
