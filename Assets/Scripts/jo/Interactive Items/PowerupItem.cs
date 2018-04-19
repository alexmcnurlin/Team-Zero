using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupItem : InteractiveItem {

    private Powerup powerup;

    public override void Start()
    {
        base.Start();
        powerup = this.GetComponent<Powerup>();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MainPlayer") {
            other.gameObject.SendMessage("ApplyPowerup", powerup);
            Destroy(gameObject);
        }
    }

}
