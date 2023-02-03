using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GunHandler : MonoBehaviour
{
    public GameObject ammo;
    public int ammoAmount = 31;
    
    public bool active;
    public float secondsRemaining;
    public float secondsBetweenShots;
    private bool timerStart;

    private void Start()
    {
        
    }

    private void Timer()
    {
        secondsRemaining -= Time.deltaTime;
        if (secondsRemaining <= 0)
        {
            secondsRemaining = secondsBetweenShots;
            timerStart = false;
        }
    }
    private void Update()
    {
        if (timerStart)
        {
            Timer();
        }
        if (active)
        {
            if (Input.GetMouseButton(0) && ammoAmount > 0 && timerStart == false)
            {
                Vector3 spawnpoint = new Vector3(0, 0.8f, 0);
                GameObject bullet = Instantiate(ammo,spawnpoint, quaternion.identity);
                bullet.transform.SetParent(transform, false);
                bullet.transform.SetParent(null);
                ammoAmount -= 1;
                timerStart = true;
            }
        }        
    }
}
