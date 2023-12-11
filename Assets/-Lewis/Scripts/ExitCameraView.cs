using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCameraView : MonoBehaviour
{
    private Camera _camera;
    [SerializeField]
    private BoxCollider2D OurCameraExitBox;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag  == "Player")
        {
            Debug.Log("wow you suck at this");

            SceneManager.LoadScene(2);
        }
    }

}
