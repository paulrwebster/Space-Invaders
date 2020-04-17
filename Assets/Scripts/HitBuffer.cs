using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBuffer : MonoBehaviour
{
    bool triggering = false; //use this to ensure trigger only kicked off by one invader at a time
    //public GameObject[] invaderArray;
    public Invader[] invaderArray;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        StartCoroutine(TriggerCoRoutine());
    }


    IEnumerator TriggerCoRoutine()

    {
        if (!triggering)
        {
            triggering = true;
            if (Statics.invaderDirection == 0) { Statics.invaderDirection = 1; }
            else { Statics.invaderDirection = 0; }
            // Move all invaders down
            //invaderArray = GameObject.FindGameObjectsWithTag("Invader");
            invaderArray = FindObjectsOfType<Invader>();
            foreach (Invader invaderInstance in invaderArray)
            {
                invaderInstance.MoveDown();

               // invaderInstance.GetComponent<Invader>().MoveDown();
            }
            yield return new WaitForSeconds(Statics.moveTime * 3);
            triggering = false;
        }
        
    }

  }
