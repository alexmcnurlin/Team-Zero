using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelectController : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectLevel(int levelNumber)
    {
        switch(levelNumber) {
            case -1:
                SceneManager.LoadScene("TestLevel", LoadSceneMode.Single);
                break;
            case 0:
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                break;
            case 1:
                SceneManager.LoadScene("SimonsLevel", LoadSceneMode.Single);
                break;
            case 2:
                SceneManager.LoadScene("AlexsLevel", LoadSceneMode.Single);
                break;
            case 3:
                SceneManager.LoadScene("JorgesLevel", LoadSceneMode.Single);
                break;
            case 4:
                SceneManager.LoadScene("ZanesLevel", LoadSceneMode.Single);
                break;
        }

    }
}
