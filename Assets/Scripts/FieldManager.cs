using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public RowManager[] allRows;
    static public BattleHex[,] allHexesArray;
    static public List<BattleHex> activeHexList = new List<BattleHex>();
    public Sprite availableAsTarget;
    public Sprite notAvailable;
    public Sprite availableToMove;

    void Awake()
    {
        allRows = GetComponentsInChildren<RowManager>();

        for (int i = 0; i < allRows.Length; i++)
        {
            allRows[i].allHexesInRow = allRows[i].GetComponentsInChildren<BattleHex>();
        }
        CreateAllHexesArray();
    }

    private void Start()
    {
        IdentifyHexes();
        AvailablePos hero = FindObjectOfType<AvailablePos>();
        IAdjacentFinder adjFinder = new PositionForGround();
        BattleHex startingHex = hero.GetComponentInParent<BattleHex>();
        int stepsLimit = BattleController.currentAtacker.velocity;
        startingHex.DefineSelfAsStartingHex();
        hero.GetAvailablePositions(hero.GetComponentInParent<BattleHex>(), stepsLimit, adjFinder);
    }

    private void CreateAllHexesArray()
    {
        int heightOfArray = allRows.Length;
        int widthOfArray = allRows[0].allHexesInRow.Length;
        allHexesArray = new BattleHex[widthOfArray, heightOfArray];

        for (int i = 0; i < heightOfArray; i++)
        {
            for (int j = 0; j < widthOfArray; j++)
            {
                allHexesArray[j, i] = allRows[heightOfArray - i - 1].allHexesInRow[j];
                allHexesArray[j, i].verticalCoordinate = i + 1;
                allHexesArray[j, i].horizontalCoordinate = j + 1;
            }
        }
    }

    private void IdentifyHexes()
    {
        foreach (BattleHex hex in allHexesArray)
        {
            if (Mathf.Abs(hex.transform.position.x) > 8.5f || Mathf.Abs(hex.transform.position.y) > 4.5f )
            {
                hex.SetInActive();
            }
            else
            {
                hex.SetActive();
            }
        }
        CreateActiveHexList();
    }

    private void CreateActiveHexList()
    {
        foreach (BattleHex hex in allHexesArray)
        {
            if (hex.battleHexState == HexState.active)
            {
                activeHexList.Add(hex);
            }
        }
    }
}
