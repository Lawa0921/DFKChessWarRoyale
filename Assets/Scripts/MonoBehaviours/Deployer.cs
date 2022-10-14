using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Deployer : MonoBehaviour
{
    public static CharIcon readyForDeploymentIcon;
    List<BattleHex> enemiesPositions = new List<BattleHex>();
    List<CharAttributes> enemiesToDeploy = new List<CharAttributes>();
    StorageMNG storage;
    int enemiesNum;

    void Start()
    {
        ActivatePositionsForRegiments();
        storage = FindObjectOfType<StorageMNG>();
        enemiesToDeploy = storage.currentProgress.enemies;
        enemiesNum = enemiesToDeploy.Count();
        PlaceEnemies();
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
            if (hex.deploymentPos.regimentPosition == PositionForRegiment.player)
            {
                hex.MakeDeploymentPosition();
            }
        }
    }

    internal List<BattleHex> GetEnemiesPos()
    {
        enemiesPositions.Clear();
        foreach (BattleHex hex in FieldManager.activeHexList)
        {
            if (hex.deploymentPos.regimentPosition == PositionForRegiment.enemy)
            {
                enemiesPositions.Add(hex);
            }
        }
        return enemiesPositions;
    }

    private void PlaceEnemies()
    {
        List<BattleHex> enemiesPositions = GetEnemiesPos();

        for (int i = 0; i < enemiesNum; i++)
        {
            int positionNum = enemiesPositions.Count();
            int randomIndex = UnityEngine.Random.Range(0, positionNum - 1);
            Image landscape = enemiesPositions[randomIndex].LandSpace;
            InstantiateEnemy(enemiesToDeploy[i], landscape);
            enemiesPositions.RemoveAt(randomIndex);
        }
    }

    private void InstantiateEnemy(CharAttributes charAttributes, Image hexPosition)
    {
        Hero enemy = Instantiate(charAttributes.heroSO, hexPosition.transform);
    }
}
