using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAnimationState : GameBaseState
{
    //ref
    GameObject panelMid;

    public override void EnterState(GameStateManager game)
    {
        Debug.Log("AnimationState");
       
        panelMid = GameObject.Find("Panel Mid");
        BlackDesk(true);
    }

    public override void UpdateState(GameStateManager game)
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
