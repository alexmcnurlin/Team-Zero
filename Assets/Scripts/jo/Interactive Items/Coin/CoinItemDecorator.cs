using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItemDecorator : CoinItem {
    public CoinTypes coinType;

    public virtual void Awake() {
        switch(coinType) {
            case CoinTypes.Gold:
                gameObject.AddComponent<Gold>();
                break;
            case CoinTypes.Silver:
                gameObject.AddComponent<Silver>();
                break;
            case CoinTypes.Bronze:
                gameObject.AddComponent<Bronze>();
                break;
        }
    }

    public override void Start()
    {
        base.Start();

    }
   
    public virtual void OnTriggerEnter2D(Collider2D other) { }

}
