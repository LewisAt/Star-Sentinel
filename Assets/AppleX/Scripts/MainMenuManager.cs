using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject aboutPanel;


    public void Start()
    {
        aboutPanel.SetActive(false);
    }

    public void OpenAbout()
    {
        aboutPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void Return()
    {
        aboutPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
