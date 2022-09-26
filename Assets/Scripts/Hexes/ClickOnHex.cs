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
        if (hex.isNeighboringHex)
        {
            print("lalalalalala");
            hex.MakeTargetToMove();
        }
    }
}
