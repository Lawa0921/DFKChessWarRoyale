using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleHex targetToMove;
    public static Hero currentAtacker;
    // Start is called before the first frame update
    void Start()
    {
        currentAtacker = FindObjectOfType<Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
