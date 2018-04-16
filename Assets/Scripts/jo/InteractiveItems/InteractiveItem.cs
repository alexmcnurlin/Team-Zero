using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveItem:MonoBehaviour {

    protected ProfileManager profileManager;
    protected GameObject uIController;
    private GameObject profileManagerGameObject;
    

    public bool debug = false;

    public virtual void Start()
    {
        uIController = GameObject.FindGameObjectWithTag("UIManager");
        profileManager = GameObject.FindGameObjectWithTag("ProfileManager").GetComponent<ProfileManager>();
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {

    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {

    }

}
