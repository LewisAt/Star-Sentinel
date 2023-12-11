using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAToB : MonoBehaviour
{
    public CanvasGroup group;
    public float startvalue;
    public float EndValue;
    public float delayInLerp;

    private float lerpTime;
    private void Start()
    {
        lerpTime = startvalue;
    }
    private void Update()
    {
        lerpTime = Mathf.Lerp(lerpTime, EndValue, delayInLerp * Time.deltaTime); 
        group.alpha = lerpTime;
    }
}
