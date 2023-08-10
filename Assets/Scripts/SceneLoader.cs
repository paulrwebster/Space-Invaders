using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      
        //Debug.Log(currentSceneIndex);
        //Statics.paused = false;
        
        SceneManager.LoadScene(currentSceneIndex + 1);
        
         if(SceneManager.GetSceneByBuildIndex(currentSceneIndex + 1).name == "GameOverScene")
        {
            GameStatus gameStatus;
            gameStatus = FindObjectOfType<GameStatus>();
            gameStatus.EndOfGame();
        }
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
