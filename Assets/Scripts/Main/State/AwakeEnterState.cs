using System.Collections;
using System.Collections.Generic;
using JWCore;

public class AwakeEnterState : StateBase
{
    public override void Entry()
    {
        //檢查APP更新
        //檢查AB更新

        GM.Instance.Event.on("tt", () => {
            GM.Instance.Log.Write("Test");
        });
        Next();
    }

    public override void Next()
    {
        GM.Instance.StateMachine.SwitchMachine(new LoginMachine());
    }

    public override void Exit()
    {
    }
}
