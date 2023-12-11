using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public BossCamera bossCamera;
    public GameObject player;
    public GameObject Laser;
    public Transform LaserPosition;
    [SerializeField] private Transform[] waypoints;
    private int currentWaypoint;
    public float speed;
    public float distance;
    public float timeShooting;
    public float timeLaser;
    public float LaserShooting;
    public GameObject ZoneL;
    bool isShooting;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ZoneL.SetActive(false);
        LaserShooting = 0;
        StartCoroutine(IncreaseTime());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (bossCamera.startedPlaying == true)
        {
            
            print(LaserShooting);
            isShooting = true;
            timeShooting += Time.deltaTime;

          
            if (transform.position != waypoints[currentWaypoint].position)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
            }
            else
            {
                currentWaypoint++;
            }
            if(currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
            if (isShooting)
            {
                if (timeShooting > 1)
                {
                    timeShooting = 0;
                    Shooting();
                }
            }
            if (LaserShooting > 30)
            {

                ZoneL.SetActive(true);
                isShooting = false;
            }
            if (LaserShooting >= 40)
            {
                LaserShooting = 0;
            }
            if (LaserShooting <= 30)
            {
                isShooting = true;
                ZoneL.SetActive(false);
            } 

              
              
            }


        
    }

    void Shooting()
    {
        Instantiate(Laser, LaserPosition.position, Quaternion.identity);
    }
    IEnumerator IncreaseTime()
    {
        while (LaserShooting >= 0)
        {
            yield return new WaitForSeconds(1);
            LaserShooting++;
        }
    }
}

 

