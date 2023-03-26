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
    public TextMeshProUGUI roundDisplay;

    public Button saveButton;
    public Button timeLargerButton;
    public Button timeShorterButton;

    public Button roundLargerButton;
    public Button roundShorterButton;


    public SettingScriptableObject Settings;
    float waitingTime;
    int rounds;

    private void Start()
    {
        waitingTime = Settings.waitingTime;
        rounds = Settings.rounds;
        UpdateWT();
        UpdateRound();

        saveButton.onClick.AddListener(() =>
        {
            //Music
            FindObjectOfType<SoundManager>().PlaySound("ting");
            SaveSettings();
            GameObject.Find("GameManager").GetComponent<MainMenuTransition>().BlockedTransition();
            Invoke("ChangeScene", 2f);
        });

        timeLargerButton.onClick.AddListener(() =>
        {
            waitingTime += 15f;
            waitingTime = Mathf.Clamp(waitingTime, 15f, 300f);
            UpdateWT();
        });

        timeShorterButton.onClick.AddListener(() =>
        {
            waitingTime -= 15f;
            waitingTime = Mathf.Clamp(waitingTime, 15f, 300f);
            UpdateWT();
        });

        roundLargerButton.onClick.AddListener(() =>
        {
            rounds += 2;
            rounds = Mathf.Clamp(rounds, 3, 9);
            UpdateRound();
        });

        roundShorterButton.onClick.AddListener(() =>
        {
            rounds -= 2;
            rounds = Mathf.Clamp(rounds, 3, 9);
            UpdateRound();
        });


    }

    public void SaveSettings()
    {
        Settings.waitingTime = waitingTime;
        Settings.rounds = rounds;
    }

    private void UpdateWT()
    {
        waitingTimeDisplay.text = "Timer of each round:\r\n" + waitingTime + " seconds";
    }

    private void UpdateRound()
    {
        roundDisplay.text = "Total rounds:\r\n" + rounds + " rounds";
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
