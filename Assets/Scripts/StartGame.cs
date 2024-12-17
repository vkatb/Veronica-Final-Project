using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Get Objects -- Assigned in Unity Interface
    public GameObject mainCamera;
    public GameObject titleMenu;
    public GameObject controlsMenu;
    public GameObject levelSelectMenu;

    private int moveDistance = 50;

    // LOAD DIFFERENT LEVELS -- I don't know if there's an easier way to do this but this way works
    
    public void LoadStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
    }

    // CAMERA MOVING COMMANDS -- VIEW MENUS

    public void viewControls()
    {
        mainCamera.transform.Translate(Vector3.right * moveDistance);
        controlsMenu.gameObject.SetActive(true);
        titleMenu.gameObject.SetActive(false);
    }

    public void viewLevelSelect()
    {
        mainCamera.transform.Translate(Vector3.right * moveDistance);
        levelSelectMenu.gameObject.SetActive(true);
        titleMenu.gameObject.SetActive(false);
    }

    public void viewTitleScreen()
    {
        mainCamera.transform.Translate(Vector3.right * -moveDistance);
        titleMenu.gameObject.SetActive(true);
        controlsMenu.gameObject.SetActive(false);
        levelSelectMenu.gameObject.SetActive(false);
    }
}
