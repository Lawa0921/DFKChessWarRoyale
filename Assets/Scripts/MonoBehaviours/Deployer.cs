using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deployer : MonoBehaviour
{
    public static CharIcon readyForDeploymentIcon;

    void Start()
    {
        ActivatePositionsForRegiments();
    }

    public static void DeployRegiment(BattleHex parentObject)
    {
        Hero regiment = readyForDeploymentIcon.charAttributes.heroSO;
        Hero fighter = Instantiate(regiment, parentObject.LandSpace.transform);
        parentObject.CleanUpDeploymentPosition();
        readyForDeploymentIcon.HeroIsDeployed();
        readyForDeploymentIcon = null;
    }

    void ActivatePositionsForRegiments()
    {
        foreach (BattleHex hex in FieldManager.allHexesArray)
        {
            if (hex.deploymentPos.positionForRegiment)
            {
                hex.MakeDeploymentPosition();
            }
        }
    }
}
