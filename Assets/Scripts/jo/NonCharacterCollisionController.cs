using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonCharacterCollisionController:MonoBehaviour {

    public enum TileTypes 
     {
        None,
        DefaultSpeed,
        Slowing,
        Accelerating,
        Damaging,
        Killing,
        EndOfLevel
    }

    public enum ItemTypes 
    {
        None,
        Token,
        Powerup
    }

    public TileTypes tileType;
    public ItemTypes itemType;
    public int damageGiving = 0;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        object[] tempStorage = new object[4];

		if(tileType != TileTypes.None && (other.gameObject.tag == "MainPlayer" || 
			other.gameObject.tag == "Enemy" || 
			other.gameObject.tag == "NPC")) {

            switch(tileType) {
                case TileTypes.DefaultSpeed:
                    tempStorage[0] = "NormalSpeed";
                    tempStorage[1] = 1f;
                    other.gameObject.SendMessage("CollideWithObject", tempStorage);
                    break;

                case TileTypes.Slowing:
                    tempStorage[0] = "Slowing";
                    tempStorage[1] = 0.6f;
                    other.gameObject.SendMessage("CollideWithObject", tempStorage);
                    break;

                case TileTypes.Accelerating:
                    tempStorage[0] = "Accelerating";
                    tempStorage[1] = 1.5f;
                    other.gameObject.SendMessage("CollideWithObject", tempStorage);
                    break;

                case TileTypes.Damaging:
                    tempStorage[0] = "Damaging";
                    tempStorage[1] = 1; //should be a variable up there
                    other.gameObject.SendMessage("CollideWithObject", tempStorage);
                    break;

                case TileTypes.Killing:
                    other.gameObject.SendMessage("CollideWithObject", "Killing");
                    break;

                default:
                    break;
            }

        }

    }
}
