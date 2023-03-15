using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePictureAnimationManager : MonoBehaviour
{
    Animator titlePictureAnimator;
    private void Start()
    {
        titlePictureAnimator = GetComponent<Animator>();

    }
    public void EndTitlePictureAnimator()
    {
        titlePictureAnimator.enabled = false;
        Invoke("FixPictureSize", 0.0001f);
    }
    private void FixPictureSize()
    {
        transform.localScale = new Vector3(3f, 3f, 3f);
    }
}
