using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGScaler : MonoBehaviour {
    public Vector2 textureOriginSize = new Vector2(2000, 1333);

    void Start() {
        Scaler();
    }

    void Scaler() {
        Vector2 canvasSize = GetComponentInParent(typeof(Canvas)).GetComponent<RectTransform>().sizeDelta;

        float screenxyRate = canvasSize.x / canvasSize.y;
        Vector2 bgSize = textureOriginSize;
        float texturexyRate = bgSize.x / bgSize.y;

        // Debug.Log(canvasSize);

        RectTransform rt = (RectTransform)transform;

        if (texturexyRate > screenxyRate) {
            int newSizeY = Mathf.CeilToInt(canvasSize.y);
            int newSizeX = Mathf.CeilToInt((float)newSizeY / bgSize.y * bgSize.x);
            rt.sizeDelta = new Vector2(newSizeX, newSizeY);
        } else {
            int newVideoSizeX = Mathf.CeilToInt(canvasSize.x);
            int newVideoSizeY = Mathf.CeilToInt((float)newVideoSizeX / bgSize.x * bgSize.y);
            rt.sizeDelta = new Vector2(newVideoSizeX, newVideoSizeY);
        }
    }
}
