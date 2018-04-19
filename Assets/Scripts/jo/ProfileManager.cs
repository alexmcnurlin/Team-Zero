using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour {

    public string profileName = "Test";
    public int currentScore = 0;
    public int levelID;
    private ScoreManager sc = new ScoreManager();
    private Profile p;

    public void Start()
    {
        LoadProfileData(profileName);
        SaveProfileData();
    }

    public void AddToScore(int amtToAdd)
    {
        currentScore += amtToAdd;
        p.setLevelScore(levelID, currentScore);
        Debug.Log("Add " + amtToAdd + " to the score." + " Score is now: " + currentScore);
    }

    public void CollectedToken(int tokenID)
    {
        sc.SetTokenCollected(p, tokenID);
        Debug.Log("Collected Token: " + tokenID);
    }

    public void LevelComplete()
    {
        sc.MarkLevelCompleted(p, levelID, currentScore);
        SaveProfileData();
    }

    public void LoadProfileData(string profileName)
    {
        p = sc.GetProfile(profileName);
        Debug.Log("Loading Profile " + p.username.ToString() + " Saved");
    }

    public void SaveProfileData()
    {
        Debug.Log("Saving Profile " + p.username.ToString() + " Saved");
        sc.Save(p);
    }
}
