using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public TextMeshProUGUI waitingTimeDisplay;

    public Button saveButton;
    public Button largerButton;
    public Button shorterButton;

    public SettingScriptableObject Settings;
    float waitingTime;

    private void Start()
    {
        waitingTime = Settings.waitingTime;
        UpdateWT();

        saveButton.onClick.AddListener(() =>
        {
            SetWaitingTime();
            GameObject.Find("GameManager").GetComponent<MainMenuTransition>().BlockedTransition();
            Invoke("ChangeScene", 2f);
        });

        largerButton.onClick.AddListener(() =>
        {
            waitingTime += 15f;
            waitingTime = Mathf.Clamp(waitingTime, 15f, 300f);
            UpdateWT();
        });

        shorterButton.onClick.AddListener(() =>
        {
            waitingTime -= 15f;
            waitingTime = Mathf.Clamp(waitingTime, 15f, 300f);
            UpdateWT();
        });
    }

    public void SetWaitingTime()
    {
        Settings.waitingTime = waitingTime;
    }

    private void UpdateWT()
    {
        waitingTimeDisplay.text = "Timer of each round:\r\n" + waitingTime + " seconds";
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
