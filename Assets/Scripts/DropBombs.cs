using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DropBombs : MonoBehaviour
{
    public Invader[] invaderArray;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(dropInvaderBomb());

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator dropInvaderBomb()
    {
        
        while (true)
        {
            List<Invader> invaderList = new List<Invader>();
            invaderList.AddRange(FindObjectsOfType<Invader>());

            //Grab a random invader            
            Invader invaderInstance = invaderList[Random.Range(0, invaderList.Count - 1)];
            
            //Find the invader in the same column on the loweat row
            foreach (Invader invaderInstance2 in invaderList)
            {
                if (invaderInstance2.GetColumn() == invaderInstance.GetColumn())
                {
                    if (invaderInstance2.GetRow() < invaderInstance.GetRow())
                    {
                        invaderInstance = invaderInstance2;
                    }
                }
            }
            invaderInstance.Bomb();
            yield return new WaitForSeconds(Random.Range(0.1f, 1.0f));
        }
    }

    

} 
