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

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

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

    }

    public void ApplyPowerup(Powerup powerup)
    {
        Debug.Log("Accepted" + powerup.type + ".");
        powerup.ActivatePowerup();

        /* ToDo, differentiate various powerups

        if (playerPowerup.type == Modifier.INVINCIBLE)
        {
            // make invincible
        }

        else if(playerPowerup.type == Modifier.JUMPHEIGHT)
        {}

        else if(playerPowerup.type == Modifier.SPEED)
        {}
        */
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
