using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameProfileController:MonoBehaviour
{
    //Dictionary<myComplex, int> myMap = new Dictionary<myComplex, int>();
    public int currentScore = 0;

    public void AddScore(int amtToAdd)
    {
        currentScore += amtToAdd;
        Debug.Log("Add " + amtToAdd + " to the score." + " Score is now: " + currentScore);
    }
    
}