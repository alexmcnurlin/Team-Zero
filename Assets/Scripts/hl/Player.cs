// Author: Hayden Lepla
// Player.cs

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    private Rigidbody2D rb2d;
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
    public int timeLength = 3;
    public Image damageImage;
    public float flashSpeed = 2f;
    public Color flashColor = new Color(1f, 0f, 0f, 1f);
    private DateTime time;


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //aSource = GameObject.Find("AudioManagement").GetComponent<AudioManagement>();
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
        if (Input.GetKeyDown("space") && (midJump == false))
        {
            Jump();
            midJump = true;
        }

        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            midJump = false;
        }

        if(hasPowerup)
        {
            if (playerPowerup.IsExpired())
            {
                Debug.Log("Powerup has expired");
                hasPowerup = false;

                if (playerPowerup.type == Modifier.INVINCIBLE)
                {
                    isInvincible = false;
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


        TimeSpan notime = new TimeSpan(0);
        if(isRecovering)
        {
            if (TimeLeft().CompareTo(notime) < 0)
            {
                isRecovering = false;
            }
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
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
            // Implement damage to enmeies and player later
            hasPowerup = true;
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
         int length = 3;

        if(isRecovering)
        Debug.Log("Is recovering" + TimeLeft());

        if(!isInvincible && !isRecovering)
        {
            Debug.Log("Applying damage");
            UpdateHealth(health - damage);
            damageImage.color = flashColor;
            isRecovering = true;
            time = DateTime.Now;
            time = time.AddSeconds(length);
        }
    }

    public TimeSpan TimeLeft()
    {
        DateTime now = DateTime.Now;
        return time.Subtract(now);
    }

    void CollideWithObject(string kill)
    {
        // use at Jorge's stuff to remove player (ie death)
    }

    void OnTriggerEnter(Collider other)
    {

    }

    void SendPlayerScore()
    {

    }

    override protected void OnCollision()
    {

    }

}
