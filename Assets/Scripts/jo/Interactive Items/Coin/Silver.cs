using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silver : CoinItemDecorator {

    public override void Awake() { }

    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MainPlayer") {

            profileManager.gameObject.SendMessage("AddToScore", coinScoreValues[CoinTypes.Silver]);
            uiController.gameObject.SendMessage("AddToScore", coinScoreValues[CoinTypes.Silver]);
            aSource.PlayFx(AudioManagement.SoundType.COIN);
            Destroy(gameObject);

        }
    }
}
