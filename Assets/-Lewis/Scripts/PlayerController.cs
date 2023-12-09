using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float PlayerSpeedMultiplier = 1f;
    public GameObject Feet;
    private Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horionztal = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3 (horionztal,0, 0);
        direction = direction.normalized * PlayerSpeedMultiplier;
        RaycastHit hit;
        playerRB.AddForce(direction);
        if(Physics.CheckSphere(Feet.transform.position, 0.5f))
        {
            Debug.Log("You Hit A Something");
        }
        
    }
}
