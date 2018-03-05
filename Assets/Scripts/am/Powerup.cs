using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public int id;

    public enum Modifier
    {
        INVINCIBLE,
    }

    private DateTime time;
    private int length = 10;

    public void ActivatePowerup()
    {
        // Initializes a timer that counts down to the powerup expiration
        time = DateTime.Now;
        Debug.Log("Activating powerup");
        time = time.AddSeconds(length);
    }

    public TimeSpan TimeLeft()
    {
        // Returns a TimeSpan object representing the time left before the powerup expires
        // You can use the following to check if a powerup has expired, where
        // TimeSpan notime = new TimeSpan(0);
        // if (myPowerup.TimeLeft().CompareTo(notime) < 0)
        // {
        //     Debug.Log("Powerup has expired");
        // }
        DateTime now = DateTime.Now;
        return time.Subtract(now);
    }

    void Start()
    {
        // No implementation yet
    }

    void Update()
    {
        // No implementation yet
    }
}
