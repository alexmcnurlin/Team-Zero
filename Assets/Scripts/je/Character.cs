using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {
	
	public abstract void move ();

	protected abstract void onCollision ();

	// private list inventory;

	private int money;
	private double health;
	private double speed;
	// TODO: enum LEFT, RIGHT, UP, DOWN
	private int direction;

	Character (double velocity) {

	}

//	public abstract void move() {
		// component.getposition + 1
		// TODO: use delta time
//	}

//	protected abstract void onCollision() {
		// 
//	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// get all items in hitbox of self, typecast to strictly character
		// if true, collision occurred, deal w it
	}
}
