using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticAndDynamicDummy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Gold i =  gameObject.AddComponent<Gold>();
        Gold j = gameObject.AddComponent<InteractiveItem>() as Gold;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
