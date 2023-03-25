using UnityEngine;

[CreateAssetMenu(fileName = "SettingScriptableObject", menuName = "ScriptableObjects/SettingScriptableObject")]
public class SettingScriptableObject : ScriptableObject
{
    public float waitingTime;
    public int rounds;
}
