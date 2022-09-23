using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighboursFinder : MonoBehaviour
{
    private BattleHex startingHex;
    private List<BattleHex> allNeighbours = new List<BattleHex>();
    private FieldManager sceneManager;
    private BattleHex[,] allHexexArray;
    // Start is called before the first frame update
    void Start()
    {
        sceneManager = FindObjectOfType<FieldManager>();
        allHexexArray = sceneManager.allHexesArray;
        GetAdjacentHexes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetAdjacentHexes()
    {
        startingHex = GetComponentInParent<BattleHex>();
        int initialX = startingHex.horizontalCoordinate - 1;
        int initialY = startingHex.verticalCoordinate - 1;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (initialY % 2 == 0)
                {
                    if (!(x == -1 && y == 1) && !(x == -1 && y == -1) && allHexexArray[initialX + x, initialY + y].battleHexState == HexState.active)
                    {
                        allNeighbours.Add(allHexexArray[initialX + x, initialY + y]);
                    }
                }
                else
                {
                    if (!(x == 1 && y == 1) && !(x == 1 && y == -1) && allHexexArray[initialX + x, initialY + y].battleHexState == HexState.active)
                    {
                        allNeighbours.Add(allHexexArray[initialX + x, initialY + y]);
                    }
                }
            }
        }

        foreach (BattleHex hex in allNeighbours)
        {
            hex.LandSpace.color = new Color32(120, 180, 200, 255);
        }
    }
}
