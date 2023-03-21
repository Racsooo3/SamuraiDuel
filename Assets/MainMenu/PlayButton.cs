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
            Debug.Log("Enter selection menu");
            SceneManager.LoadScene("MainMenu");
        });
    }
}
