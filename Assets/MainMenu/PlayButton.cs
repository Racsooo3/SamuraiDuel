using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] Button playButton;

    // For local version
    // [SerializeField] Button quit;

    private void Start()
    {
        playButton.onClick.AddListener(() => {
            //music
            FindObjectOfType<SoundManager>().PlayMusic("game_bgm");
            FindObjectOfType<SoundManager>().PlaySound("ting");

            GetComponent<MainMenuTransition>().BlockedTransition();
            Invoke("LoadMainMenuScene", 2f);
        });
    }

    private void LoadMainMenuScene()
    {
        Debug.Log("Enter selection menu");
        SceneManager.LoadScene("MainMenu");
    }
}
