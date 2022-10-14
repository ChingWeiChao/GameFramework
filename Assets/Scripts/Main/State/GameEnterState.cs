using System.Collections;
using System.Collections.Generic;
using JWCore;

public class GameEnterState : StateBase
{
    public override void Entry()
    {
        Next();
    }

    public override void Next()
    {
        GM.Instance.StateMachine.Run(nameof(GameIdleState));
    }

    public override void Exit()
    {
    }
}
