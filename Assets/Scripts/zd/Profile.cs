/*
	Author: Zane Durkin <durk7832@vandals.uidaho.edu>
*/
using System;
using System.Collections.Generic;
using UnityEngine;

public class Profile
{
	private int id;
	public string username;
	public List < int > completedLevels;
	public List < int > tokens;
	public Dictionary < int, int > score;


	public Profile(string username, List < int > completedLevels, List < int > tokens, Dictionary< int, int > score)
	// first option of two for initialization
	{
		// Create a new profile with the data given
		this.username = username;
		this.completedLevels = completedLevels;
		this.tokens = tokens;
		this.score = score;
	}
   
	public Profile(string username)
	// second option of two for initialization
	{
		// Create a new profile, fill fields with empty values, but username is required
		this.username = username;
		this.completedLevels = new List < int >();
		this.tokens = new List < int >();
		this.score = new Dictionary< int, int >();
	}

	public void setLevelScore(int levelId, int score)
	// set the score for the given levelId
	{
		// check if the level already exists in the list
		if (this.score.ContainsKey(levelId)) 
		{
			// if the level exists, overwrite the old score
			this.score[levelId] = score;
		} 
		else 
		{
			// if the level doesn't exist, make it and set the score
			this.score.Add(levelId, score);
		}
	}

	public int GetLevelScore(int levelId)
	// returns score for given levelId or 0 if score isin't set
	{		
		// check if the level has a score
		if (this.score.ContainsKey(levelId)) 
		{
			// if the level exists in the list, return the score
			return this.score[levelId];
		} 
		else 
		{
			// if the level doesn't exits, return 0
			return 0;
		}	
	}

	public void MarkLevelCompleted(int levelId)
	// Add level to completed levels and save to db
	{
		// checks to see if level already exists as completed
		if (!this.completedLevels.Contains(levelId)) 
		{
			// if level isn't completed, mark complete
			this.completedLevels.Add(levelId);
		}
		// save to db when level is complete
		ScoreManager sc = new ScoreManager();
		sc.Save(this);
	}

	public void MarkLevelCompleted(int levelId, int score)
	// Add level to list of completed levels, and set level score
	{
		// set level score
		this.setLevelScore(levelId, score);
		// mark level as complete
		this.MarkLevelCompleted(levelId);
	}

	public List < int > GetTokensCollected()
	// returns list of tokens collected 
	{
		return this.tokens;
	}

	public void SetTokensCollected(List < int > tokens)
	// Overwrite tokens collected
	{
		this.tokens = tokens;
	}

	public void SetTokenCollected(int token)
	// Add token to profile's collected tokens
	{
		// Checks to see if token already exists as collected
		if (!this.tokens.Contains(token))
		{
			// if token hasn't been collected, mark as collected
			this.tokens.Add(token);
		}
	}

	public int GetTotalScore()
	// Finds total score of profile, used for score server
	{
		int total = 0;
		foreach(KeyValuePair<int, int> entry in this.score)
		{
			total = total + entry.Value;
		}
			
		return total;
	}

}
