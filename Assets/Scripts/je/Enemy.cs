using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{

	private int moneyRewardDefeatAmount;
	private bool shouldRespawn;
	private bool isVisibleOnScreen;
	//	private InventoryItem[] inventoryItemDrop;
	//	private PowerUp[] powerUpItemDrop;
	private int damageAmount;

	public Enemy ()
	{
		velocity = 2;
	}

	protected override void OnCollision ()
	{

	}

	public void Move ()
	{
		Vector2 position = transform.position;
		float translation = Time.deltaTime * velocity;
		position.x += translation;
		transform.position = position;
	}

	// Use this for initialization
	void Start ()
	{
		
	}

	public void CollideWithObject (object[] temp)
	{
		string type = (string)temp [0];
		float speed = (float)temp [1];
		velocity *= speed * 3;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move ();
	}

	private bool IsEnemyVisibleOnScreen ()
	{
		return true;
	}

	public void Attack ()
	{

	}

	public void Reward ()
	{ 

	}
}
