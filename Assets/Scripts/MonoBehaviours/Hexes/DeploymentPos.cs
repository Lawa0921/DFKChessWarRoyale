using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploymentPos : MonoBehaviour
{
    public bool positionForRegiment;
    void Start()
    {

    }

    public void OnMouseDown()
    {
        BattleHex battleHex = GetComponentInParent<BattleHex>();

        if (Deployer.readyForDeploymentIcon != null && positionForRegiment)
        {
            Deployer.DeployRegiment(battleHex);
        }
    }
}
