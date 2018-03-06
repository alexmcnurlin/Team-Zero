using System.Collections;
using System.Collections.Generic;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityEngine;

public class TestingScript : MonoBehaviour {
	//public Player pancake;
	public Player pancake;
	public bool shouldPass;
	TestCases tc; // contains common test functions

	// Use this for initialization
	void Start () {
		this.tc = new TestCases (this.pancake);
		StartCoroutine(RunLevel2 (shouldPass));
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator RunLevel1(bool Pass=true){
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

	IEnumerator RunLevel2(bool Pass=true){
		Debug.Log ("Running Test for Level 2");
		yield return this.tc.Wait (2);

		Debug.Log ("Moving to first step");
		yield return this.tc.MoveRightTillX(8.0f, 2.5f);
		yield return this.tc.Wait (1);
		Debug.Log ("Jummping on first step");
		yield return this.tc.Jump ();
		yield return this.tc.MoveRight(2);
		yield return this.tc.Wait (2);
		Debug.Log ("Jumping on second step");
		yield return this.tc.Jump ();
		yield return this.tc.MoveRight (2);
		yield return this.tc.Wait (2);
		Debug.Log ("Jumping on final step");
		yield return this.tc.Jump();
		yield return this.tc.MoveRight (3, 9.0f);
		yield return this.tc.Wait (2);
		if (Pass) {
			
			Debug.Log ("Jumping over ditch");
			yield return this.tc.Jump ();
			yield return this.tc.MoveRight (4);
			yield return this.tc.Wait (2);
			Debug.Log ("Continuing to finish");
			yield return this.tc.MoveRight (3);
			yield return this.tc.Wait (2);
			yield return this.tc.Jump ();
			yield return this.tc.MoveRight (5);
			yield return this.tc.Wait (3);

			if (this.pancake.transform.position.x > 40) {
				Debug.Log ("Test Passes");
			} else {
				Debug.Log ("Test Failed");
			}

		} else {
			Debug.Log ("Jumping into ditch");
			yield return this.tc.MoveRight (4);
			yield return this.tc.Wait (3);

			if (this.pancake.transform.position.x < 40) {
				Debug.Log ("Test Passed");
			} else {
				Debug.Log ("Test Failed");
			}

		}
	}
		
}
