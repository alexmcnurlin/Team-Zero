using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour {
    public int currentScore = 0;
    public string profileName;

    public void Start()
    {
        LoadProfileData(profileName);
    }

    public void AddToScore(int amtToAdd)
    {
        currentScore += amtToAdd;
        Debug.Log("Add " + amtToAdd + " to the score." + " Score is now: " + currentScore);
    }

    public void CollectedToken(int tokenID)
    {
        Debug.Log("WOWEE GOT TOKEN: " + tokenID);
    }

    public void LoadProfileData(string profileName)
    {

    }

    public void SaveProfileData()
    {

    }

    public int GetScore()
    {
        return currentScore;
    }
}
