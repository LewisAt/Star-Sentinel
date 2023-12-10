using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneManager : MonoBehaviour
{
    public TMP_Text HighScoreText;
    // Start is called before the first frame update
    void Start()
    {
        HighScoreText.text = "Your Max Height was: " + PlayerController.StaticDistance;
    }

    // Update is called once per frame fuck fuck fuck fuck fuck fuck fuck my leg hurts
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
