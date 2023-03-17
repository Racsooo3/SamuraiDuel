using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengthOfAnimation : MonoBehaviour
{
    
    public float couterTime;
    public float slashTime;
    public float sneakTime;
    public float idleTime;

    private Animator anim;
    private AnimationClip clip;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.Log("Error: Did not find anim!");
        }
        else
        {
            //Debug.Log("Got anim");
        }

        UpdateAnimClipTimes();
    }
    public void UpdateAnimClipTimes()
    {
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "player_counter":
                    couterTime = clip.length;
                    break;
                case "player_slash":
                    slashTime = clip.length;
                    break;
                case "player_sneak":
                    sneakTime = clip.length;
                    break;
                case "player_idle":
                    idleTime = clip.length;
                    break;
            }
        }
    }
}
