using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float PlayerSpeedMultiplier = 1f;
    [SerializeField]
    private float ForceOfGravity = 9.81f;
    public GameObject Feet;
    private Rigidbody2D playerRB;
    public GameObject spawn;

    [HideInInspector] public float heightToReach;
    [HideInInspector] public float currentHeight;


    private bool canJump = false;
    private bool CanDoubleJump = false;

    //public AnimationCurve ()
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    float heldDownTime = 0.5f;
    void Update()
    {
        currentHeight = Vector2.Distance(transform.position, spawn.transform.position);
        float horionztal = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector3(horionztal, 0);
        direction = direction.normalized * PlayerSpeedMultiplier;
        playerRB.velocity = direction;
        playerRB.velocity += Vector2.up * -ForceOfGravity;
        RaycastHit2D hit;
        if(Physics2D.Raycast(Feet.transform.position,Vector2.down,5,~7))
        {
            //reset jump and double jump
        }
        else
        {
           // if double jump is not false and player jumps set doulbe jumpt to false
        }
        CanDoubleJump = true;

 

        if (Input.GetKey(KeyCode.Space) && heldDownTime > 0.0f && canJump || CanDoubleJump)
        {
            playerRB.velocity += new Vector2(0, 65 * heldDownTime);
            heldDownTime -= Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            heldDownTime = 0.5f;
        }
        setStaticDistance(currentHeight);
    }
    private void FixedUpdate()
    {

    }
    public static float StaticDistance = 0;

    public static void setStaticDistance(float height)
    {
        StaticDistance = height;
    }
}
