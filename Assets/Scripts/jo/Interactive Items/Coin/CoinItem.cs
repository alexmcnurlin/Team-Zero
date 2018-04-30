using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoinItem : InteractiveItem {
    public enum CoinTypes {
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

    public virtual void OnTriggerEnter2D(Collider2D other){}

}
