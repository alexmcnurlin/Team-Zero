using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour {

    public int currentScore = 0;
    public int levelID;
    private ScoreManager sc = new ScoreManager();
    private Profile p;

    public void Start()
    {
        LoadActiveProfile ();  // loads active profile using string saved in playerprefs with "profile" key
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

    public void LoadActiveProfile()
    {
        LoadProfileData(PlayerPrefs.GetString("profile"));  // modified by Alex Parenti, grabs active profile name saved by AP_ActiveProfile
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

    public int GetScore()
    {
        return currentScore;
    }
}
