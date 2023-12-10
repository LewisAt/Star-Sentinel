using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class ProwlerMovement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public GameObject prowler;

    public float speed;

    public LayerMask downCape;
    public LayerMask frontCape;

    public float downDistance;
    public float frontDistance;

    public Transform downController;
    public Transform frontController;
    

    public bool downInfo;
    public bool frontInfo;

    public bool isRight = true;


   
    public void Update()
    {
        
        rb2D.velocity = new Vector2(speed, rb2D.velocity.y); 
        frontInfo = Physics2D.Raycast(frontController.position, transform.right ,frontDistance,frontCape);
        downInfo = Physics2D.Raycast(downController.position, transform.up *-1, downDistance, downCape);

        if(!downInfo)
        {
            Turn();
        }
        if(frontInfo == true)
        {
            Chase();
        }
       
    }

    private  void Turn()
    {
        isRight = !isRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 180, 0);
        speed *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(downController.transform.position, downController.transform.position + transform.up * -1 * downDistance);
        Gizmos.DrawLine(frontController.transform.position, frontController.transform.position + transform.right  * frontDistance);
    }

    private void Chase()
    {
        rb2D.velocity = new Vector2(speed * 2, rb2D.velocity.y);
    }
 
}
