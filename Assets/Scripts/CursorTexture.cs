using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTexture : MonoBehaviour
{
    public Texture2D cursorTextureRed;
    public Texture2D cursorTextureBlue;
    private void Start()
    {
        Cursor.SetCursor(cursorTextureRed, new Vector2(0,0), CursorMode.ForceSoftware);
    }

    public void ChangeCursorColor(string redOrBlue)
    {
        if (redOrBlue == "red")
        {
            Cursor.SetCursor(cursorTextureRed, new Vector2(0, 0), CursorMode.ForceSoftware);
        } else if (redOrBlue == "blue")
        {
            Cursor.SetCursor(cursorTextureBlue, new Vector2(0, 0), CursorMode.ForceSoftware);
        }else
        {
            Debug.LogError("Wrong color brich on cursor");
        }
    }

}
