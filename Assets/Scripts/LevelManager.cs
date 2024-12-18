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
    public GameObject gameUI;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI carrotText;
    public TextMeshProUGUI perfectText;

    // OTHER VARIABLES
    public bool isGameActive = true;
    private int score;
    private float gravityFixer = 1.6f;
    

    // MENU ACTIVATORS
    public void LevelComplete() {
        if (isGameActive)
        {
            isGameActive = false;
            Physics.gravity /= gravityFixer;
            
            levelComplete.gameObject.SetActive(true);
            carrotText.gameObject.SetActive(true);
            gameUI.gameObject.SetActive(false);
            if (score == 3)
            {
                perfectText.gameObject.SetActive(true);
            }
        }
    }
    public void LevelFailed() {
        if (!levelComplete.gameObject.activeSelf && isGameActive) // Prioritizes level completion over failure, just in case
        {
            isGameActive = false;
            Physics.gravity /= gravityFixer;
            gameUI.gameObject.SetActive(false);
            carrotText.gameObject.SetActive(true);
            levelFailed.gameObject.SetActive(true);
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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
