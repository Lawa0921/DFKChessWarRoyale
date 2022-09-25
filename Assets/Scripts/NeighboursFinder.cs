using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class NeighboursFinder : MonoBehaviour
{
    private BattleHex startingHex;
    static private List<BattleHex> allNeighbours = new List<BattleHex>();
    // Start is called before the first frame update
    void Start()
    {
        GetAdjacentHexes(GetComponentInParent<BattleHex>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public List<BattleHex> GetAdjacentHexes(BattleHex startingHex)
    {
        int initialX = startingHex.horizontalCoordinate - 1;
        int initialY = startingHex.verticalCoordinate - 1;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (EvaluateIfItIsNewHex(FieldManager.allHexesArray[initialX + x, initialY + y], x, y))
                {
                    allNeighbours.Add(FieldManager.allHexesArray[initialX + x, initialY + y]);
                    FieldManager.allHexesArray[initialX + x, initialY + y].SetAvailable();
                }
            }
        }
        return allNeighbours;
    }

    static private bool EvaluateIfItIsNewHex(BattleHex evaluateHex, int horizontalValueAdded, int verticalValueAdded)
    {
        if (evaluateHex.verticalCoordinate % 2 != 0)
        {
            return evaluateHex.battleHexState == HexState.active &&
                !evaluateHex.isIncluded &&
                !evaluateHex.isNeighboringHex &&
                !(horizontalValueAdded == 1 && verticalValueAdded == 1) &&
                !(horizontalValueAdded == 1 && verticalValueAdded == -1);
        }
        else
        {
            return evaluateHex.battleHexState == HexState.active &&
                !evaluateHex.isIncluded &&
                !evaluateHex.isNeighboringHex &&
                !(horizontalValueAdded == -1 && verticalValueAdded == 1) &&
                !(horizontalValueAdded == -1 && verticalValueAdded == -1);
        }
    }
}
