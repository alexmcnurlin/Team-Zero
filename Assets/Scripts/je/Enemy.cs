using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
	// can be set via Unity editor; used to determine what is considered "ground" collision for the enemy
	[SerializeField] string floorGameObjectTag;
	// amount of money to be given to player on defeat
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

	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag != floorGameObjectTag) {
			if (collision.gameObject.tag == "MainPlayer") {
				GameObject playerGameObject = GameObject.FindWithTag ("MainPlayer");
				Player player = null;
				if (playerGameObject != null) {
					player = playerGameObject.GetComponent<Player> ();
				}

				const float THRESHOLD_DISTANCE = 0.05f;
				const int HEIGHT = 2;

				if (Mathf.Abs (playerGameObject.transform.position.y) <= (Mathf.Abs (transform.position.y) - HEIGHT + THRESHOLD_DISTANCE)) {
					// player jumped on enemy head, kill the enemy
					UpdateHealth (0);
					Destroy (gameObject);
				} else {
					// player touched enemy, hurt the player by 25% of their max health				
					if (!player.isInvincible) {
						player.ApplyDamage (MAX_HEALTH / 4);
					}
				}


			}
			velocity *= -1;
		}
	}

	public void CollideWithObject (object[] temp)
	{
//		string type = (string)temp [0];
//		Debug.Log (type);
//		float speed = (float)temp [1];
//		velocity = speed * 3 * ((speed > 0) ? 1 : -1);
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
