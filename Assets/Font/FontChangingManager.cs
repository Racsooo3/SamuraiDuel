using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FontChangingManager : MonoBehaviour
{
    [SerializeField] public TMP_FontAsset Font_A;
    [SerializeField] public TMP_FontAsset Font_B;

    public TMP_FontAsset GetFont_A () 
    {
        return Font_A;
    }
    public TMP_FontAsset GetFont_B()
    {
        return Font_B;
    }

}
