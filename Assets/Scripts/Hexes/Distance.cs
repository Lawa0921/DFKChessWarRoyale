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
    public void SetDistanceFromStartingHex(BattleHex initialHex)
    {
        distanceFromStartingPoint = initialHex.distanceText.distanceFromStartingPoint + initialHex.distanceText.stepsToGo;
        distanceText.text = distanceFromStartingPoint.ToString();
        distanceText.color = new Color32(255, 255, 255, 255);
    }
}
