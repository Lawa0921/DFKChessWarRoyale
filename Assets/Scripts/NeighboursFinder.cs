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

        if (initialY % 2 == 0)
        {
            allNeighbours.Add(allHexexArray[initialX + 1, initialY]);
            allNeighbours.Add(allHexexArray[initialX, initialY + 1]);
            allNeighbours.Add(allHexexArray[initialX - 1, initialY]);
            allNeighbours.Add(allHexexArray[initialX + 1, initialY - 1]);
            allNeighbours.Add(allHexexArray[initialX + 1, initialY + 1]);
            allNeighbours.Add(allHexexArray[initialX, initialY - 1]);
        }
        else
        {
            allNeighbours.Add(allHexexArray[initialX + 1, initialY]);
            allNeighbours.Add(allHexexArray[initialX, initialY + 1]);
            allNeighbours.Add(allHexexArray[initialX - 1, initialY]);
            allNeighbours.Add(allHexexArray[initialX, initialY - 1]);
            allNeighbours.Add(allHexexArray[initialX - 1, initialY + 1]);
            allNeighbours.Add(allHexexArray[initialX - 1, initialY - 1]);
        }

        foreach (BattleHex hex in allNeighbours)
        {
            hex.LandSpace.color = new Color32(120, 180, 200, 255);
        }
    }
}
