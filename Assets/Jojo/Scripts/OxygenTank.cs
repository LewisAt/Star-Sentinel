using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class OxygenTank : MonoBehaviour
{
    //OxygenTank should only be accessible by UI to display how much Oxygen is left in the tank.
    public float oxygenValue = 100f;
    private float addOxygen = 15f;
    private float removeOxygen = 25f;
    private float oxygenLeak = 2f;
    [SerializeField]
    private float timeBeforeDeath = 3f;
    [SerializeField]
    private Image BackGroundFade;
    [SerializeField]
    private AnimationCurve FadeCurve;



    //This WaitForSeconds could be reused to keep a consistent starting time throughout the game.
    public WaitForSeconds startingTime;

    void Start()
    {
        startingTime = new WaitForSeconds(3);
        StartCoroutine(LoseOxygen());
    }

    void Update()
    {
        if (oxygenValue <= 0)
        {
            timeBeforeDeath -= Time.deltaTime;
            //trigger player death.
        }
        if (timeBeforeDeath <= 0) 
        {

        }
    }
    float curve;
    void fadeinGameOverScreen()
    {
        curve = Mathf.Lerp(curve, 1, 1 * Time.deltaTime);
        float position = FadeCurve.Evaluate(curve);
        Debug.Log(position);


        Color CurrentColor = BackGroundFade.color;
        CurrentColor.a = Mathf.Lerp(BackGroundFade.color.a, 0, position);
        BackGroundFade.color = CurrentColor;
    }
    IEnumerator GameOver()
    {

    }

    private void OnCollisionEnter2D(Collision2D other) //Checks only for collision with oxygen tanks or with enemies/enemy lasers and appropriately addresses the data.
    {
        if (other.gameObject.tag == "Oxygen")
        {
            oxygenValue += addOxygen;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyLaser") oxygenValue -= removeOxygen;
    }

    IEnumerator LoseOxygen() //Timer that'll lower the Oxygen Value until it reaches zero or less.
    {
        //print("coroutine started");
        yield return startingTime;
        while (oxygenValue > 0) 
        {
            oxygenValue -= oxygenLeak;
            yield return new WaitForSeconds(1);
        }
    }
}
