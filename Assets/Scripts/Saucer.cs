using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saucer : MonoBehaviour
{
    [SerializeField] int score = 300; //needs to be random
    [SerializeField] AudioClip explodeSound;
    [SerializeField] AudioClip saucerSound;

    GameStatus gameStatus;
    AudioSource myAudioSource;



    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        //myAudioSource = GetComponent<AudioSource>();
        //myAudioSource.loop = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            SoundManager.Instance.Play(explodeSound);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            gameStatus.AddToScore(score);
        }
    }

}

