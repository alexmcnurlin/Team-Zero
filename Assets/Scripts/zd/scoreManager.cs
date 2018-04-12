/*
	Author: Zane Durkin <durk7832@vandals.uidaho.edu>
*/

using UnityEngine;

using System;
using System.Collections.Generic;

// include sql dependencies
// thanks https://forum.unity.com/threads/tutorial-how-to-integrate-sqlite-in-c.192282/
// for sqlite dlls
using System.Data;
using Mono.Data.SqliteClient;
public class ScoreManager : SuperClass
{
	private IDbConnection _db;
	private IDbCommand _dbcommand;
	private IDataReader _dbreader;

	public ScoreManager()
	// Use this for initialization
	{
		// Connect to DB file
		_db = new SqliteConnection("URI=file:SadProfiles.db");
		// see if db exists, create if it doesn't
		CreateDB();
	}

	/*
	 *
	 * Public Functions
	 *
	 */
	public List<Profile> GetAvailableProfiles()
	// return profiles in database
	{
		List < Profile > profiles = new List < Profile >();
		string sql = "SELECT `Username` from `Profiles`;";
		IDataReader reader = ExecuteQuery(sql);
		//add items in a List collection
		while (reader.Read()) 
		{
			profiles.Add(GetProfile(reader["Username"].ToString()));
		}
		// return all Profiles
		return profiles;
	}

	public Profile GetProfile(string username)
	// return a profile from database
	{
		string sql = "SELECT * FROM `Profiles` WHERE `Username`='" + username + "' LIMIT 1;";
		IDataReader reader = ExecuteQuery(sql);
		if (reader.Read()) 
		{

			return new Profile(
				reader["Username"].ToString(),
				StringToList(reader["CompletedLevels"].ToString()),
				StringToList(reader["tokens"].ToString()),
				StringToDict(reader["score"].ToString())
			);
		}
		// will only run if reader.read() fails
		return new Profile(username);
	}

	public Profile CreateProfile(string username)
	// create a new profile object
	{
		return new Profile(username);
	}

	public void RemoveProfile(Profile player)
	// remove profile from database
	{
		RemoveProfile(player.username);
	}

	public void RemoveProfile(string username)
	// remove profile from database
	{
		string sql = "DELETE FROM `Profiles` WHERE `Username`='" + username + "' LIMIT 1;";
		ExecuteQuery(sql);
	}

	public Profile SetLevelScore(Profile player, int levelId, int score)
	// set profile object's level score
	{
		player.setLevelScore(levelId, score);
		return player;
	}

	public int GetLevelScore(Profile player, int levelId)
	// get profile object's level score
	{
		return player.GetLevelScore(levelId);
	}

	public Profile MarkLevelCompleted(Profile player, int levelId)
	// Add level to profile's list of completed levels
	{
		player.MarkLevelCompleted(levelId);
		return player;
	}

	public Profile MarkLevelCompleted(Profile player, int levelId, int score)
	// Add level to profile's list of completed levels
	{
		player.MarkLevelCompleted(levelId, score);
		return player;
	}

	public List < int > GetTokensCollected(Profile player)
	// get profile's tokens collected
	{
		return player.GetTokensCollected();
	}

	public Profile SetTokensCollected(Profile player, List < int > tokens)
	// Set token list to profile's list of completed levels
	{
		player.SetTokensCollected(tokens);
		return player;
	}

	public Profile SetTokenCollected(Profile player, int token)
	// Add token to profile's list of completed levels
	{
		player.SetTokenCollected(token);
		return player;
	}

	public void Save(Profile player)
	// writes profile to db
	{
		string sql = "INSERT OR REPLACE INTO `Profiles` (`Id`, `Username`, `CompletedLevels`, `Tokens`, `Score`) VALUES ( (SELECT `Id` FROM `Profiles` WHERE `Username`='" + player.username.ToString() + "' LIMIT 1), '" + player.username.ToString() + "', '" + ListToString(player.completedLevels) + "', '" + ListToString(player.tokens) + "', '" + DictToString(player.score) + "');";
		ExecuteQuery(sql);
		SendToServer(player);
	}


	/*
	 *
	 * Private functions
	 *
	 */


	private void SendToServer(Profile player)
	// Send player scores to server
	{
		// waiting on server implementation
	}

	private List < int > StringToList(string str)
	// converts string to list < int > , ie. "5,3,7" -> {5, 3, 7}
	{
		List < int > lst = new List < int >();
		foreach (string i in str.Split(',')) 
		{
			int j;
			int.TryParse(i, out j);
			lst.Add(j);
		}
		return lst;
	}

	private string ListToString(List < int > list)
	// converts list < int > to string, ie. {5, 3, 7} -> "5,3,7"
	{
		string str = "";
		for (int i = 0; list.Count > i; i++) 
		{
			str = str + list[i].ToString() + ",";
		}
		return str.TrimEnd('n');
	}

	private Dictionary< int, int > StringToDict(string str)
	// converts string to dictionary<int,int>  ie. "1:5,3:2" -> {<1,5>,<3,2>}
	{
		Dictionary < int, int > dict = new Dictionary < int, int >();
		foreach (string i in str.Split(',')) 
		{
			string[] d = i.Split(':');
			int key, val;
			int.TryParse(d[0], out key);
			int.TryParse(d[1], out val);
			dict.Add(key, val);
		}
		return dict;
	}

	private string DictToString(Dictionary < int, int > dict)
	// converts Dictionary < int, int > to a string  ie. {<1,5>,<3,2>} -> "1:5,3:2"
	{
		string str = "";
		foreach (KeyValuePair< int, int> entry in dict) 
		{
			str = str + entry.Key.ToString() + ":" + entry.Value.ToString() + ",";
		}

		return str.TrimEnd(',');
	}

	/*
	 *
	 * SQLlite functions
	 *
	 */

	private void CreateDB()
	// see if db exists, create file if it doesn't
	{
		string sql = "CREATE TABLE IF NOT EXISTS `Profiles` (`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `Username` TEXT NOT NULL, `CompletedLevels` TEXT NOT NULL, `Tokens` TEXT NOT NULL, `Score` TEXT NOT NULL);";
		ExecuteQuery(sql);
	}

	private IDataReader ExecuteQuery(string txtQuery)
	// execute query and then return IDataReader object with result
	{
		_db.Open();
		_dbcommand = _db.CreateCommand();
		_dbcommand.CommandText = txtQuery;
		_dbcommand.ExecuteNonQuery();
		_dbreader = _dbcommand.ExecuteReader();
		_dbcommand.Dispose();
		_db.Close();
		return _dbreader;
	}

	public override void FakeFunc()
	{
		// doesn't do anything, just to show that superclass functions will be overwritten.
	}
}
