using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoveWithCursor : MonoBehaviour
{
    [SerializeField] Transform Background;
    [SerializeField] float Stickiness;

    void Update()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        Background.transform.position = new Vector2 (0, worldPosition.y/ Stickiness);

    }
}
