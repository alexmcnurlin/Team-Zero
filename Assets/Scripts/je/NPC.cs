using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

	private string[] dialogue;
	private float velocity = 1;

	// Use this for initialization
	void Start ()
	{
		
	}

	public void Move ()
	{
		Vector2 position = transform.position;
		float translation = Time.deltaTime * velocity;
		position.x += translation;
		transform.position = position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move ();
	}

	void Chat ()
	{

	}

	public void CollideWithObject (object[] temp)
	{
		string type = (string)temp [0];
		float speed = (float)temp [1];
		velocity *= speed * 2;
	}

	void AssignQuest (/*Quest quest*/)
	{

	}
}
