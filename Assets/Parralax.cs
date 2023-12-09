using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    public GameObject resetPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3 (0f, 1 * Time.deltaTime, 0f);
        if (transform.localPosition.y <= -15)
        {
            transform.position = resetPoint.transform.position;
        }
    }
}
