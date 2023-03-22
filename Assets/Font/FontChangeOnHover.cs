using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class FontChangeOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    TMP_FontAsset Font_Original;
    TMP_FontAsset Font_Hover;

    private void Start()
    {
        Font_Original = FindObjectOfType<FontChangingManager>().GetFont_A();
        Font_Hover = FindObjectOfType<FontChangingManager>().GetFont_B();
        GetComponent<TextMeshProUGUI>().font = Font_Original;
    }

    void IPointerEnterHandler.OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData)
    {
        GetComponent<TextMeshProUGUI>().font = Font_Hover;
    }

    void IPointerExitHandler.OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
    {
        GetComponent<TextMeshProUGUI>().font = Font_Original;
    }
}
