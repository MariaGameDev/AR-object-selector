using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewContentScaleControl : MonoBehaviour
{
    private void OnRectTransformDimensionsChange()
    {
        //Debug.Log(this.GetComponent<ScrollRect>().content.transform.localScale);
        //Debug.Log(this.GetComponent<RectTransform>().rect.width);
        float newScale = this.GetComponent<RectTransform>().rect.width / 89;
        this.GetComponent<ScrollRect>().content.transform.localScale = new Vector3(newScale, newScale, 1); 
    }
}
