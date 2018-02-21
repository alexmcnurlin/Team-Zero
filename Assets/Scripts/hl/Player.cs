using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

	private Rigidbody2D rb2d;
	public int counter;
	public Vector2 local_speed = new Vector2 (10, 10);

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}

	private void FixedUpdate ()
	{
		//Store the current horizontal input in the float moveHorizontal.
		float moveHorizontal = Input.GetAxis ("Horizontal");

		//Store the current vertical input in the float moveVertical.
		float moveVertical = Input.GetAxis ("Vertical");

		//Use the two store floats to create a new Vector2 variable movement.
		Vector2 movement = new Vector2 (local_speed.x * moveHorizontal, local_speed.y * moveVertical);
       
		if (Input.GetKeyDown ("space")) {
			rb2d.AddForce (new Vector2 (0, 20), ForceMode2D.Impulse);
		}

		//Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
		rb2d.AddForce (movement);
       

	}

	// Update is called once per frame
	void Update ()
	{

	}

	void ApplyPowerup ()
	{

	}

	void CollideWithObject (object tmp)
	{
		// look at Jorge's stuff
	}

	void CollideWithObject (string kill)
	{
		// look at Jorge's stuff
	}

	void CollideWithResettingObject ()
	{

	}

	void CollideWithObjectSound ()
	{

	}

	void OnTriggerEnter (Collider other)
	{

	}

	void SetScoreText ()
	{

	}

	void SendPlayerScore ()
	{

	}

	void InteractsWithUI ()
	{

	}

	override protected void OnCollision ()
	{

	}

}
