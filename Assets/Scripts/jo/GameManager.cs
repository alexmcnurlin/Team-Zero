using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    private Rigidbody2D mainPlayer;
    private Vector2 originalPosition;

	void Start () {
        mainPlayer = GameObject.FindGameObjectWithTag("MainPlayer").GetComponent<Rigidbody2D>();
        originalPosition = mainPlayer.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Respawn()
    {
        mainPlayer.MovePosition(originalPosition);
    }

}
