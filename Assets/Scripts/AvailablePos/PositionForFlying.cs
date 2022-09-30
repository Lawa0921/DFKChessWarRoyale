using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionForFlying : MonoBehaviour, IAdjacentFinder
{
    IEvaluateHex checkHex = new IfItIsNewHex();

    public void GetAdjacentHexesExtended(BattleHex initialHex)
    {
        List<BattleHex> neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex, checkHex);
        foreach (BattleHex hex in neighboursToCheck)
        {
            hex.isNeighboringHex = true;
            hex.distanceText.SetDistanceFromStartingHex(initialHex);
            hex.SetAvailable();
        }
    }
}
