using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera cam;
    private Rigidbody2D rb;

    public float force;

    private void Start()
    {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
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
        }
        else if (collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}