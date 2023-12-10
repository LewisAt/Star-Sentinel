using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScroll : MonoBehaviour
{
    public float scrollSpeed;

    void Update()
    {
        transform.position += (Vector3.up * scrollSpeed) * Time.deltaTime; 
    }

}
