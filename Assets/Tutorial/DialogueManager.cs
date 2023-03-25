using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //ref
    SpecialEvents specialEvents;

    public TextMeshProUGUI dialogueText;
    public Button nextDialogueButton;
    public GameObject character_sprite;

    [TextArea(5, 5)]
    public string[] dialogues;
    public int dialogueCount;


    private bool nextDialogueLock;
    public float delay = 0.1f;

    private string fullText; 
    private string currentText = "";

    void Start()
    {
        //ref
        specialEvents = GetComponent<SpecialEvents>();

        DialogueReset();

        nextDialogueButton.onClick.AddListener(() =>
        {
            if (!nextDialogueLock)
            {
                DialogueRunNext();
            }
        });
    }
    public void DialogueReset()
    {
        dialogueCount = 0;
        DialogueRunNext();
    }

    private void SpecialEvent(int dialogueCount)
    {
        // Camera focus on the 3 cards
        if (dialogueCount == 3)
        {
            specialEvents.BoardFocusCards();
        }

        // Shows the type advantage map
        if (dialogueCount == 7)
        {
            specialEvents.ShowTypeMap();
        }
        // Camera focus on the action area
        if (dialogueCount == 8)
        {
            specialEvents.BoardFocusActionArea();
        }

        //Camera reset, read card area is highlighted
        if (dialogueCount == 11)
        {
            specialEvents.ResetBoard();
            specialEvents.HighlightReadCard(true);
        }
        //Read card area is not highlighted
        if (dialogueCount == 12)
        {
            specialEvents.HighlightReadCard(false);
        }

        // Camera focus on fold
        if (dialogueCount == 14)
        {
            specialEvents.BoardFocusFold();
        }

        if (dialogueCount == 16)
        {
            specialEvents.BoardFocusFlags();
        }

    }

    public void DialogueRunNext()
    {
        if (dialogueCount < dialogues.Length)
        {
            fullText = dialogues[dialogueCount];
            StartCoroutine(ShowText());
            StartCoroutine(SpriteJump());
            SpecialEvent(dialogueCount);
            dialogueCount += 1;
        } else
        {
            Debug.Log("End Tutorial");

            GameObject.Find("GameManager").GetComponent<MainMenuTransition>().BlockedTransition();
            Invoke("LoadMainMenu", 2f);
        }
    }

    IEnumerator ShowText()
    {
        nextDialogueLock = true;
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i + 1);
            dialogueText.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        nextDialogueLock = false;
    }

    IEnumerator SpriteJump()
    {
        for (int i = 0; i < 10; i++)
        {
            character_sprite.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 3f);
            yield return new WaitForSeconds(0.02f);
        }

        for (int i = 0; i < 10; i++)
        {
            character_sprite.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0, 3f);
            yield return new WaitForSeconds(0.02f);
        }
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
