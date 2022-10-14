using System.Collections;
using System.Collections.Generic;
using JWCore;
public class LoginIdleState : StateBase
{
    public override void Entry()
    {
        Next();
    }

    public override void Next()
    {
        GM.Instance.StateMachine.SwitchMachine(new GameMachine());
    }

    public override void Exit()
    {
    }
}
