using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    private Text scoreText;
    private ProfileManager profileManager;

    // Use this for initialization
    void Start () {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        profileManager = GameObject.FindGameObjectWithTag("ProfileManager").GetComponent<ProfileManager>();
        scoreText.text = "Score: " + 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddToScore(int amtToAdd)
    {
        scoreText.text = "Score: " + profileManager.GetScore();
    }
}
