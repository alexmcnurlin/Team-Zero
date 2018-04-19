using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : InteractiveItem {
    public CoinTypes coinType;

    public enum CoinTypes {
        None,
        Gold,
        Silver,
        Bronze
    }

    public Dictionary<CoinTypes, int> coinScoreValues = new Dictionary<CoinTypes, int>
    {
        {CoinTypes.Gold, 10},
        {CoinTypes.Silver, 5},
        {CoinTypes.Bronze, 1}
    };

    public override void Start()
    {
        base.Start();

    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "MainPlayer") {

            profileManager.gameObject.SendMessage("AddToScore", coinScoreValues[coinType]);
            uiController.gameObject.SendMessage("AddToScore", coinScoreValues[coinType]);
            aSource.PlayFx(AudioManagement.SoundType.COIN);
            Destroy(gameObject);

        }
    }
}
