using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TMP_Text TempTextDeleteifNotNeed;
    public LayerMask layermaskforPlayerFeet;
    private bool canJump = true;
    private bool CanDoubleJump = true;
    public SpriteRenderer image;

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
        if(Physics2D.Raycast(Feet.transform.position,Vector2.down,0.2f, layermaskforPlayerFeet))
        {
            Debug.DrawRay(Feet.transform.position, Vector3.down * 5, Color.red);

            canJump = true;
            CanDoubleJump = true;
            //reset jump and double jump
        }
        if (CanDoubleJump && !canJump && Input.GetKeyUp(KeyCode.Space))
        {
            CanDoubleJump = false;
        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            canJump = false;
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(TakeDamage());
        }
        if(TempTextDeleteifNotNeed != null)
        {
            TempTextDeleteifNotNeed.text = "Player Jump : " + canJump + "\nPlayer DoubleJump: " + CanDoubleJump;
        }
        if (Input.GetKey(KeyCode.Space) && heldDownTime > 0.0f && canJump || Input.GetKey(KeyCode.Space) && heldDownTime > 0.0f && CanDoubleJump)
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
    public void takeDamageFunc()
    {
        StartCoroutine(TakeDamage());
    }
    private IEnumerator TakeDamage()
    {
        Color neutralColor = Color.white;
        Color damageColor = Color.red;

        for (int i = 0; i < 3; i++)
        {
            image.color = damageColor;
            yield return new WaitForSeconds(0.1f);
            image.color = neutralColor;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
