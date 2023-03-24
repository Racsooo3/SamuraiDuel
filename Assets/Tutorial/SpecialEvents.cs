using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEvents : MonoBehaviour
{
    [SerializeField] GameObject mainGameBoard;
    [SerializeField] GameObject highlightReadCard;
    [SerializeField] GameObject typeMap;

    float lerpSpeed = 0.001f;

    private void Start()
    {
        ResetBoard();
        HighlightReadCard(false);
    }

    public void BoardFocusCards()
    {
        mainGameBoard.transform.position = Vector3.Lerp(mainGameBoard.transform.position, new Vector3(5.45f, 5.51f, 0), lerpSpeed);
        mainGameBoard.transform.localScale = Vector3.Lerp(mainGameBoard.transform.localScale, new Vector3(4f, 4f, 0f), lerpSpeed);
        if (Vector2.Distance(mainGameBoard.transform.position, new Vector3(5.45f, 5.51f, 0)) > 1f)
        {
            Invoke("BoardFocusCards", 0.001f);
        }
    }

    public void BoardFocusActionArea()
    {
        mainGameBoard.transform.position = Vector3.Lerp(mainGameBoard.transform.position, new Vector3(0f, 5.24f, 0), lerpSpeed);
        mainGameBoard.transform.localScale = Vector3.Lerp(mainGameBoard.transform.localScale, new Vector3(2.1f, 2.1f, 0f), lerpSpeed);
        if (Vector2.Distance(mainGameBoard.transform.position, new Vector3(0f, 5.24f, 0)) > 1f)
        {
            Invoke("BoardFocusActionArea", 0.001f);
        }
    }

    public void ResetBoard()
    {
        mainGameBoard.transform.position = Vector3.Lerp(mainGameBoard.transform.position, new Vector3(0, 0, 0), lerpSpeed);
        mainGameBoard.transform.localScale = Vector3.Lerp(mainGameBoard.transform.localScale, new Vector3(1.58f, 1.58f, 0f), lerpSpeed);
        if (Vector2.Distance(mainGameBoard.transform.position, new Vector3(0, 0, 0)) > 1f)
        {
            Invoke("ResetBoard", 0.001f);
        }
    }

    public void BoardFocusFold()
    {
        mainGameBoard.transform.position = Vector3.Lerp(mainGameBoard.transform.position, new Vector3(15, 9, 0), lerpSpeed);
        mainGameBoard.transform.localScale = Vector3.Lerp(mainGameBoard.transform.localScale, new Vector3(3.3f, 3.3f, 0f), lerpSpeed);
        if (Vector2.Distance(mainGameBoard.transform.position, new Vector3(0, 0, 0)) > 1f)
        {
            Invoke("BoardFocusFold", 0.001f);
        }
    }

    public void ShowTypeMap()
    {
        typeMap.SetActive(true);
    }

    public void HighlightReadCard(bool turnOnOrOff)
    {
        highlightReadCard.SetActive(turnOnOrOff);
    }
}
