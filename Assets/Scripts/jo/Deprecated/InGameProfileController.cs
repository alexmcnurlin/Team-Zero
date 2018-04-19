using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameProfileController:MonoBehaviour
{

    //MORE DEPRECATED THAN EVAR
    public int currentScore = 0;

    public void AddScore(int amtToAdd)
    {

        currentScore += amtToAdd;
        Debug.Log("Add " + amtToAdd + " to the score." + " Score is now: " + currentScore);
    }

    public void Start()
    {
        Debug.Log("InGameProfileController is deprecated, use ProfileManager instead.");
    }

}