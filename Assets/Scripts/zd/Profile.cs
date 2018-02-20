/*
	Author: Zane Durkin <durk7832@vandals.uidaho.edu>
*/
using System;
using System.Collections.Generic;

public class Profile 
{

	public string username;
	public List < int > completedLevels;
	public List < int > tokens;
	private int [ ] score;

	// Use this for initialization
	public Profile (string username, List < int > completedLevels, List < int > tokens, int[ ] score)
	{
		this.username = username;
		this.completedLevels = completedLevels;
		this.tokens = tokens;
		this.score = score;
	}
	public Profile (string username)
	{
		this.username = username;
		this.completedLevels = new List < int > ();

	}


	public void setLevelScore(int levelId, int score)
	{
		this.score [levelId] = score;
	}
	public int GetLevelScore (int levelId)
	{
		return this.score [levelId];	
	}
	public void MarkLevelCompleted (int levelId)
	{
		// will add checks to see if level already exists
		this.completedLevels.Add(levelId);
	}
	public void MarkLevelCompleted (int levelId, int score)
	{
		
	}
	public List < int > GetTokensCollected ()
	{

		return tokens;
		
	}
	public void SetTokensCollected (List < int > tokens)
	{
		
	}
	public void SetTokenCollected(int token)
	{
		
	}
}