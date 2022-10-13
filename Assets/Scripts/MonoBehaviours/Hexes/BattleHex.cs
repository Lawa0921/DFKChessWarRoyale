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
    public ClickOnHex clickOnHex;
    public Distance distanceText;
    public DeploymentPos deploymentPos;
    [SerializeField] protected Image currentState;
    public bool isStartingHex = false;
    public bool isNeighboringHex = false;
    public bool isIncluded = false;

    private void Awake()
    {
        clickOnHex = GetComponent<ClickOnHex>();
    }

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

    public virtual void SetAvailable()
    {
        currentState.sprite = clickOnHex.fieldManager.availableToMove;
        currentState.color = new Color32(255, 255, 255, 255);
    }

    public virtual void MakeTargetToMove()
    {
        clickOnHex.isTargetToMove = true;
        BattleController.targetToMove = this;
        currentState.sprite = clickOnHex.fieldManager.availableAsTarget;
    }

    public void DefineSelfAsStartingHex()
    {
        distanceText.distanceFromStartingPoint = 0;
        isStartingHex = true;
        distanceText.stepsToGo = 1;
    }

    public virtual bool AvailableForGround()
    {
        return true;
    }

    public virtual bool AvailableForFlying()
    {
        return true;
    }

    public void MakeDeploymentPosition()
    {
        deploymentPos.GetComponent<PolygonCollider2D>().enabled = true;
        deploymentPos.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void CleanUpDeploymentPosition()
    {
        deploymentPos.GetComponent<PolygonCollider2D>().enabled = false;
        deploymentPos.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
    }
}