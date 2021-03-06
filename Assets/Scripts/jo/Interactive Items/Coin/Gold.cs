﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : CoinItemDecorator {
    public override void Awake() { }
    public override void Start()
    {
        base.Start();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MainPlayer") {

            profileManager.gameObject.SendMessage("AddToScore", coinScoreValues[CoinTypes.Gold]);
            uiController.gameObject.SendMessage("AddToScore", coinScoreValues[CoinTypes.Gold]);
            aSource.PlayFx(AudioManagement.SoundType.COIN);
            Destroy(gameObject);

        }
    }
}
