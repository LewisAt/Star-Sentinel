using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float CameraFollowDelay = 0.05f;
    private GameObject player;


    private Vector2 cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        float xLerp = Mathf.Lerp(this.transform.position.x, player.transform.position.x, CameraFollowDelay);
        this.transform.position = new Vector3(xLerp, this.transform.position.y + (2.7f * Time.deltaTime), -10);

    }
}
