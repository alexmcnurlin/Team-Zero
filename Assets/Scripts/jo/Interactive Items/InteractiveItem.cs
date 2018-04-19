using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveItem:MonoBehaviour {

    protected ProfileManager profileManager;
    protected static AudioManagement aSource;

    public bool debug = false;

    public virtual void Start()
    {
        profileManager = GameObject.FindGameObjectWithTag("ProfileManager").GetComponent<ProfileManager>();
        aSource = GameObject.Find("AudioManagement").GetComponent<AudioManagement>();
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {

    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {

    }

}
