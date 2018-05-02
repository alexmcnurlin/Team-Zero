using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveItem : MonoBehaviour {

    protected ProfileManager profileManager;
    protected static AudioManagement aSource;
    protected UIController uiController;

    public virtual void Start()
    {
        uiController = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIController>();
        profileManager = GameObject.FindGameObjectWithTag("ProfileManager").GetComponent<ProfileManager>();
        aSource = GameObject.Find("AudioManagement").GetComponent<AudioManagement>();
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("I'm an Interactive Object!");
    }

    public virtual void OnCollisionEnter2D(Collision2D other)
    {

    }

}
