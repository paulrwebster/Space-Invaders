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

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        Statics.moveTime = NormalSpeed;
        Statics.paused = false;
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
        
        if (InvaderCount <= 0) { sceneLoader.LoadNextScene();}
        SetMoveTime(InvaderCount);
    }

    public int GetInvaderCount() 
    {
        return InvaderCount;
    }

    void SetMoveTime(int invaderCount)
    {
        //if(invaderCount <= 2) 
        //{
        //    Statics.moveTime = GoesLikeStinkSpeed;
        //}
        //else if (invaderCount <= 5 && invaderCount >= 3)
        //{
        //    Statics.moveTime = VeryFastSpeed;
        //}
        //else if (invaderCount < 12 && invaderCount >= 6)
        //{
        //    Statics.moveTime = FastSpeed;
        //}
        //else 
        //{
        //    Statics.moveTime = NormalSpeed;

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
