using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardFloatingAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform rect;
    //if the card is fold it rise higher
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        rect.anchoredPosition += new Vector2(0, 15f);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        rect.anchoredPosition += new Vector2(0, -15f);
    }
}
