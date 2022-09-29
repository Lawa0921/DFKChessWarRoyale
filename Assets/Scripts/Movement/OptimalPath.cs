using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimalPath : MonoBehaviour
{
    public static BattleHex nextStep;
    public static List<BattleHex> optimailPath = new List<BattleHex>();
    BattleHex targetHex;
    IAdjacentFinder AdjacentOption = new PosForPath();

    internal void MatchPath()
    {
        targetHex = BattleController.targetToMove;
        optimailPath.Add(targetHex);

        int steps = targetHex.distanceText.distanceFromStartingPoint;

        for (int i = steps; i > 1;)
        {
            AdjacentOption.GetAdjacentHexesExtended(targetHex);
            targetHex = nextStep;
            i -= nextStep.distanceText.MakeSelfPartOfOptimalPath();
        }
    }
}
