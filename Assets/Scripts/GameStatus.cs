using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [SerializeField] public Text score1;
    [SerializeField] Text lives1;
    [SerializeField] Text hiscore;
    [SerializeField] public int score_1;
    [SerializeField] int score_2;
    [SerializeField] int hi_score = 0;
    [SerializeField] int lives;
    [SerializeField] Image life2;
    [SerializeField] Image life3;
    [SerializeField] GameObject gun_prefab;
    

    // Start is called before the first frame update
    void Start()
    {
        //load sco_1 with the score saved at the end of the last scene
        //score_1 = PlayerPrefs.GetInt("Score", 0);
        //score1.text = score_1.ToString("000000");
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

    public void setScoreCF() //updates score on disk to carry forward to next level

    {
        PlayerPrefs.SetInt("ScoreCF", score_1);
    }

    public void getScoreCF()  //get score from disk carried forward from previous level
    {
       score_1 = PlayerPrefs.GetInt("ScoreCF",0);
       score1.text = score_1.ToString("000000");
        
    }

    public void SetHighScore(int score)
    {
        if(score > hi_score)
        {
            hi_score = score;
        }
        PlayerPrefs.SetInt("High Score", hi_score);
        hiscore.text = hi_score.ToString("000000");
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
        score_1 = 0;
        PlayerPrefs.SetInt("ScoreCF", 0); //reset score to 0
        getScoreCF();
        SceneLoader sceneLoader;
        sceneLoader = FindObjectOfType<SceneLoader>();
        sceneLoader.LoadEndScene();
    }

}
