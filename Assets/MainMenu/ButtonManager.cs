using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            StartCoroutine(LoadSinglePlayer());
        });

        multiplayerButton.onClick.AddListener(() => {
            GetComponent<MainMenuTransition>().BlockedTransition();
            StartCoroutine(LoadMultiplayer());
        });

        settingsButton.onClick.AddListener(() => {
            GetComponent<MainMenuTransition>().BlockedTransition();
            Invoke("LoadSettings", 2f);
        });
    }
    private IEnumerator LoadSinglePlayer()
    {
        Debug.Log("Load single player");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("OneComputerTwoPlayers");
        yield return new WaitForSeconds(0.01f);
        GameObject.Find("/GameManager").GetComponent<GameStateManager>().SinglePlayer = true;
    }    
    private IEnumerator LoadMultiplayer()
    {
        Debug.Log("Load Multiplayer");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("OneComputerTwoPlayers");
        yield return new WaitForSeconds(0.01f);
        GameObject.Find("/GameManager").GetComponent<GameStateManager>().SinglePlayer = false;
    }
    private void LoadSettings()
    {
        Debug.Log("Load Setting Scene");
        SceneManager.LoadScene("SettingsMenu");
    }
}
