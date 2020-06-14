using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour
{
    Gun gun ;

    private void Start()
    {
        
    }

    public void Fire()
    {
        gun = FindObjectOfType<Gun>();
        gun.Fire();
    }

    

    


}
