using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    public int velocity = 5;

    public abstract void DealDamage(BattleHex targetPos);
}
