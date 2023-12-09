using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    private float rotateZ;
    private Vector3 turned;

    public GameObject bullet;
    public GameObject flare;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        flare.gameObject.SetActive(false);
        //StartCoroutine(resizeRoutine(15, 25, 3));
    }

    private void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        CheckAngle();

        flare.SetActive(!canFire);
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

    public void CheckAngle()
    {
        rotateZ = transform.rotation.z;
        if (rotateZ > 0.7 || rotateZ < -0.7)
        {
            turned = new Vector3(180, 0, 0);
            transform.Rotate(turned);
        }
    }

    private IEnumerator resizeRoutine(float oldSize, float newSize, float time)
    {
        float elapsed = 0;
        while (elapsed <= time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);

            mainCamera.orthographicSize = Mathf.Lerp(oldSize, newSize, t);
            yield return null;
        }
    }
}
