using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelMarker : MonoBehaviour {

    private ProfileManager profileManager;
    private GameManager gameManager;
    private InGameUI ui;

	// Use this for initialization
	void Start ()
    {
        ui = GameObject.FindGameObjectWithTag("InGameUIController").GetComponent<InGameUI>();
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
        ui.EndLevel();
        Debug.Log("Level Complete");
    }
}
