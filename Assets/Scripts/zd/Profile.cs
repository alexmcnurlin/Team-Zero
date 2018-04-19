/*
	Author: Zane Durkin <durk7832@vandals.uidaho.edu>
*/
using System;
using System.Collections.Generic;
using UnityEngine;

public class Profile : MonoBehaviour
{
	private int id;
	public string username;
	public List < int > completedLevels;
	public List < int > tokens;
	public Dictionary < int, int > score;


	public Profile(string username, List < int > completedLevels, List < int > tokens, Dictionary< int, int > score)
	// first option of two for initialization
	{
		this.username = username;
		this.completedLevels = completedLevels;
		this.tokens = tokens;
		this.score = score;
	}
   
	public Profile(string username)
	// second option of two for initialization
	{
		this.username = username;
		this.completedLevels = new List < int >();
		this.tokens = new List < int >();
		this.score = new Dictionary< int, int >();
	}

	public void setLevelScore(int levelId, int score)
	// set the score for the given levelId
	{
		if (this.score.ContainsKey(levelId)) 
		{
			this.score[levelId] = score;
		} 
		else 
		{
			this.score.Add(levelId, score);
		}
	}

	public int GetLevelScore(int levelId)
	// returns score for given levelId or 0 if score isin't set
	{		
		if (this.score.ContainsKey(levelId)) 
		{
			return this.score[levelId];
		} 
		else 
		{
			return 0;
		}	
	}

	public void MarkLevelCompleted(int levelId)
	// Add level to completed levels and save to db
	{
		// checks to see if level already exists as completed
		if (!this.completedLevels.Contains(levelId)) 
		{
			this.completedLevels.Add(levelId);
		}
		// save to db
		ScoreManager sc = new ScoreManager();
		sc.Save(this);
	}

	public void MarkLevelCompleted(int levelId, int score)
	// Add level to list of completed levels, and set level score
	{
		// checks to see if level already exists as completed
		if (!this.completedLevels.Contains(levelId)) 
		{
			this.completedLevels.Add(levelId);
		}
		// set level score
		this.setLevelScore(levelId, score);
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
			this.tokens.Add(token);
		}
	}

	public int GetTotalScore()
	// Finds total score of profile
	{
		int total = 0;
		foreach(KeyValuePair<int, int> entry in this.score)
		{
			total = total + entry.Value;
		}
			
		return total;
	}

}
