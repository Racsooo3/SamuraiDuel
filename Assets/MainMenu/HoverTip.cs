using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.localScale = new Vector3(1.3f, 1.3f);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.localScale = new Vector3(1f, 1f);
    }
}
