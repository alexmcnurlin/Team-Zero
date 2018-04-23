using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour {

    public int levelNumber;
    GameObject levelSelecter;
    // Use this for initialization
    void Start () {
        levelSelecter = GameObject.FindGameObjectWithTag("LevelSelectController");

        Button thisButton = gameObject.GetComponent(typeof(Button)) as Button;
        thisButton.onClick.AddListener(LoadLevel);
	}

    // Update is called once per frame
    void Update () {
		
	}

    void LoadLevel()
    {
        levelSelecter.gameObject.SendMessage("SelectLevel", levelNumber);
    }


}
