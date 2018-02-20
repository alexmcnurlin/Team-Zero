using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

	public enum Direction {
		LEFT,
		RIGHT,
		UP,
		DOWN
	}

	protected abstract void OnCollision ();

	// private list inventory;

	private int MAX_HEALTH;
	private int MAX_SPEED;

	private int money;
	private int health;
	private int velocity;
	private int speed;
	private Direction direction;

	public void Move() {

	}

	public bool IsDead() {
		return (health <= 0);
	}

	public int GetHealth() {
		return health;
	}

	public int GetSpeed() {
		return speed;
	}

	public Direction GetDirection() {
		return direction;
	}

	public void UpdateHealth (int newHealth) {
		health = newHealth;
	}

	public void UpdateSpeed (int newHealth) {
		health = newHealth;
	}

	public void ChangeDirection (Direction newDirection) {
		direction = newDirection;
	}
}