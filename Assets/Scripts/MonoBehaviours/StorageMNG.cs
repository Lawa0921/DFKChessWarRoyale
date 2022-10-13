using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageMNG : MonoBehaviour
{
    [SerializeField] internal CurrentProgress currentProgress;
    [SerializeField] CharIcon iconPrefab;
    List<CharAttributes> regimentIcons = new List<CharAttributes>();
    ScrollRect scrollRect;
    [SerializeField] internal Sprite selectIcon;
    [SerializeField] internal Sprite defaultIcon;
    [SerializeField] internal Sprite deployedRegimant;

    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
        CallHeroIcons();
    }

    private void CallHeroIcons()
    {
        regimentIcons = currentProgress.heroesOfPlayer;
        Transform parentOfIcons = scrollRect.content.transform;
        for (int i = 0; i < regimentIcons.Count; i++)
        {
            CharIcon fighterIcon = Instantiate(iconPrefab, parentOfIcons);
            fighterIcon.charAttributes = regimentIcons[i];
            fighterIcon.FillIcon();
        }
    }

    internal void TintIcon(CharIcon clickedIcon)
    {
        CharIcon[] charIcons = GetComponentsInChildren<CharIcon>();
        foreach (CharIcon icon in charIcons)
        {
            if (!icon.deployed)
            {
                icon.background.sprite = defaultIcon;
            }
        }
        clickedIcon.background.sprite = selectIcon;
        Deployer.readyForDeploymentIcon = clickedIcon;
    }

    internal void ReturnRegiment(CharIcon clickedIcon)
    {

    }
}
