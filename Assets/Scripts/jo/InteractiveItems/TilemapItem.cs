using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapItem : InteractiveItem {

    public TileMapTypes tileMapType;

    public enum TileMapTypes {
        None,
        DefaultSpeed,
        Slowing,
        Accelerating,
        Damaging,
        Killing,
        EndOfLevel
    }

    public override void Start()
    {
        base.Start();
    }

    public override void OnCollisionEnter2D(Collision2D other)
    {

        object[] tempStorage = new object[4];

        if(tileMapType != TileMapTypes.None && (other.gameObject.tag == "MainPlayer" ||
            other.gameObject.tag == "Enemy" ||
            other.gameObject.tag == "NPC")) {

            switch(tileMapType) {
                case TileMapTypes.DefaultSpeed:
                    tempStorage[0] = "NormalSpeed";
                    tempStorage[1] = 1f;
                    other.gameObject.SendMessage("CollideWithObject", tempStorage);
                    break;

                case TileMapTypes.Slowing:
                    tempStorage[1] = 0.6f;
                    other.gameObject.SendMessage("CollideWithObject", tempStorage);
                    break;

                case TileMapTypes.Accelerating:
                    tempStorage[0] = "Accelerating";
                    tempStorage[1] = 1.5f;
                    other.gameObject.SendMessage("CollideWithObject", tempStorage);
                    break;

                case TileMapTypes.Damaging:
                    tempStorage[0] = "Damaging";
                    tempStorage[1] = 1f; //should be a variable up there
                    other.gameObject.SendMessage("CollideWithObject", tempStorage);
                    break;

                case TileMapTypes.Killing:
                    other.gameObject.SendMessage("CollideWithObject", "Killing");
                    break;

                default:
                    break;
            }

        }



    }


}
