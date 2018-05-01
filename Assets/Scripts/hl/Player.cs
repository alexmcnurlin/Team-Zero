// Author: Hayden Lepla
// Player.cs

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IDeadPlayer
{

    void KillPlayer();
}

abstract class PlayerAlive : IDeadPlayer
{
    public static readonly IDeadPlayer NULL = new NULLPlayerAlive();

    private class NULLPlayerAlive : PlayerAlive
    {
        public override void KillPlayer()
        {
            // Purposfully provides no behavior
        }
    }

    public abstract void KillPlayer();
}

    public class Player : Character , IDeadPlayer 
    {
        private Rigidbody2D rb2d;
        private DateTime sec;
        public int counter;
        public Vector2 localSpeed = new Vector2(10, 0);
        public Vector2 charAction;
        public bool midJump = false;
        private Powerup playerPowerup;
        private Powerup playerCoolDown;
        public bool isInvincible = false;
        public bool isDoubleJump = false;
        public bool isFast = false;
        public bool hasPowerup = false;
        public bool isRecovering = false;
        public float timeLeft;
        public AudioManagement aSource;
        public int damage;
        private int flickerLength = 1;  //  Must be shorter than "timeLength" 
                                        //  When changed to float - Instead of AddSeconds
                                        //  Add MiliSeconds( flickerLength * 1000)
        public int timeLength = 3;      //  Total Length of time it takes to "recover" from injury
        public Image damageImage;
       
        //public GameObject gameObject;
        public float flashSpeed = 2f;
        public Color flashColor = new Color(1f, 0f, 0f, 1f);
        private DateTime time;


        // Use this for initialization
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            health = MAX_HEALTH;
        }

        public void Movement(float moveHorizontal, float moveVertical)
        {
            //Use the two store floats to create a new Vector2 variable movement.
            Vector2 movement = new Vector2(localSpeed.x * moveHorizontal, localSpeed.y * moveVertical);

            //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            rb2d.AddForce(movement);
        }

        public void Jump()
        {
            // Apply 7 units of force in the y direction
            rb2d.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
            aSource.PlayFx(AudioManagement.SoundType.JUMP);
        }

    // Update is called once per frame
    void Update()
    {

        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        Movement(moveHorizontal, moveVertical);

        // Prevent double jumping
        if(Input.GetKeyDown("space") && (midJump == false)) {
            Jump();
            midJump = true;
        }

        if(GetComponent<Rigidbody2D>().velocity.y == 0) {
            midJump = false;
        }

        if(hasPowerup) {
            if(playerPowerup.IsExpired()) {
                Debug.Log("Powerup has expired");
                hasPowerup = false;

                if(playerPowerup.type == Modifier.INVINCIBLE) {
                    isInvincible = false;
                } else if(playerPowerup.type == Modifier.JUMPHEIGHT) {
                    isDoubleJump = false;
                } else if(playerPowerup.type == Modifier.SPEED) {
                    isFast = false;
                }
            }
        }

        // start recovery counter
        TimeSpan notime = new TimeSpan(0);
        DateTime now = DateTime.Now;

        if(isRecovering) {

            if(sec.Subtract(now).CompareTo(notime) <= 0) {

                if(gameObject.GetComponent<SpriteRenderer>().enabled) {
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    sec = DateTime.Now.AddSeconds(flickerLength);
                } else {
                    gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    sec = DateTime.Now.AddSeconds(flickerLength);
                }
            }

            if(time.Subtract(now).CompareTo(notime) <= 0) {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                isRecovering = false;
            }


            //gameObject.GetComponent<SpriteRenderer>().enabled = true;

            //damageImage.GetComponent<SpriteRenderer>().color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            //damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            // }
        }
    }
        public void ApplyPowerup(Powerup powerup)
        {
            playerPowerup = powerup;
            Debug.Log("Accepted" + powerup.type + ".");
            powerup.ActivatePowerup();

            ResetPowerup();
            if (playerPowerup.type == Modifier.INVINCIBLE)
            {
                isInvincible = true;
                Debug.Log("now invincible");
                hasPowerup = true;
            }

            else if (playerPowerup.type == Modifier.JUMPHEIGHT)
            {
                isDoubleJump = true;
                Jump();
            }

            else if (playerPowerup.type == Modifier.SPEED)
            {
                isFast = true;
                // Temp double player speed
                Movement(20, 0);
                hasPowerup = true;
            }
            Debug.Log("powerup deactivated");

        }

        public void ResetPowerup()
        {
            isInvincible = false;
            isDoubleJump = false;
            isFast = false;
        }

        public void ApplyDamage(int damage)
        {
            // Player gets 3 seconds of recovery
            int length = 3;

            if (isRecovering)
                Debug.Log("Is recovering" + TimeLeft());

            if (!isInvincible && !isRecovering)
            {
                Debug.Log("Applying damage");
                UpdateHealth(health - damage);
            //Jorge
            //gameObject.SetActive(false);
            //damageImage.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("Color is being changed to flashColor");
                //damageImage.color = flashColor;
                isRecovering = true;
                sec = DateTime.Now.AddSeconds(flickerLength);
                Debug.Log("Timer: " + sec.Subtract(DateTime.Now).ToString());
                time = DateTime.Now.AddSeconds(length);
            }
        }

    public void KillPlayer()
    {
        if(!isInvincible && health == 0)
        {
            // remove player
            Debug.Log("Player is dead!");
        }
    }

        public TimeSpan TimeLeft()
        {
            DateTime now = DateTime.Now;
            return time.Subtract(now);
        }

        void OnTriggerEnter(Collider other)
        {

        }

        override protected void OnCollision()
        {

        }

    void CollideWithObject(TilemapItem.TileMapTypes type)
    {
        //  Look at TilemapItem.cs for help
        switch(type) {
            case TilemapItem.TileMapTypes.DefaultSpeed:
                break;

            case TilemapItem.TileMapTypes.Slowing:
                break;

            case TilemapItem.TileMapTypes.Accelerating:
                break;

            case TilemapItem.TileMapTypes.Damaging:
                break;

            case TilemapItem.TileMapTypes.Killing:
                break;

            default:
                break;
        }
    }
}
