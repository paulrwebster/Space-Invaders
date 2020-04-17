using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // if (currentSceneIndex <= 1)
        // {
        Debug.Log(currentSceneIndex);
        //Statics.paused = false;

        SceneManager.LoadScene(currentSceneIndex + 1);
       // }
       // else
        //{ 
        //    LoadStartScene();
        //}
    }

    public void LoadStartScene()
    {
       // Statics.paused = false;
        SceneManager.LoadScene(0);
    }

    public void LoadEndScene()
    {

        SceneManager.LoadScene("GameOverScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
