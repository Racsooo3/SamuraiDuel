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
            Debug.Log("Enter Game");
        
        });

        multiplayerButton.onClick.AddListener(() => {
            Debug.Log("Enter Hosting/Joining Menu");

        });

        settingsButton.onClick.AddListener(() => {
             Debug.Log("Show Credit Window");

         });
    }
}
