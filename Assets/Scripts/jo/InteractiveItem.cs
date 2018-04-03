using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveItem:MonoBehaviour {

    protected ProfileManager profileManager;
    private GameObject profileManagerGameObject;

    public bool debug = false;

    public virtual void Start()
    {
        profileManagerGameObject = GameObject.FindGameObjectWithTag("ProfileManager");
        profileManager = profileManagerGameObject.GetComponent<ProfileManager>();
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {

    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {

    }

}
