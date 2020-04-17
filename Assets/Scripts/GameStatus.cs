using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [SerializeField] Text score1;
    [SerializeField] Text lives1;
    [SerializeField] Text hiscore;

    [SerializeField] int score_1;
    [SerializeField] int score_2;
    [SerializeField] int hi_score = 0;
    [SerializeField] int lives;
    [SerializeField] Image life2;
    [SerializeField] Image life3;
    [SerializeField] GameObject gun_prefab;
    

    // Start is called before the first frame update
    void Start()
    {
        score1.text = score_1.ToString("000000");
        lives1.text = lives.ToString("0");
        hi_score = PlayerPrefs.GetInt("High Score", 0);
        hiscore.text = hi_score.ToString("000000");
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void AddToScore(int score)
    {
        score_1 += score;
        score1.text = score_1.ToString("000000");
    }

    public void SetHighScore(int score)
    {
        if(score > hi_score)
        {
            hi_score = score;
        }
        PlayerPrefs.SetInt("High Score", hi_score);
    }
     IEnumerator LoseLife()
    {
        lives--;
        lives1.text = lives.ToString("0");
        if (lives <= 1)
        {
            life2.enabled = false;
            life3.enabled = false;
        }
        else if (lives == 2)
        {
            life2.enabled = false;
            life3.enabled = true;
        }
        else
        {
            life2.enabled = true;
            life3.enabled = true;
        }
        
        Statics.paused = true;
        yield return new WaitForSeconds(2);

        if (lives > 0)
        { Statics.paused = false; }

        if (lives > 0)
        {
            Gun MyGun = FindObjectOfType<Gun>();
            MyGun.EnableGun(true);
        }
        else
        {
            EndOfGame();
        }
    }


    public void EndOfGame()
    {
        Statics.paused = true;
        SetHighScore(score_1);
        SceneLoader sceneLoader;
        sceneLoader = FindObjectOfType<SceneLoader>();
        sceneLoader.LoadEndScene();
    }

}
