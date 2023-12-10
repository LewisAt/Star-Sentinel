using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera cam;
    private Rigidbody2D rb;
    private Vector3 origin;

    public float force;

    private void Start()
    {
        origin = transform.position;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        
        //If we want the bullet to rotate, uncomment this part:
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void Update()
    {
        if (Vector3.Distance(origin, transform.position) > 25f) { Destroy(this.gameObject); }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            if (collision.gameObject.GetComponent<ProwlerHealth>() != null)
            {
                collision.gameObject.GetComponent<ProwlerHealth>().StartTimer();
                Destroy(this.gameObject);
            }
            else if (collision.gameObject.GetComponent<AlienHealth>() != null)
            {
                collision.gameObject.GetComponent <AlienHealth>().StartTimer();
                Destroy(this.gameObject);
            }
            else if(collision.gameObject.GetComponent<BossHealth>() != null)
            {
                collision.gameObject.GetComponent<BossHealth>().StartTimer();
                Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.tag != "Player" || collision.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
}