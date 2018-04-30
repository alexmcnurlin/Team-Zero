using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour {

    private GameObject pauseMenu;
    private GameObject statsDisplay;
    private GameObject endOfLevelMenu;
    public GameObject dialogueBox;

    private bool paused = false;

	// Use this for initialization
	void Start () {
        dialogueBox = GameObject.FindGameObjectWithTag("DialogueCanvas");
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        statsDisplay = GameObject.FindGameObjectWithTag("StatsMenu");
        endOfLevelMenu = GameObject.FindGameObjectWithTag("EndOfLevelMenu");

        statsDisplay.SetActive(true);
        pauseMenu.SetActive(false);
        endOfLevelMenu.SetActive(false);
        dialogueBox.SetActive(false);
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

    public void Pause()
    {
        pauseMenu.SetActive(true);
        statsDisplay.SetActive(false);
        PauseGame();
    }

    public void Unpause()
    {
        paused = false;
        statsDisplay.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
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
