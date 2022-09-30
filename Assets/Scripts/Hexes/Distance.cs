using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public int distanceFromStartingPoint;
    public int stepsToGo;
    BattleHex hex;
    Text distanceText;

    void Start()
    {
        hex = GetComponentInParent<BattleHex>();
        distanceText = GetComponent<Text>();
    }

    public void SetDistanceForGroundUnit(BattleHex initialHex)
    {
        distanceFromStartingPoint = initialHex.distanceText.distanceFromStartingPoint + initialHex.distanceText.stepsToGo;
        DispalyDistanceText();
    }

    public void SetDistanceForFlyingUnit(BattleHex initialHex)
    {
        distanceFromStartingPoint = initialHex.distanceText.distanceFromStartingPoint + 1;
        DispalyDistanceText();
    }

    void DispalyDistanceText()
    {
        distanceText.text = distanceFromStartingPoint.ToString();
        distanceText.color = new Color32(255, 255, 255, 255);
    }

    public bool EvaluateDistance(BattleHex initialHex)
    {
        return distanceFromStartingPoint + stepsToGo == initialHex.distanceText.distanceFromStartingPoint;
    }

    public int MakeSelfPartOfOptimalPath()
    {
        OptimalPath.optimailPath.Add(hex);
        hex.LandSpace.color = new Color32(150, 150, 150, 255);
        return stepsToGo;
    }

    public bool EvaluateDistanceForGround(BattleHex initialHex)
    {
        int currentDistance = initialHex.distanceText.distanceFromStartingPoint + initialHex.distanceText.stepsToGo;
        int stepsLimit = BattleController.currentAtacker.velocity;

        return distanceFromStartingPoint > currentDistance && stepsLimit >= currentDistance;
    }
}
