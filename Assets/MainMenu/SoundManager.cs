using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
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
            if (s.soundName == soundName)
            {
                source.volume = s.volume;
                source.PlayOneShot(s.clip);
            }
        }
    }
    public void PlayMusic(string soundName)
    {
        foreach (SoundScriptableObject s in SoundList)
        {
            if (s.soundName == soundName)
            {
                source.volume = s.volume;
                source.loop = s.loop;
                source.PlayOneShot(s.clip);
            }
        }
    }
}
