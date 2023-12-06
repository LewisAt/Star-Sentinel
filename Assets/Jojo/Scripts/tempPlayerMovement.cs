using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayerMovement : MonoBehaviour
{
    public float ms = 6;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow)) { transform.Translate(Vector3.up * ms * Time.deltaTime); }
        if (Input.GetKey(KeyCode.DownArrow)) { transform.Translate(Vector3.down * ms * Time.deltaTime); }
    }

}
