using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NextButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button Next;
    [SerializeField] GameObject card_limit_warning_particle;
    [SerializeField] Transform warningSpawnPosition;

    private void Start()
    {
        Next = GetComponent<Button>();
        Next.onClick.AddListener(() =>
        {
            GameStateManager gameStateManager = FindObjectOfType<GameStateManager>();
            GamePlaceCardOneState placeCardOneState = gameStateManager.PlaceCardOneState;
            GamePlaceCardTwoState placeCardTwoState = gameStateManager.PlaceCardTwoState;
            if (gameStateManager.GetCurrentState() == placeCardOneState)
            {
                if (!gameStateManager.PlaceCardOneState.EndTimer())
                {
                    Instantiate(card_limit_warning_particle, warningSpawnPosition.position, Quaternion.identity);
                }
            } 
            if (gameStateManager.GetCurrentState() == placeCardTwoState)
            {
                if (!gameStateManager.PlaceCardTwoState.EndTimer())
                {
                    Instantiate(card_limit_warning_particle, warningSpawnPosition.position, Quaternion.identity);
                }
            }
        });
    }
    private void Update()
    {
        
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
