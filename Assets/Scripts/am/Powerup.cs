using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour 
{
    public int id;
	public enum Modifier {
		INVINCIBLE,
	}
	private DateTime time;

	public void ActivatePowerup ()
    {
        // No implmentation yet
    }

	public DateTime TimeLeft ()
    {
        // No implementation yet
		return DateTime.Now;
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
