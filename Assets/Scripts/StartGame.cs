using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Get Camera -- Assigned in Unity Interface
    public GameObject mainCamera;

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void viewControls()
    {
        //Transform...
    }
    public void viewTitleScreen()
    {
        //Transform...
    }
}
