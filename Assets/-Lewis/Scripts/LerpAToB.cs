using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LerpAToB : MonoBehaviour
{
    public CanvasGroup group;
    public float startvalue;
    public float EndValue;
    public float delayInLerp;
    public bool isFinalboss = false;
    private float lerpTime;
    private void Start()
    {
        lerpTime = startvalue;
    }
    private void Update()
    {
        lerpTime = Mathf.Lerp(lerpTime, EndValue, delayInLerp * Time.deltaTime);
        Debug.Log(lerpTime);
        group.alpha = lerpTime;
        if(isFinalboss )
        {
            Invoke("loadCredits", 5);
        }

    }
    void loadCredits()
    {
        SceneManager.LoadScene(5);
    }
}
