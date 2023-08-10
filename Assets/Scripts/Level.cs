using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{ 
    [SerializeField] int InvaderCount = 0;
    [SerializeField] float NormalSpeed;
    [SerializeField] float FastSpeed;
    [SerializeField] float VeryFastSpeed;
    [SerializeField] float GoesLikeStinkSpeed;

    SceneLoader sceneLoader;
    GameStatus gameStatus;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameStatus>();
        Statics.moveTime = NormalSpeed;
        Statics.paused = false;
    }

    void Awake()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        int i = PlayerPrefs.GetInt("ScoreCF", 0);
        gameStatus.score_1 = i;
        gameStatus.score1.text = i.ToString("000000");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    public void IncrementInvaderCount()
    {
        InvaderCount++;
    }

    public void DecrementInvaderCount()
    {
        Debug.Log(InvaderCount);
        InvaderCount--;
        
        if (InvaderCount <= 0) 
        {
            gameStatus.setScoreCF();
            sceneLoader.LoadNextScene();
            //gameStatus.getScoreCF();
        }
        SetMoveTime(InvaderCount);
    }

    public int GetInvaderCount() 
    {
        return InvaderCount;
    }

    void SetMoveTime(int invaderCount)
    {
        if (invaderCount <= 2)
        {
            Statics.moveTime = GoesLikeStinkSpeed;
        }
        else if (invaderCount <= 11 && invaderCount >= 3)
        {
            Statics.moveTime = VeryFastSpeed;
        }
        else if (invaderCount < 33 && invaderCount >= 12)
        {
            Statics.moveTime = FastSpeed;
        }
        else
        {
            Statics.moveTime = NormalSpeed;
        }
    }
}
