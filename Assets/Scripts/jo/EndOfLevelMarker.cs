using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOfLevelMarker : MonoBehaviour {

    private ProfileManager profileManager;
    private GameManager gameManager;
    private InGameUI ui;
    private bool levelComplete = false;

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
        if(!levelComplete) 
        {
            levelComplete = true;
            profileManager.LevelComplete();
            ui.EndLevel();
            ui.dialogueBox.SetActive(true);
            ui.dialogueBox.GetComponentInChildren<Text>().text = "Congratulations!";
            StartCoroutine(Wait(4));
        }
    }

    IEnumerator Wait(int dTime)
    {
        yield return new WaitForSeconds(dTime);
        SceneManager.LoadScene("MainMenu");
    }
}
