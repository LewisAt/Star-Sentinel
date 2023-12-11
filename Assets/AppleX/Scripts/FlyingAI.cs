using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAI : MonoBehaviour
{
    public float distance;
    public float speed;
    public bool isUp;
    public bool alreadyAttack;
    public float counterT;
    public float timeM;
    public GameObject player;
    public GameObject flare;
    public GameObject bullet;
    public Transform bulletPos;
    public float timeShooting;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        counterT = timeM;
        timeShooting = Time.deltaTime;
        
    }
    private void Update()
    {
        
        if (isUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (!isUp)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        counterT -= Time.deltaTime;
        timeShooting += Time.deltaTime;

        if(counterT <= 0)
        {
            counterT = timeM;
            isUp = !isUp;
        }

        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 6 )
        {
           /* flare.SetActive(!alreadyAttack);
            if (!alreadyAttack)
            {*/
               
                if (timeShooting > 3)
                {
                    alreadyAttack = true;
                    timeShooting = 0;
                    shooting();
                }
            
           
             
         

        }
        
    }

    void shooting()
    {
        alreadyAttack = false;
        Instantiate(bullet, bulletPos.position, Quaternion.identity);

    }
}
