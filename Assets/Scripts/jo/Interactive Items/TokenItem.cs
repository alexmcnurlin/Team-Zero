using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenItem : InteractiveItem {
    public int tokenID;


    public override void Start()
    {
        base.Start();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MainPlayer") {
            profileManager.gameObject.SendMessage("CollectedToken", tokenID);
            aSource.PlayFx(AudioManagement.SoundType.TOKEN);
            Destroy(gameObject);
        }

    }
}
