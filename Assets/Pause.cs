using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] Button PauseButton;

    CanvasGroup screenCanvasGroup;
    Canvas PauseCanvas;
    RectTransform ReturnGameTransform;
    RectTransform QuitGameTransform;
    private void Awake()
    {
        screenCanvasGroup = transform.GetChild(0).GetComponent<CanvasGroup>();
        PauseCanvas = gameObject.GetComponent<Canvas>();
        ReturnGameTransform = gameObject.transform.GetChild(1).GetComponent<RectTransform>();
        QuitGameTransform = gameObject.transform.GetChild(2).GetComponent<RectTransform>();
    }
    void Start()
    {
        // default seting
        PauseCanvas.sortingOrder = -1;
        screenCanvasGroup.alpha = 0;
        ReturnGameTransform.anchoredPosition = new Vector2(0, 1031);
        QuitGameTransform.anchoredPosition = new Vector2(0, 855);
        //set the button
        PauseButton.onClick.AddListener(() => {
            StartCoroutine(PauseGame());
        });
        gameObject.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => {
            StartCoroutine(ReturnGame());
        });
        gameObject.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => {
            QuitGame();
        });
    }

    private IEnumerator PauseGame()
    {
        PauseCanvas.sortingOrder = 2;
        Time.timeScale = 0;
        StartCoroutine(ButtonFall());
        StartCoroutine(TurnBlack());
        yield return new WaitForSeconds(1f);
    }
    private IEnumerator ReturnGame()
    {
        Time.timeScale = 0;
        PauseCanvas.sortingOrder = -1;
        StartCoroutine(ButtonUp());
        StartCoroutine(TurnUnBlack());
        yield return new WaitForSeconds(1f);
    }
    private void QuitGame()
    {
        Debug.Log("Quit");
    }
    private IEnumerator TurnBlack()
    {
        screenCanvasGroup.alpha += Time.unscaledDeltaTime / 0.8f;
        yield return new WaitForSeconds(0f);
        if (screenCanvasGroup.alpha <= 0.8f)
        {
            StartCoroutine(TurnBlack());
        }
    }
    private IEnumerator TurnUnBlack()
    {
        screenCanvasGroup.alpha -= Time.unscaledDeltaTime / 0.8f;
        yield return new WaitForSeconds(0f);
        if (screenCanvasGroup.alpha >= 0f)
        {
            StartCoroutine(TurnUnBlack());
        }
    }
    private IEnumerator ButtonFall()
    {
        ReturnGameTransform.anchoredPosition -= new Vector2(0, 1000 * Time.unscaledDeltaTime);
        QuitGameTransform.anchoredPosition -= new Vector2(0, 1000 * Time.unscaledDeltaTime);
        yield return new WaitForSeconds(0f);
        if (ReturnGameTransform.anchoredPosition.y >= 126)
        {
            StartCoroutine(ButtonFall());
        }
    }
    private IEnumerator ButtonUp()
    {
        ReturnGameTransform.anchoredPosition += new Vector2(0, 1000 * Time.unscaledDeltaTime);
        QuitGameTransform.anchoredPosition += new Vector2(0, 1000 * Time.unscaledDeltaTime);
        yield return new WaitForSeconds(0f);
        if (ReturnGameTransform.anchoredPosition.y <= 1040)
        {
            StartCoroutine(ButtonUp());
        }
    }
}
