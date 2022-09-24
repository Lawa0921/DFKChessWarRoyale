using System.Collections;
using System.Collections.Generic;
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

    static public void GetAdjacentHexes(BattleHex startingHex)
    {
        int initialX = startingHex.horizontalCoordinate - 1;
        int initialY = startingHex.verticalCoordinate - 1;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (initialY % 2 == 0)
                {
                    if (!(x == -1 && y == 1) && !(x == -1 && y == -1) && FieldManager.allHexesArray[initialX + x, initialY + y].battleHexState == HexState.active)
                    {
                        allNeighbours.Add(FieldManager.allHexesArray[initialX + x, initialY + y]);
                        FieldManager.allHexesArray[initialX + x, initialY + y].SetAvailable();
                    }
                }
                else
                {
                    if (!(x == 1 && y == 1) && !(x == 1 && y == -1) && FieldManager.allHexesArray[initialX + x, initialY + y].battleHexState == HexState.active)
                    {
                        allNeighbours.Add(FieldManager.allHexesArray[initialX + x, initialY + y]);
                        FieldManager.allHexesArray[initialX + x, initialY + y].SetAvailable();
                    }
                }
            }
        }
    }
}
