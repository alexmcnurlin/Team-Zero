using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
	// used for logic related to movement in the Player/Enemy classes
	public enum Direction
	{
		LEFT,
		RIGHT,
		UP,
		DOWN
	}

	// protected for subclasses to have custom handlers for object collisions
	protected abstract void OnCollision ();

	// private list inventory;

	// subclasses may have differing max health/speed, allow them to customize it
	protected int MAX_HEALTH;
	protected int MAX_SPEED;

	// subclasses need to access these members
	protected int money;
	protected int health;
	protected float velocity;
	protected float speed;
	protected Direction direction;

	public void Move ()
	{

	}

	public bool IsDead ()
	{
		return (health <= 0);
	}

	public int GetHealth ()
	{
		return health;
	}

	public float GetSpeed ()
	{
		return speed;
	}

	public Direction GetDirection ()
	{
		return direction;
	}

	public void UpdateHealth (int newHealth)
	{
		health = newHealth;
	}

	public void UpdateSpeed (int newHealth)
	{
		health = newHealth;
	}

	public void ChangeDirection (Direction newDirection)
	{
		direction = newDirection;
	}
}