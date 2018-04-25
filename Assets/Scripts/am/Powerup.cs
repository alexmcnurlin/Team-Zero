using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Modifier
{
    INVINCIBLE,
    JUMPHEIGHT,
    SPEED,
}

public class Powerup : MonoBehaviour
{
    private PowerupSoundManager soundManager;
    public delegate void Del();
    public int id;
    public Modifier type;
    public int length = 10;
    public Del StopAudio;

    private DateTime time;

    public void ActivatePowerup()
    {
        // Initializes a timer that counts down to the powerup expiration
        time = DateTime.Now;
        Debug.Log("Activating powerup");
        time = time.AddSeconds(length);

        // Play sound effect
        soundManager.PlayAudio(type);
    }

    public TimeSpan TimeLeft()
    {
        // Returns a TimeSpan object representing the time left before the powerup expires
        // You can use the following to check if a powerup has expired:

        // TimeSpan notime = new TimeSpan(0);
        // if (myPowerup.TimeLeft().CompareTo(notime) < 0)
        // {
        //     Debug.Log("Powerup has expired");
        // }
        DateTime now = DateTime.Now;
        return time.Subtract(now);
    }

    public bool IsExpired()
    {
        // Lets the calling object know if this powerup is expired.
        // If it is expired, stop playing any music.
        TimeSpan notime = new TimeSpan(0);
        bool returnVal = (TimeLeft().CompareTo(notime) < 0);
        if (returnVal)
        {
            Debug.Log("Powerup has expired");
            StopAudio();
        }
        return returnVal;
    }

    void Start()
    {
        soundManager = PowerupSoundManager.getInstance();
        StopAudio = soundManager.StopAudio;
    }

    void Update()
    {
    }
}
