using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailablePos : MonoBehaviour
{
    private int step;
    List<BattleHex> initialHexes = new List<BattleHex>();

    public void GetAvailablePositions(BattleHex startingHex, int stepsLimit, IAdjacentFinder AdjFinder)
    {
        AdjFinder.GetAdjacentHexesExtended(startingHex);

        for (step = 2; step <= stepsLimit; step++)
        {
            initialHexes = GetNewInitialHexes();
            foreach (BattleHex hex in initialHexes)
            {
                AdjFinder.GetAdjacentHexesExtended(hex);
                hex.isIncluded = true;
            }
        }
    }

    internal List<BattleHex> GetNewInitialHexes()
    {
        initialHexes.Clear();
        foreach (BattleHex hex in FieldManager.allHexesArray)
        {
            if (hex.isNeighboringHex && !hex.isIncluded)
            {
                initialHexes.Add(hex);
            }
        }

        return initialHexes;
    }
}
