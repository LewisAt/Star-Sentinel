using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDmg : MonoBehaviour
{
    PlayerController playerController;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<OxygenTank>().oxygenValue -= 5;
            playerController.takeDamageFunc();
        }
    }
}
