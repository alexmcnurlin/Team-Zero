// Author: Hayden Lepla
// Player.cs

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private Rigidbody2D rb2d;
    public int counter;
    public Vector2 localSpeed = new Vector2(10, 0);
    public Vector2 charAction;
    public string midJump = "no";
    private Powerup playerPowerup;
    public const float maxHealth = 100;
    public float health;
    public static bool isInvicible = false;
    public static bool isDoubleJump = false;
    public static bool isFast = false;
    public bool hasPowerup = false;
    public float timeLeft;
    public AudioManagement aSource;
    
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        aSource = GameObject.Find("AudioManagement").GetComponent<AudioManagement>();
        health = maxHealth;
    }
    // Not used for now
    private void FixedUpdate()
    {

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

        // Call Movement every iteration of FixedUpdate
        Movement(moveHorizontal, moveVertical);

        // Prevent double jumping
        if (Input.GetKeyDown("space") && (midJump == "no"))
        {
            Jump();
            midJump = "yes";
        }

        if (GetComponent<Rigidbody2D>().velocity.y == 0)
            midJump = "no";

        TimeSpan notime = new TimeSpan(0);
        if(hasPowerup) 
        {
            if (playerPowerup.TimeLeft().CompareTo(notime) < 0)
            {
                Debug.Log("Powerup has expired");
                hasPowerup = false;

                if (playerPowerup.type == Modifier.INVINCIBLE)
                {
                    isInvicible = false;
                }

                else if(playerPowerup.type == Modifier.JUMPHEIGHT)
                {
                    isDoubleJump = false;

                }
                else if(playerPowerup.type == Modifier.SPEED)
                {
                    isFast = false;
                }
            }
        }
    }

    public void ApplyPowerup(Powerup powerup)
    {
        playerPowerup = powerup;
        Debug.Log("Accepted" + powerup.type + ".");
        powerup.ActivatePowerup();

        if (playerPowerup.type == Modifier.INVINCIBLE)
        {
            isInvicible = true;
            // Implement damage to enmeies and player later
        }

        else if(playerPowerup.type == Modifier.JUMPHEIGHT)
        {
            isDoubleJump = true;
            Jump(); 
        }

        else if(playerPowerup.type == Modifier.SPEED)
        {
            isFast = true;
            // Temp double player speed
            Movement(20, 0);
        }
        
    }    

    public void ApplyDamage(float damage)
    {
        if(!isInvicible)
        {
            health -= damage;
        }
    }

    void CollideWithObject(object tmp)
    {
        // look at Jorge's stuff
    }

    void CollideWithObject(string kill)
    {
        // look at Jorge's stuff
    }

    void CollideWithResettingObject()
    {

    }

    void CollideWithObjectSound()
    {

    }

    void OnTriggerEnter(Collider other)
    {

    }

    void SetScoreText()
    {

    }

    void SendPlayerScore()
    {

    }

    void InteractsWithUI()
    {

    }

    override protected void OnCollision()
    {

    }

}
