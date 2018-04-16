using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject statsDisplay;
    public bool paused = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("escape")){
            if(!paused) {
                Pause();
            } else {
                Unpause();
            }
        }
	}

    void Pause()
    {
        paused = true;
        pauseMenu.SetActive(true);
        statsDisplay.SetActive(false);
        Time.timeScale = 0;
    }

    void Unpause()
    {
        paused = false;
        statsDisplay.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        Debug.Log("Going to Main Menu");
    }
}
