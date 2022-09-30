using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionForGround : MonoBehaviour, IAdjacentFinder
{
    IEvaluateHex checkHex = new IfItIsNewGround();

    public void GetAdjacentHexesExtended(BattleHex initialHex)
    {
        List<BattleHex> neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex, checkHex);
        foreach (BattleHex hex in neighboursToCheck)
        {
            if (hex.distanceText.EvaluateDistanceForGround(initialHex))
            {
                hex.isNeighboringHex = true;
                hex.distanceText.SetDistanceForGroundUnit(initialHex);
                hex.SetAvailable();
            }
        }
    }
}
