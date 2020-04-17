using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{

    public Sprite invaderA;
    public Sprite invaderB;
    

    [SerializeField] float moveX = 0.5f;
    [SerializeField] float moveY = 0.4f;
    [SerializeField] int score = 10;
    [SerializeField] int row = 0;
    [SerializeField] int column = 0;
    [SerializeField] GameObject bombPrefab;
    [SerializeField] float bombSpeed = -5f;
    [SerializeField] float bombPadding = -0.4f;
    [SerializeField] bool dropBomb = false;


    //cached reference
    GameStatus gameStatus;
    Level level;

    GameObject bombInstance;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();
        level.IncrementInvaderCount();
        //InvokeRepeating("MoveInvadersX", 0.1f, Statics.moveTime);
        StartCoroutine(MoveInvadersX());
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            //GameObject.FindObjectOfType<GameStatus>().AddToScore(this.score);     
            gameStatus.AddToScore(score);
            level.DecrementInvaderCount();
        }
        if (collision.tag == "Shredder")
        {
            if (Statics.paused == false)
            {
                Statics.paused = true;
                Destroy(this.gameObject);
                FindObjectOfType<GameStatus>().StartCoroutine("LoseLife");
                gameStatus.EndOfGame();
            }
        }
    }

        IEnumerator MoveInvadersX()
    {
        while (true)
        { 
            StartCoroutine(Move());
            yield return new WaitForSeconds(Statics.moveTime);
        }
    }
    

    IEnumerator Move()
    {
        if (Statics.paused == false)
        {
            float moveDelay = 0f;
            //Grab the direction from statics berfore the delay to ensure that all invaders head in the same direction
            int direction = Statics.invaderDirection;

            //Make them wobble along
            if (this.row == 5) { moveDelay = Statics.moveTime * 0.4f; }
            if (this.row == 4) { moveDelay = Statics.moveTime * 0.3f; }
            if (this.row == 3) { moveDelay = Statics.moveTime * 0.20f; }
            if (this.row == 2) { moveDelay = Statics.moveTime * 0.1f; }
            if (this.row == 1) { moveDelay = 0f; }

            //if (this.row == 5) { moveDelay = 0.40f; }
            //if (this.row == 4) { moveDelay = 0.3f; }
            //if (this.row == 3) { moveDelay = 0.20f; }
            //if (this.row == 2) { moveDelay = 0.1f; }
            //if (this.row == 1) { moveDelay = 0f; }

            InvaderAudio.Instance.PlayInvaderSounds();
            yield return new WaitForSeconds(moveDelay);
            if (direction == 0)
            {
                this.gameObject.GetComponent<Transform>().position += new Vector3(moveX, 0, 0);
            }
            else
            {
                this.gameObject.GetComponent<Transform>().position -= new Vector3(moveX, 0, 0);
            }

            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == invaderA)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = invaderB;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = invaderA;
            }

        }
    }

    

    //This is called by HitBuffer.cs
    public void MoveDown()
    {
        if (Statics.paused == false)
        {
            this.gameObject.GetComponent<Transform>().position -= new Vector3(0, moveY, 0);
        }
    }

    public void Bomb()
    {
        if (Statics.paused == false)
        { 
            if (GameObject.FindWithTag("Bomb") is null)
            {
                bombInstance =
                Instantiate(bombPrefab, transform.position + new Vector3(0, bombPadding, 0), Quaternion.identity)
                as GameObject;
                bombInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bombSpeed);
   
            }
        }
    }

    public int GetRow() {return row;}

    public int GetColumn() {return column;}

   


}
