using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    // MENU VARIABLES -- Assigned in Unity Interface
    public GameObject levelComplete;
    public GameObject levelFailed;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI carrotText;
    public TextMeshProUGUI perfectText;

    // OTHER VARIABLES
    public bool isGameActive = true;
    private int score;
    

    // MENU ACTIVATORS
    public void LevelComplete() {
        isGameActive = false;
        
        levelComplete.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        if (score == 3)
        {
            perfectText.gameObject.SetActive(true);
        }
    }
    public void LevelFailed() {
        if (!levelComplete.gameObject.activeSelf) // Prioritizes level completion over failure, just in case
        {
            levelFailed.gameObject.SetActive(true);
            isGameActive = false;
        }
    }

    // GAME UPDATES

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Carrots: " +score;
        carrotText.text = "Carrots collected: " +score;
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
