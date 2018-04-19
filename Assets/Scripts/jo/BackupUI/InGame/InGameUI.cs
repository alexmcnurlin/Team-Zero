using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour {

    private GameObject pauseMenu;
    private GameObject statsDisplay;
    private GameObject endOfLevelMenu;

    private bool paused = false;

	// Use this for initialization
	void Start () {
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        statsDisplay = GameObject.FindGameObjectWithTag("StatsMenu");
        endOfLevelMenu = GameObject.FindGameObjectWithTag("EndOfLevelMenu");

        statsDisplay.SetActive(true);
        pauseMenu.SetActive(false);
        endOfLevelMenu.SetActive(false);
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

    public void EndLevel()
    {
        endOfLevelMenu.SetActive(true);
        pauseMenu.SetActive(false);
        statsDisplay.SetActive(false);
    }
}
