using System.Collections;
using System.Collections.Generic;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine;

public class TestLevelRunner : MonoBehaviour 
{
	//public Player pancake;
	public Player pancake;
	public bool shouldPass;
	TestCases tc; // contains common test functions

	// Use this for initialization
	void Start () 
	{
		this.tc = new TestCases (this.pancake);
		StartCoroutine(RunLevel(shouldPass));
	}
	
	// Update is called once per frame
	void Update () 
	{
	}


	IEnumerator RunLevel(bool Pass=true)
	{
		Debug.Log ("Running Test for Test Level");
		yield return this.tc.Wait (2);
		Debug.Log ("Moving to first step");
		yield return this.tc.MoveToX (11.3f, 5f);
		yield return this.tc.Wait (1);
		Debug.Log ("Jummping on first step");
		yield return this.tc.Jump ();
		yield return this.tc.MoveRight(2);
		yield return this.tc.Wait (2);
		Debug.Log ("Move to step 2");
		yield return this.tc.MoveToX (16f, 5f);
		Debug.Log ("Jumping on second step");
		yield return this.tc.Jump ();
		yield return this.tc.MoveRight (2);
		yield return this.tc.Wait (2);
		yield return this.tc.MoveToX (21f, 5f);
		Debug.Log ("Jumping on final step");
		yield return this.tc.Jump();
		yield return this.tc.MoveRight (3, 9.0f);
		yield return this.tc.Wait (2);
		yield return this.tc.MoveToX (28.3f, 4.5f);
		if (Pass) 
		{
			
			Debug.Log ("Jumping over ditch");
			yield return this.tc.Jump ();
			yield return this.tc.MoveRight (4);
			yield return this.tc.Wait (2);
			Debug.Log ("Continuing to finish");
			yield return this.tc.MoveRight (3);
			yield return this.tc.Wait (2);
			yield return this.tc.Jump ();
			yield return this.tc.MoveRight (7);
			yield return this.tc.Wait (3);

			if (this.pancake.transform.position.x > 40) 
			{
				Debug.Log ("Test Passes");
			}
			else
			{
				Debug.Log ("Test Failed");
			}

		} 
		else 
		{
			Debug.Log ("Jumping into ditch");
			yield return this.tc.MoveRight (4);
			yield return this.tc.Wait (3);

			if (this.pancake.transform.position.x < 40)
			{
				Debug.Log ("Test Passed");
			} 
			else 
			{
				Debug.Log ("Test Failed");
			}
		}
	}
}
