using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    
    public GameObject[] DragToObject;
    public GameObject Deck;
    public GameObject Fold;
    public int cardNumber;
    public AttackType attackType;
    public int playerNum;

    private Vector2 positionAfterDragEnd;
    private int slot=-1;
    private bool isFold = false;

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
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        rectTransform.anchoredPosition = Deck.transform.Find(String.Format("deck{0}", cardNumber)).GetComponent<RectTransform>().anchoredPosition;
        if (playerNum == 1)
        {
            if (slot != -1)
            {
                GameData.player1CardOrder[slot] = AttackType.Empty;
            }
            UnityEngine.Debug.Log(String.Format("Player1CardOrder: {0} , {1} , {2}", GameData.player1CardOrder[0], GameData.player1CardOrder[1], GameData.player1CardOrder[2]));
            slot = -1;
        }
        if (playerNum == 2)
        {
            if (slot != -1)
            {
                GameData.player2CardOrder[slot] = AttackType.Empty;
            }
            UnityEngine.Debug.Log(String.Format("Player2CardOrder: {0} , {1} , {2}", GameData.player2CardOrder[0], GameData.player2CardOrder[1], GameData.player2CardOrder[2]));
            slot = -1;
        }
        if (isFold)
        {
            isFold = false;
            if (playerNum == 1)
            {
                GameData.player1CardFold[(int)attackType]--;
            }
            else
            {
                GameData.player2CardFold[(int)attackType]--;
            }
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
        GameObject tempCollideGO = detectCollideWithWhichGO();
        if (tempCollideGO != null)
        {
            if(tempCollideGO == Deck)
            {
                rectTransform.anchoredPosition = Deck.transform.Find(String.Format("deck{0}", cardNumber)).GetComponent<RectTransform>().anchoredPosition;
                if(playerNum == 1)
                {
                    if (slot != -1)
                    {
                        GameData.player1CardOrder[slot] = AttackType.Empty;
                    }                  
                    UnityEngine.Debug.Log(String.Format("Player1CardOrder: {0} , {1} , {2}", GameData.player1CardOrder[0], GameData.player1CardOrder[1], GameData.player1CardOrder[2]));
                    slot = -1;
                }
                if (playerNum == 2)
                {
                    if (slot != -1)
                    {
                        GameData.player2CardOrder[slot] = AttackType.Empty;
                    }
                    UnityEngine.Debug.Log(String.Format("Player2CardOrder: {0} , {1} , {2}", GameData.player2CardOrder[0], GameData.player2CardOrder[1], GameData.player2CardOrder[2]));
                    slot = -1;
                }
            }
            else if (tempCollideGO == Fold)
            {
                isFold = true;
                rectTransform.anchoredPosition = Fold.GetComponent<RectTransform>().anchoredPosition;
                if (slot != -1)
                {
                    GameData.player1CardOrder[slot] = AttackType.Empty;
                }
                UnityEngine.Debug.Log(String.Format("Player1CardOrder: {0} , {1} , {2}", GameData.player1CardOrder[0], GameData.player1CardOrder[1], GameData.player1CardOrder[2]));
                slot = -1;
                if (playerNum == 1)
                {
                    GameData.player1CardFold[(int)attackType]++;
                }
                else
                {
                    GameData.player2CardFold[(int)attackType]++;
                }
            }

            else
            {
                for(int x = 0; x<3; x++)
                {
                    if (DragToObject[x]== tempCollideGO && playerNum==1 && GameData.player1CardOrder[x] == AttackType.Empty)
                    {
                        if (slot != -1)
                        {
                            GameData.player1CardOrder[slot] = AttackType.Empty;
                        }                
                        GameData.player1CardOrder[x] = attackType;
                        slot = x;
                        rectTransform.anchoredPosition = tempCollideGO.GetComponent<RectTransform>().anchoredPosition;
                        UnityEngine.Debug.Log(String.Format("Player1CardOrder: {0} , {1} , {2}", GameData.player1CardOrder[0], GameData.player1CardOrder[1], GameData.player1CardOrder[2]));
                        return;
                    }
                    else if (DragToObject[x]== tempCollideGO && playerNum==2 && GameData.player2CardOrder[x] == AttackType.Empty)
                    {
                        if (slot != -1)
                        {
                            GameData.player2CardOrder[slot] = AttackType.Empty;
                        }
                        slot = x;
                        GameData.player2CardOrder[x] = attackType;
                        rectTransform.anchoredPosition = tempCollideGO.GetComponent<RectTransform>().anchoredPosition;
                        UnityEngine.Debug.Log(String.Format("Player2CardOrder: {0} , {1} , {2}", GameData.player2CardOrder[0], GameData.player2CardOrder[1], GameData.player2CardOrder[2]));
                        return;
                    }
                    else
                    {
                        rectTransform.anchoredPosition = positionAfterDragEnd;
                    }

                }
            }
        }
        else
        {
            rectTransform.anchoredPosition = positionAfterDragEnd;
        }
    }
    private GameObject detectCollideWithWhichGO()
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
