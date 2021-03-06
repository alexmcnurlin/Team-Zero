﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCases
{
	Player pancake;
	public Rigidbody2D pc_rigid;

	public TestCases (Player pancake)
	{
		this.pancake = pancake;
		this.pc_rigid = pancake.GetComponent<Rigidbody2D>();
	}

	/*
	 * Public functions
	 */

	public IEnumerator Wait( float seconds)
	/* pauses for the give seconds */
	{
		yield return new WaitForSeconds (seconds);
	}

	/* 
	 * Movement functions 
	 */
	 
	public IEnumerator MoveToX(float x, float force = 5.0f, float precision = 0.5f, double timeout = 10.0)
	/* Moves Player until it reaches the given x value */
	{
		double end_time = Time.realtimeSinceStartup + timeout; // 1.0 = 1 second
		// run till x is reached, or timeout is reached
		while (pancake.transform.position.x > x + precision || pancake.transform.position.x < x - precision) 
		{
			if (end_time < Time.realtimeSinceStartup)
			{
				Debug.Log ("Move to X Timeout");
				break;
			}
			// If player is to far to the left
			while (pancake.transform.position.x < x - precision) 
			{
				// Slow Player as it approaches the destination, but no slower than 1.0f force.
				yield return MoveRight (1, force * Mathf.Max( Mathf.Abs( (x - pancake.transform.position.x) / x ) , 1.0f) );
				yield return this.Wait (0.05f);
			}
			// If Player is to far to the right
			while (pancake.transform.position.x > x + precision) 
			{
				// Slow Player as it approaches the destination, but no slower than 1.0f force.
				yield return MoveLeft  (1, force * Mathf.Max( Mathf.Abs( (x - pancake.transform.position.x) / x ) , 1.0f) );
				yield return this.Wait (0.05f);
			}
			// Wait for momentum to carry before checking position again.
			yield return this.Wait (0.5f);
		}
	}

	public IEnumerator MoveLeft(int steps=1, float force = 10.0f)
	/* Moves Player Left */
	{
		//Debug.Log("Moving Left");
		for (int i = 0; i < steps; i++) 
		{
			yield return this.Move (- force, 0.0f);
			yield return this.Wait (0.05f);
		}
	}

	public IEnumerator MoveLeftTillX(float x, float force = 10.0f, double timeout = 10.0)
	/* Moves Player Left until it reaches the given x value */
	{
		//Debug.Log("Moving Left");
		double end_time = Time.realtimeSinceStartup + timeout; // 1.0 = 1 second
		// run till x is reached, or timeout is reached
		while (pancake.transform.position.x < x) 
		{
			if (end_time < Time.realtimeSinceStartup)
			{
				Debug.Log ("Move Left Timeout");
				break;
			}
			yield return this.Move (- force, 0.0f);
			yield return this.Wait (0.05f);
		}
	}

	public IEnumerator MoveRight(int steps=1, float force = 10.0f)
	/* Moves Player Right */
	{
		//Debug.Log("Moving Right");
		for (int i = 0; i < steps; i++) 
		{
			yield return this.Move (force, 0.0f);
			yield return this.Wait (0.05f);
		}
	}

	public IEnumerator MoveRightTillX(float x, float force = 10.0f, double timeout = 10.0)
	/* Moves Player Right until it reaches the given x value */
	{
		//Debug.Log("Moving Right");
		double end_time = Time.realtimeSinceStartup + timeout; // 1.0 = 1 second
		// run till x is reached, or timeout is reached
		while (pancake.transform.position.x < x) 
		{
			if (end_time < Time.realtimeSinceStartup)
			{
				Debug.Log ("Move Right Timeout");
				break;
			}
			yield return this.Move (force, 0.0f);
			yield return this.Wait (0.05f);
		}
	}

	public IEnumerator Jump()
	/* Makes Player Jump */
	{
		//Debug.Log ("Jumping");
		this.pancake.Jump();
		yield return true;
	}



	/* 
	 * private Functions 
	 */

	private IEnumerator Move(float forceX=1.0f, float forceY=0.0f)
	{
		this.pancake.Movement(forceX, forceY);
		yield return true;
	}
}
