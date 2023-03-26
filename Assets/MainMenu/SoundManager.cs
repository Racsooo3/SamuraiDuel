using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(this.gameObject);
        }
    }

    [SerializeField] private string SoundPlayOnAwake;
    [SerializeField] private string MusicPlayOnAwake;

    public List<SoundScriptableObject> SoundList = new List<SoundScriptableObject>();

    //ref 
    private AudioSource source;

    private void Start()
    {
        //ref
        source = GetComponent<AudioSource>();

        if (SoundPlayOnAwake != null)
        {
            PlaySound(SoundPlayOnAwake);
        }
        if (MusicPlayOnAwake != null)
        {
            PlayMusic(MusicPlayOnAwake);
        }
    }

    public void PlaySound(string soundName)
    {
        foreach (SoundScriptableObject s in SoundList)
        {
            if (soundName != null && s.soundName == soundName)
            {
                source.volume = s.volume;
                source.PlayOneShot(s.clip, source.volume);
            }
        }
    }
    public void PlayMusic(string soundName)
    {
        foreach (SoundScriptableObject s in SoundList)
        {
            if (soundName != null && s.soundName == soundName)
            {
                source.volume = s.volume;
                source.loop = s.loop;
                source.clip = s.clip;
                source.Play(0);
            }
        }
    }
}
