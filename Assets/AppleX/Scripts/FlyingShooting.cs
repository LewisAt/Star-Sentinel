using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingShooting : MonoBehaviour
{

    private GameObject player;
    private PlayerController controller;
    private Rigidbody2D rb;
    public float force;
    public float time;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        controller = player.GetComponent<PlayerController>();
        

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0,rot );
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 10)
        {
            Destroy(gameObject);
        }
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            player.GetComponent<OxygenTank>().oxygenValue -= 5;
            controller.takeDamageFunc();
            Destroy(gameObject);

            
        }
    }

   
}
