using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionForFlying : MonoBehaviour
{
    public void GetAdjacentHexesExtended(BattleHex initialHex)
    {
        List<BattleHex> neighboursToCheck = NeighboursFinder.GetAdjacentHexes(initialHex);
        foreach (BattleHex hex in neighboursToCheck)
        {
            hex.isNeighboringHex = true;
        }
    }
}
