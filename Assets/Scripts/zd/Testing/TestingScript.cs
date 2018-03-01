using System.Collections;
using System.Collections.Generic;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine;

public class TestingScript : MonoBehaviour {
	//public Player pancake;
	public Player pancake;

	TestCases tc; // contains common test functions

	// Use this for initialization
	void Start () {
		this.tc = new TestCases (this.pancake);
		StartCoroutine(RunLevel1 (true));
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator RunLevel1(bool Pass=true){
		Debug.Log ("Running Test for Level 1");

		Debug.Log ("Running Right");
		yield return this.tc.MoveRight (5, 10.0f);
		yield return this.tc.Wait (1);
		yield return this.tc.MoveLeft (5, 10.0f);
		yield return this.tc.Wait (1);
		yield return this.tc.MoveRight (5, 10.0f);
		yield return this.tc.Wait (1);
		yield return this.tc.Jump ();
	}

	void RunLevel2(bool Pass=true){
	}
		
}
