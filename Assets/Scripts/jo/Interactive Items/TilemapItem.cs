using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapItem : InteractiveItem {

    public TileMapTypes tileMapType;

    public enum TileMapTypes {
        None,                   //  None Applied    -   set speed to default
        DefaultSpeed,           //  Default Speed   -   set speed to default
        Slowing,                //  Slow Down Character as he Walks -   set speed to some <100 percentage of default speed
        Accelerating,           //  Speed up character when on this type of floor   -   set speed to some >100 percentage of default speed
        Damaging,               //  Damage Character    -   Do some amount of damage
        Killing                 //  Damage Character    -   Deal 100% of health as damage
    }

    public override void Start()
    {
        base.Start();
        profileManager = GameObject.FindGameObjectWithTag("ProfileManager").GetComponent<ProfileManager>();
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {
           

        if(tileMapType != TileMapTypes.None && (other.gameObject.tag == "MainPlayer" ||
            other.gameObject.tag == "Enemy" ||
            other.gameObject.tag == "NPC")) {
            //  Affects Object with Tags "MainPlayer", "Enemy", "NPC"
            //  This makes that Object run method: "CollideWithObject" - Like Delegate
            //  Argument is the TileMapType - Look at Player.cs for example on how to use
            //  gameObject is a component of whichever object collided with this floor
            //  So gameObject acts as a delegate

            switch(tileMapType) {   //  look at the enum above to see what each argument should cause to happen
                                    //  Implementation left to whoever makes objects with "MainPlayer", "Enemy", "NPC" tags
                case TileMapTypes.DefaultSpeed:
                    other.gameObject.SendMessage("CollideWithObject", TileMapTypes.DefaultSpeed);
                    break;

                case TileMapTypes.Slowing:
                    other.gameObject.SendMessage("CollideWithObject", TileMapTypes.Slowing);
                    break;

                case TileMapTypes.Accelerating:
                    other.gameObject.SendMessage("CollideWithObject", TileMapTypes.Accelerating);
                    break;

                case TileMapTypes.Damaging:
                    other.gameObject.SendMessage("CollideWithObject", TileMapTypes.Damaging);
                    break;

                case TileMapTypes.Killing:
                    other.gameObject.SendMessage("CollideWithObject", TileMapTypes.Killing);
                    break;

                default:
                    break;
            }

        }



    }


}
