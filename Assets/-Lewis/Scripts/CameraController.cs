using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float CameraFollowDelay = 0.05f;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPositon = Vector3.Lerp(this.transform.position, player.transform.position, CameraFollowDelay * Time.deltaTime);
        cameraPositon.z = -10;
        
        this.transform.position = cameraPositon;
        
    }
}
