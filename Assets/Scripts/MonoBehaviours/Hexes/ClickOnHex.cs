using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnHex : MonoBehaviour, IPointerClickHandler
{
    private BattleHex hex;
    public bool isTargetToMove = false;
    public FieldManager fieldManager;

    private void Awake()
    {
        hex = GetComponent<BattleHex>();
        fieldManager = FindObjectOfType<FieldManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isTargetToMove)
        {
            SelectTargetToMove();
        }
        else
        {
            BattleController.currentAtacker.GetComponent<Move>().StartsMoving();
        }
    }

    private void SelectTargetToMove()
    {
        ClearPreviousSelectionOfTargetHex();
        if (hex.isNeighboringHex)
        {
            hex.MakeTargetToMove();
            BattleController.currentAtacker.GetComponent<OptimalPath>().MatchPath();
        }
    }

    public void ClearPreviousSelectionOfTargetHex()
    {
        foreach (BattleHex hex in FieldManager.activeHexList)
        {
            if (hex.clickOnHex.isTargetToMove == true)
            {
                hex.GetComponent<ClickOnHex>().isTargetToMove = false;
                hex.SetAvailable();
            }
            hex.LandSpace.color = new Color32(250, 250, 250, 250);
        }
    }
}
