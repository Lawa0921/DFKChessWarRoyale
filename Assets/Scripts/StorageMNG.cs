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
}
