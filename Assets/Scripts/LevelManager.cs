using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // MENU VARIABLES -- Assigned in Unity
    public GameObject levelComplete;
    // other menus later.


    // public bool isGameActive = true; // Will get called to stop player and stuff later on
    
    // MENU ACTIVATORS

    public void LevelComplete() {
        levelComplete.gameObject.SetActive(true);
        // isGameActive = false;
    }

    // SCENE LOADERS CONNECTED TO BUTTONS
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Restart() // Currently Unused.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
