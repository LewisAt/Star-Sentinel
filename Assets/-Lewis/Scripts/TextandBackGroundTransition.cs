using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextandBackGroundTransition : MonoBehaviour
{
    public GameObject PointB;
    public GameObject PointA;
    public GameObject GameObjectToMove;
    public Image CanvasToFadeAway;
    public float BeforeStartDelay;
    public float DelayInMovement;
    public AnimationCurve BendBend;

    private bool canLerp = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delayAtTheEnd());
    }

    // Update is called once per frame
    void Update()
    {
        if(canLerp)
        {
            lerpToDefaultPositon();
        }
    }
    IEnumerator delayAtTheEnd()
    {
        yield return new WaitForSeconds(BeforeStartDelay);
        canLerp = true;
    }
    float curve = 0;
    void lerpToDefaultPositon()
    {
        curve = Mathf.Lerp(curve, 1, DelayInMovement * Time.deltaTime);
        float position = BendBend.Evaluate(curve);
        Debug.Log(position);
        
        GameObjectToMove.transform.position = Vector3.Lerp(PointA.transform.position, PointB.transform.position, position);
        Color CurrentColor = CanvasToFadeAway.color;
        CurrentColor.a = Mathf.Lerp(CanvasToFadeAway.color.a, 0, DelayInMovement * Time.deltaTime);
        CanvasToFadeAway.color = CurrentColor;
    }
}
