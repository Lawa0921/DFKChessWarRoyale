using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PositionForRegiment { none, player, enemy };

public class DeploymentPos : MonoBehaviour
{
    public PositionForRegiment regimentPosition;
    void Start()
    {

    }

    public void OnMouseDown()
    {
        BattleHex battleHex = GetComponentInParent<BattleHex>();

        if (Deployer.readyForDeploymentIcon != null && regimentPosition == PositionForRegiment.player)
        {
            Deployer.DeployRegiment(battleHex);
        }
    }
}
