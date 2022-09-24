using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HexState { inactive, active };

public class BattleHex : MonoBehaviour
{
    public int horizontalCoordinate;
    public int verticalCoordinate;
    public HexState battleHexState;
    public Image LandSpace;
    [SerializeField] Image currentState;
    public bool isStartingHex = false;

    public void SetActive()
    {
        battleHexState = HexState.active;
    }

    public void SetInActive()
    {
        if (battleHexState != HexState.active)
        {
            LandSpace.color = new Color32(170, 170, 170, 255);
        }
    }

    public void SetAvailable()
    {
        LandSpace.color = new Color32(120, 180, 200, 255);
    }
}
