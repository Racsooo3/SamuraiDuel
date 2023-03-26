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
    Button ReturnGameButton;
    Button QuitGameButton;
    Button ToggleHelperButton;
    RectTransform ButtonsTransform;

    bool PauseButtonLock;
    private void Awake()
    {
        screenCanvasGroup = transform.GetChild(0).GetComponent<CanvasGroup>();
        PauseCanvas = gameObject.GetComponent<Canvas>();
        ReturnGameButton = gameObject.transform.GetChild(1).GetChild(0).GetComponent<Button>();
        QuitGameButton = gameObject.transform.GetChild(1).GetChild(1).GetComponent<Button>();
        ToggleHelperButton = gameObject.transform.GetChild(1).GetChild(2).GetComponent<Button>();

        ButtonsTransform = transform.GetChild(1).GetComponent<RectTransform>();
    }
    void Start()
    {
        // default seting
        PauseCanvas.sortingOrder = -1;
        screenCanvasGroup.alpha = 0;

        //set the button
        PauseButton.onClick.AddListener(() =>
        {
            if (PauseButtonLock) return;
            PauseGame();
        });
        ReturnGameButton.onClick.AddListener(() =>
        {
            if (PauseButtonLock) return;
            ReturnGame();
        });
        QuitGameButton.onClick.AddListener(() =>
        {
            QuitGame();
        });
        ToggleHelperButton.onClick.AddListener(() =>
        {
            ToggleHelper();
        });
    }

    private void PauseGame()
    {
        PauseButtonLock = true;
        PauseCanvas.sortingOrder = 2;
        Time.timeScale = 0;
        StartCoroutine(ButtonFall());
        StartCoroutine(TurnBlack());
        //yield return new WaitForSeconds(1f);
    }
    private void ReturnGame()
    {
        PauseButtonLock = true;
        Time.timeScale = 1;
        PauseCanvas.sortingOrder = -1;
        StartCoroutine(ButtonUp());
        StartCoroutine(TurnUnBlack());
        //yield return new WaitForSeconds(1f);
    }
    private void QuitGame()
    {
        Debug.Log("Quit Match");
        ReturnGame();
        LoadMainMenu();
    }
    private IEnumerator TurnBlack()
    {
        screenCanvasGroup.alpha = 0.6f;
        //screenCanvasGroup.alpha += 0.8f * Time.unscaledDeltaTime;
        yield return new WaitForSeconds(0f);
        /*        if (screenCanvasGroup.alpha <= 0.8f)
                {
                    StartCoroutine(TurnBlack());
                }*/
    }
    private IEnumerator TurnUnBlack()
    {
        screenCanvasGroup.alpha = 0f;

        //screenCanvasGroup.alpha -= 0.8f * Time.unscaledDeltaTime;
        yield return new WaitForSeconds(0f);
        /*        if (screenCanvasGroup.alpha >= 0.001f) // the alpha value can never be zero because of line 77
                {
                    StartCoroutine(TurnUnBlack());
                }*/
    }
    private IEnumerator ButtonFall()
    {
        ButtonsTransform.anchoredPosition -= new Vector2(0, 1500 * Time.unscaledDeltaTime);

        yield return new WaitForSeconds(0f);
        if (ButtonsTransform.anchoredPosition.y >= 0)
        {
            StartCoroutine(ButtonFall());
        }
        else
        {
            PauseButtonLock = false;
        }
    }
    private IEnumerator ButtonUp()
    {
        ButtonsTransform.anchoredPosition += new Vector2(0, 1500 * Time.unscaledDeltaTime);

        yield return new WaitForSeconds(0f);
        if (ButtonsTransform.anchoredPosition.y <= 900)
        {
            StartCoroutine(ButtonUp());
        }
        else
        {
            PauseButtonLock = false;
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    [SerializeField] SettingScriptableObject Settings;
    private bool ToggleHelper()
    {
        if (Settings.eyeHelper == true)
        {
            Settings.eyeHelper = false;
            FindObjectOfType<EyeHelper>().ShowHelpers(false);
        } else
        {
            Settings.eyeHelper = true;
            FindObjectOfType<EyeHelper>().ShowHelpers(true);
        }
        return Settings.eyeHelper;
    }
}
