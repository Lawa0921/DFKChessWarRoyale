using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfItIsOptimalPath : MonoBehaviour, IEvaluateHex
{
    public bool EvaluateHex(BattleHex evaluatedHex)
    {
        return evaluatedHex.isNeighboringHex;
    }
}
