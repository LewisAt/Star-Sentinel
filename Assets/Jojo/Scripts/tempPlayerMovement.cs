using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class tempPlayerMovement : MonoBehaviour
{
    public float ms = 6;
    public Transform target;
    [HideInInspector] public float heightToReach;
    [HideInInspector] public float currentHeight;
    //public LevelGenerator levelGenerator;

    private void Start()
    {
        currentHeight = 0;
    }

    private void FixedUpdate()
    {
        currentHeight = transform.position.y + 10f;

        Vector3 targetPos = new Vector3(target.position.x,target.position.y,target.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f) ;
        if (Input.GetKey(KeyCode.UpArrow)) { transform.Translate(Vector3.up * ms * Time.deltaTime); }
        if (Input.GetKey(KeyCode.DownArrow)) { transform.Translate(Vector3.down * ms * Time.deltaTime); }
        if (Input.GetKey(KeyCode.LeftArrow)) { transform.Translate(Vector3.left * ms * Time.deltaTime); }
        if (Input.GetKey(KeyCode.RightArrow)) { transform.Translate(Vector3.right * ms * Time.deltaTime); }

        /*if (transform.position.y >= levelGenerator.backgroundChoices[levelGenerator.GlobalCurrentRoll].backgroundSize.position.y)
        {
            levelGenerator.CreatePage();
        }
        if (transform.position.y < levelGenerator.backgroundChoices[levelGenerator.GlobalCurrentRoll].backgroundSize.position.y)
        {
            levelGenerator.DestroyPage();
        }*/

    }

}
