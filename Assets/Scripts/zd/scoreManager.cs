/*
	Author: Zane Durkin <durk7832@vandals.uidaho.edu>
*/

using System;
using System.Collections.Generic;

// include sql dependencies 
// thanks https://forum.unity.com/threads/tutorial-how-to-integrate-sqlite-in-c.192282/
// for sqlite dlls
using System.Data;
using Mono.Data.SqliteClient;

public class ScoreManager 
{
	private IDbConnection _db;
	private IDbCommand _dbcommand;
	private IDataReader _dbreader;

	// Use this for initialization
	public ScoreManager(){
		//SetConnection ();
		_db=new SqliteConnection("URI=file:SadProfiles.db");
		// see if db exists, create if it doesn't
		CreateDB();
	}

	/*
	 * 
	 * Public Functions
	 * 
	 */
	public List<Profile> GetAvailableProfiles ()
	{
		List < Profile > profiles = new List < Profile > ();

		//add items in a List collection
		//profiles.Add(0);
		return profiles;
	}
	public Profile GetProfile (String username)
	{
		Profile player = new Profile(username); // will change to read from database
		return player;
	}
	public Profile CreateProfile( String username )
	{
		Profile player = new Profile(username);
		return player;
	}
	public void RemoveProfile (Profile player)
	{
		
	}
	public void RemoveProfile( String username)
	{
		
	}
	public Profile SetLevelScore( Profile player, int levelId, int score)
	{
		return player;
	}
	public Profile GetLevelScore (Profile player, int levelId)
	{
		return player;
	}
	public Profile MarkLevelCompleted (Profile player, int levelId)
	{
		return player;
	}
	public Profile MarkLevelCompleted (Profile player, int levelId, int score)
	{
		return player;
	}
	public List < int > GetTokensCollected (Profile player)
	{

		List < int > tokens = new List < int > ();
		return tokens;
	}
	public Profile SetTokensCollected (Profile player, List < int > tokens)
	{
		return player;
	}
	public Profile SetTokenCollected (Profile player, int token)
	{
		return player;
	}


	/* 
	 * 
	 * Private functions
	 * 
	 */
	private void Save( Profile player )
	{
		
	}
	private void SendToServer( Profile player )
	{
		
	}
	// sqllite connection functions

	private void CreateDB()
	// see if db exists, create file if it doesn't
	{
		string sql = "";
		ExecuteQuery (sql);
	}

	private List < string > ExecuteQuery(string txtQuery) 
	{ 
		_db.Open();	
		_dbcommand=_db.CreateCommand();
		_dbcommand.CommandText = txtQuery;
		_dbcommand.ExecuteNonQuery();
		_dbreader=_dbcommand.ExecuteReader();
		_dbcommand.Dispose ();
		List<string> response = new List<string>();
		while (_dbreader.Read())
		{
			response.Add( _dbreader.GetValue(0).ToString() );
		}
		_db.Close ();
		return response;
	}
}
