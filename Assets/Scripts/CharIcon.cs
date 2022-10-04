using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharIcon : MonoBehaviour
{
    [SerializeField] internal Image heroImage;
    [SerializeField] internal Image background;
    [SerializeField] internal TMPro.TextMeshProUGUI stackText;
    [SerializeField] internal CharAttributes charAttributes;

    internal void FillIcon()
    {
        heroImage.sprite = charAttributes.heroSprite;
        stackText.text = charAttributes.stack.ToString();
    }
}
