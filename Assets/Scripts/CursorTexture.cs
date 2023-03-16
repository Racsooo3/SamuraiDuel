using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTexture : MonoBehaviour
{
    public Texture2D cursorTexture;
    private void Start()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(0,0), CursorMode.ForceSoftware);
    }
}
