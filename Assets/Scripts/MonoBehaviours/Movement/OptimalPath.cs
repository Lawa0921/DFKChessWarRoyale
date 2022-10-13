using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptimalPath : MonoBehaviour
{
    public static BattleHex nextStep;
    public static List<BattleHex> optimailPath = new List<BattleHex>();
    public List<Image> landscapes = new List<Image>();
    BattleHex targetHex;
    IAdjacentFinder AdjacentOption = new PosForPath();
    Move move;

    private void Start()
    {
        move = GetComponent<Move>();
    }

    internal void MatchPath()
    {
        optimailPath.Clear();
        targetHex = BattleController.targetToMove;
        optimailPath.Add(targetHex);

        int steps = targetHex.distanceText.distanceFromStartingPoint;

        for (int i = steps; i > 1;)
        {
            AdjacentOption.GetAdjacentHexesExtended(targetHex);
            targetHex = nextStep;
            i -= nextStep.distanceText.MakeSelfPartOfOptimalPath();
        }
        ManagerPath();
    }

    void ManagerPath()
    {
        landscapes.Clear();
        optimailPath.Reverse();
        foreach (BattleHex hex in optimailPath)
        {
            landscapes.Add(hex.LandSpace);
        }
        move.path = landscapes;
    }
}
