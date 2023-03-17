using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAnimationState : GameBaseState
{
    //ref
    GameObject panelMid;
    PlayerAnimation playerAnimation;

    public override void EnterState(GameStateManager game)
    {
        Debug.Log("AnimationState");
       
        //ref
        panelMid = GameObject.Find("Panel Mid");
        playerAnimation = GameObject.Find("GameManager").GetComponent<PlayerAnimation>();

        BlackDesk(true);

        playerAnimation.StartAnimation();
    }

    public override void UpdateState(GameStateManager game)
    {
        if (playerAnimation.anim_count < 0)
        {
            BlackDesk(false);
            game.SwitchState(game.CardDistributeState);
        }
    }

    private void BlackDesk(bool b)
    {
        // Blacked out the control desk
        panelMid.SetActive(!b);
    }
    

}
