﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelMarker : MonoBehaviour {

    private ProfileManager profileManager;
    private GameManager gameManager;

	// Use this for initialization
	void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        profileManager = GameObject.FindGameObjectWithTag("ProfileManager").GetComponent<ProfileManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        profileManager.LevelComplete();
        Debug.Log("Level Complete");
        gameManager.Respawn();
    }
}
