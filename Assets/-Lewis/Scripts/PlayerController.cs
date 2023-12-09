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


        if (Physics2D.OverlapCircle(Feet.transform.position, 5f, ~6))
        {
            Debug.Log("WOWOWOWOOOWW");
        }

        if (Input.GetKey(KeyCode.Space) && heldDownTime > 0.0f)
        {
            playerRB.velocity += new Vector2(0, 65 * heldDownTime);
            heldDownTime -= Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            heldDownTime = 0.5f;
        }
    }
    private void FixedUpdate()
    {

    }
}
