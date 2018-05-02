﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bronze : CoinItemDecorator {
    public override void Awake() { }
    public override void Start()
    {
        base.Start();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MainPlayer") {

            profileManager.gameObject.SendMessage("AddToScore", coinScoreValues[CoinTypes.Bronze]);
            uiController.gameObject.SendMessage("AddToScore", coinScoreValues[CoinTypes.Bronze]);
            aSource.PlayFx(AudioManagement.SoundType.COIN);
            Destroy(gameObject);

        }
    }
}
