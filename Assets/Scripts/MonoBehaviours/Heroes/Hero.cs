using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    public int velocity = 7;
    public CharAttributes heroData;

    public abstract void DealDamage(BattleHex targetPos);

    private void Start()
    {
        StorageMNG.OnClickOnGrayIcon += DestroyMe;
    }

    private void DestroyMe(CharAttributes SOHero)
    {
        if (SOHero == heroData)
        {
            BattleHex parentHex = GetComponentInParent<BattleHex>();
            parentHex.MakeDeploymentPosition();
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        StorageMNG.OnClickOnGrayIcon -= DestroyMe;
    }
}
