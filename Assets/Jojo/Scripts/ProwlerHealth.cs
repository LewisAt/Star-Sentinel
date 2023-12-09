using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProwlerHealth : MonoBehaviour
{
    private float health;
    private SpriteRenderer image;

    private void Start()
    {
        health = 3f;
        image = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        print(health);
    }
    public IEnumerator TakeDamage()
    {
        Color neutralColor = Color.white;
        Color damageColor = Color.red;
        health--;
        if (health < 0f) 
        { 
            Die(); 
        }
        for (int i = 0; i < 3; i++)
        {
            image.color = damageColor;
            yield return new WaitForSeconds(0.1f);
            image.color = neutralColor;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void StartTimer()
    {
        StartCoroutine(TakeDamage());
    }

    public void Die()
    {
        Color alphaChange = image.color;
        alphaChange.a = Mathf.Lerp(1, 0, Time.deltaTime);
        image.color = alphaChange;
    }
}
