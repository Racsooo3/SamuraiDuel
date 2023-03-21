using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardFloatingAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    RectTransform rect;
    bool isFloating;
    //if the card is fold it rise higher
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (!isFloating)
        {
            rect.anchoredPosition += new Vector2(0, 15f);
            isFloating = true;
        }
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (isFloating)
        {
            rect.anchoredPosition += new Vector2(0, -15f);
            isFloating = false;
        }
    }
    void IPointerClickHandler.OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (isFloating)
        {
            isFloating = false;
        }
    }
}
