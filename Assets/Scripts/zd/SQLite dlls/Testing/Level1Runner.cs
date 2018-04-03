using System.Collections;
using System.Collections.Generic;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine;

public class Level1Runner : MonoBehaviour 
{
	//public Player pancake;
	public Player pancake;
	public bool shouldPass;
	TestCases tc; // contains common test functions

	// Use this for initialization
	void Start () 
	{
		this.tc = new TestCases (this.pancake);
		StartCoroutine(RunLevel (shouldPass));
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	IEnumerator RunLevel(bool Pass=true)
	{
		Debug.Log ("Running Test for Level 1");
		yield return this.tc.Wait (2);
		yield return this.tc.MoveRight (5, 5.0f);
		yield return this.tc.Wait (1);
		yield return this.tc.MoveLeft (5);
		yield return this.tc.Wait (1);
		yield return this.tc.MoveRight (5);
		yield return this.tc.Wait (1);
		yield return this.tc.Jump ();
		yield return this.tc.Wait (4);
		yield return this.tc.MoveRight (5);
		yield return this.tc.Jump ();
	}
		
}
