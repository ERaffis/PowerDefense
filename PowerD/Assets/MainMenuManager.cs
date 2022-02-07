using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public LevelTransition transition;
    public GameObject mainBox;
    public GameObject tutorialBox;
    public GameObject credits;

    public void StartNewGame()
    {
        mainBox.SetActive(false);
        tutorialBox.SetActive(true);
    }

    public void LoadScene(int index)
    {
        transition.StartCoroutine(transition.LoadLevel(index));
    }

    public void ExitGame()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }
    
}
