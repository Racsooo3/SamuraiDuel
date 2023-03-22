using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NextButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button Next;

    private void Start()
    {
        Next = GetComponent<Button>();
    }
    private void Update()
    {
        Next.onClick.AddListener(() =>
        {
            FindObjectOfType<GameStateManager>().PlaceCardOneState.EndTimer();
            FindObjectOfType<GameStateManager>().PlaceCardTwoState.EndTimer();
        });
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Next.transform.localScale = new Vector2(1.1f,1.1f);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Next.transform.localScale = new Vector2(1f, 1f);
    }
}
