using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button playButton;
    [SerializeField] Button multiplayerButton;
    [SerializeField] Button settingsButton;

    // For local version
    // [SerializeField] Button quit;

    private void Start()
    {
        playButton.onClick.AddListener(() => {
            GetComponent<MainMenuTransition>().BlockedTransition();
            Invoke("LoadSinglePlayer", 2f);
        });

        multiplayerButton.onClick.AddListener(() => {
            GetComponent<MainMenuTransition>().BlockedTransition();
            Invoke("LoadMultiplayer", 2f);
        });

        settingsButton.onClick.AddListener(() => {
            GetComponent<MainMenuTransition>().BlockedTransition();
            Invoke("LoadSettings", 2f);
        });
    }

    private void LoadSinglePlayer()
    {
        Debug.Log("Enter Game");
    }
    private void LoadMultiplayer()
    {
        Debug.Log("Enter Hosting/Joining Menu");
    }
    private void LoadSettings()
    {
        Debug.Log("Show settings Window");
    }
}
