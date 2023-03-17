using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    [Header("Which Ui do you want to drag to")]
    [SerializeField] private GameObject[] DragToObject;

    [SerializeField] private GameObject Deck;
    [Header("CardNumber should range 1 -5")]
    public int cardNumber;

    private Vector2 positionAfterDragEnd;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        if (TryGetComponent<CanvasGroup>(out CanvasGroup CG))
        {
            canvasGroup = CG;
        }
        else
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        positionAfterDragEnd = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        if (detectCollideWithWhichGB() != null)
        {
            if(detectCollideWithWhichGB() == Deck)
            {
                rectTransform.anchoredPosition = Deck.transform.Find(String.Format("deck{0}", cardNumber)).GetComponent<RectTransform>().anchoredPosition;
            }
            else
            {
            rectTransform.anchoredPosition = detectCollideWithWhichGB().GetComponent<RectTransform>().anchoredPosition;

            }
        }
        else
        {
            rectTransform.anchoredPosition = positionAfterDragEnd;
        }
    }
    private GameObject detectCollideWithWhichGB()
    {
        // set the touch border of this UI
        float xleft = rectTransform.anchoredPosition.x-(rectTransform.rect.width/2);
        float xright = rectTransform.anchoredPosition.x+(rectTransform.rect.width / 2);
        float ytop = rectTransform.anchoredPosition.y+(rectTransform.rect.height/2);
        float ybottom = rectTransform.anchoredPosition.y-(rectTransform.rect.height / 2);
        foreach(GameObject go in DragToObject)
        {
            RectTransform goRT = go.GetComponent<RectTransform>();
            float goxleft = goRT.anchoredPosition.x - (goRT.rect.width / 2);
            float goxright = goRT.anchoredPosition.x + (goRT.rect.width / 2);
            float goytop = goRT.anchoredPosition.y + (goRT.rect.height / 2);
            float goybottom = goRT.anchoredPosition.y - (goRT.rect.height / 2);
            if (
                ((goxleft < xleft && xleft< goxright) || (goxleft < xright && xright < goxright))   &&
                ((goytop > ytop && ytop > goybottom) || (goytop > ybottom && ybottom > goybottom))
                )
            {
                return go;
            }
        }
        return null;
    }

}
