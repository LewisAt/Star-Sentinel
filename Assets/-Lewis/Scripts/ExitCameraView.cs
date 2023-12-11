using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExitCameraView : MonoBehaviour
{
    private Camera _camera;
    [SerializeField]
    private BoxCollider2D OurCameraExitBox;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag  == "Player")
        {
            Debug.Log("wow you suck at this");
        }
    }

}
