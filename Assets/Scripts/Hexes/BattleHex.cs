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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
