using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : MonoBehaviour
{
    //hit1 and hit2 are the spprites thatoverlay the bunkers to show damage after a hit
    public GameObject hit1;
    public GameObject hit2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet" || collision.tag == "Bomb")
        {
            int hit = Random.Range(1, 3);
            if (hit == 1)
            {
                Instantiate(hit1, this.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(hit2, this.transform.position, Quaternion.identity);
            }   
            Destroy(collision.gameObject);
            Destroy(this.gameObject.GetComponent<Collider2D>());
        }
        if (collision.tag == "Invader")
        {
            Destroy(this.gameObject);
        }
    }

   
}
