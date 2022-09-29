using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnHex : MonoBehaviour, IPointerClickHandler
{
    private BattleHex hex;
    public bool isTargetHex;
    public FieldManager fieldManager;

    private void Awake()
    {
        hex = GetComponent<BattleHex>();
        fieldManager = FindObjectOfType<FieldManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
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
            if (hex.clickOnHex.isTargetHex == true)
            {
                hex.GetComponent<ClickOnHex>().isTargetHex = false;
                hex.SetAvailable();
            }
        }
    }
}
