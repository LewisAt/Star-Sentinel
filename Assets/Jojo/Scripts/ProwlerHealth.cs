using System.Collections;
using UnityEngine;

public class ProwlerHealth : MonoBehaviour
{
    private int health;
    private SpriteRenderer image;
    public GameObject oxygenDrop;

    private void Start()
    {
        health = 5;
        image = GetComponent<SpriteRenderer>();
    }
    public IEnumerator TakeDamage()
    {
        Color neutralColor = Color.white;
        Color damageColor = Color.red;

        health--;
        if (health <= 0) 
        {
            StartCoroutine(Die());
            yield break;
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

    public IEnumerator Die()
    {
        Color alphaChange = image.color;
        Transform size = gameObject.transform;
        
        for (int i = 0; i < 3;i++)
        {
            alphaChange.a = Mathf.Lerp(alphaChange.a, 0, 0.2f);
            size.localScale = Vector3.Lerp(size.localScale, Vector3.zero, 0.2f);
            gameObject.transform.localScale = size.localScale;
            image.color = alphaChange;
            yield return new WaitForSeconds(0.2f);
        }
        int randomChance = Random.Range(1, 4);
        print(randomChance);
        if (randomChance == 1)
        {
            Instantiate(oxygenDrop, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
