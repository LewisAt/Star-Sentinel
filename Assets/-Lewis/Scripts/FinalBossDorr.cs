using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBossDorr : MonoBehaviour
{
    [SerializeField]
    private GameObject DisplayCanvas;
    private bool isInside=false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DisplayCanvas.SetActive(true);
            isInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DisplayCanvas.SetActive(false);
            isInside = false;
        }
    }
    private void FixedUpdate()
    {
        if(isInside && Input.GetKeyDown(KeyCode.E)) 
        {
            SceneManager.LoadScene(4);
        }
    }

}
