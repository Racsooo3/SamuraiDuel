using UnityEngine;

[CreateAssetMenu(fileName = "SoundScriptableObject", menuName = "ScriptableObjects/SoundScriptableObject")]
public class SoundScriptableObject : ScriptableObject
{
    public string soundName;
    public float volume;
    public AudioClip clip;
    public bool loop;
}
