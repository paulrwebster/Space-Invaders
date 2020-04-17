using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour
{
    Gun gun ;

    private void Start()
    {
        if (SystemInfo.deviceType != DeviceType.Handheld)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Fire()
    {
        gun = FindObjectOfType<Gun>();
        gun.Fire();
    }

    

    


}
