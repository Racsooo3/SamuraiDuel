using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundAnimation : MonoBehaviour
{
    private Animator roundAnim;

    private void Start()
    {
        roundAnim = GameObject.Find("RoundDisplayAnimation").GetComponent<Animator>();
        roundAnim.gameObject.SetActive(false);
    }

    public void DisplayRoundAnimation()
    {
        roundAnim.gameObject.SetActive(true);
        roundAnim.Play("DisplayRound");
        float length = 0;
        foreach (AnimationClip clip in roundAnim.runtimeAnimatorController.animationClips)
        {
            if (clip.name == "DisplayRound")
            {
                length = clip.length;
            }
        }
        Invoke("DontDisplayRoundAnimation", length);
    }
    public void DontDisplayRoundAnimation()
    {
        roundAnim.gameObject.SetActive(false);
    }
}
