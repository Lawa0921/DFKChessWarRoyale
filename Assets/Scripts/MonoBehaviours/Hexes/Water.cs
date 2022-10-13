using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : BattleHex
{
    public override bool AvailableForGround()
    {
        return false;
    }
}
