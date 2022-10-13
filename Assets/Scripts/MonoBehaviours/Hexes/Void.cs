using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : BattleHex
{
    public override void SetAvailable()
    {
        currentState.color = new Color32(255, 255, 255, 0);
    }

    public override void MakeTargetToMove()
    {
        clickOnHex.ClearPreviousSelectionOfTargetHex();
    }

    public override bool AvailableForGround()
    {
        return false;
    }

    public override bool AvailableForFlying()
    {
        return false;
    }
}
