using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewportContentHeightControl : MonoBehaviour
{
    private float newHeight;

    private void OnEnable()
    {
        ContentHeightControl(this.transform.childCount);
    }
    private void ContentHeightControl(int objectCount)
    {
        GridLayoutGroup gridLayoutGroup = this.GetComponent<GridLayoutGroup>();
        RectTransform rectTransform = this.GetComponent<RectTransform>();

        newHeight = ((float)Mathf.CeilToInt((float)objectCount / (float)gridLayoutGroup.constraintCount) * (gridLayoutGroup.cellSize.y + gridLayoutGroup.spacing.y)) + gridLayoutGroup.padding.top + gridLayoutGroup.padding.bottom;
        rectTransform.sizeDelta = new Vector2(rectTransform.rect.width, newHeight);
    }

    public void UpdateContentHeight()
    {
        ContentHeightControl(this.transform.childCount);
    }
}
