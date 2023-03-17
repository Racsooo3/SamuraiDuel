using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAnimationState : GameBaseState
{
    public override void EnterState(GameStateManager game)
    {
        Debug.Log("AnimationState");

        //BlackDesk();
        game.SwitchState(game.CardDistributeState);

    }

    public override void UpdateState(GameStateManager game)
    {
        
    }

    private void BlackDesk()
    {
        // Blacked out the control desk
        GameObject panelMid = GameObject.Find("Panel Mid");
        panelMid.SetActive(false);
    }
    

}
