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

    private int moveDistance = 50;

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void viewControls()
    {
        mainCamera.transform.Translate(Vector3.right * moveDistance);
        controlsMenu.gameObject.SetActive(true);
        titleMenu.gameObject.SetActive(false);
    }
    public void viewTitleScreen()
    {
        mainCamera.transform.Translate(Vector3.right * -moveDistance);
        titleMenu.gameObject.SetActive(true);
        controlsMenu.gameObject.SetActive(false);
    }
}
