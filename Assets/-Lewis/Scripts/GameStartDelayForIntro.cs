using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartDelayForIntro : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(startGame());
    }

    IEnumerator startGame()
    {
        yield return new WaitForSeconds(30f);
        SceneManager.LoadScene(1);
    }
}
