using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosForPath : MonoBehaviour, IAdjacentFinder
{
    IEvaluateHex checkHex = new IfItIsOptimalPath();

    public void GetAdjacentHexesExtended(BattleHex initialHex)
    {
        List<BattleHex> neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex, checkHex);
        foreach (BattleHex hex in neighboursToCheck)
        {
            if (hex.distanceText.EvaluateDistance(initialHex))
            {
                OptimalPath.nextStep = hex;
                break;
            }
        }
    }
}
