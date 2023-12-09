using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    private float rotateZ;
    private Quaternion turned;

    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rotateZ = transform.rotation.z;
    }

    private void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (rotateZ < -90 && rotateZ > 90)
        {
            turned = Quaternion.Euler(0, 180, 0);
            transform.rotation = turned;
        }
        else
        {
            turned = Quaternion.Euler(0, 0, transform.rotation.z);
            transform.rotation = turned;
        }


        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet,bulletTransform.position, Quaternion.identity);
        }
    }
}
