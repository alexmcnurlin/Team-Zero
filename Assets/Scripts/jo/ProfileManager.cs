using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour {

    public ScoreManager scoreManager;
    public int score = 0;
    public string profileName;
    public int levelID;
    private Profile p;

    public void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        LoadProfile(profileName);
    }

    public void AddToScore(int amtToAdd)
    {
        score += amtToAdd;
        Debug.Log("Add " + amtToAdd + " to the score." + " Score is now: " + score);
    }

    public void CollectedToken(int tokenID)
    {
        scoreManager.SetTokenCollected(p, tokenID);
    }

    public void LevelComplete()
    {
        scoreManager.MarkLevelCompleted(p, levelID, score);
        SaveProfileData();
    }

    public void LoadProfile(string profileName)
    {
        p = scoreManager.GetProfile(profileName);
        Debug.Log("Loading Profile " + p.username.ToString() + " Saved");
    }

    public void SaveProfileData()
    {
        Debug.Log("Saving Profile " + p.username.ToString() + " Saved");
        scoreManager.Save(p);
    }
}
