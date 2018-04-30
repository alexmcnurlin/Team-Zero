using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu:MonoBehaviour {

    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject levelSelect;

    // Use this for initialization
    void Start()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
        settingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowLevelSelect()
    {
        levelSelect.SetActive(true);
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void ShowSettings()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
        levelSelect.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}