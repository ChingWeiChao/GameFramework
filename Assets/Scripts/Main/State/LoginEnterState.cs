using System.Collections;
using System.Collections.Generic;
using JWCore;
public class LoginEnterState: StateBase
{
    public override void Entry()
    {
        Next();
    }

    public override void Next()
    {
        GM.Instance.StateMachine.Run(nameof(LoginIdleState));
    }

    public override void Exit()
    {
    }
}
