using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    public int velocity = 7;
    public CharAttributes heroData;

    public abstract void DealDamage(BattleHex targetPos);
}
