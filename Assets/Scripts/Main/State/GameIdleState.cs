using System.Collections;
using System.Collections.Generic;
using JWCore;

public class GameIdleState : StateBase
{
    public override void Entry()
    {
        GM.Instance.Event.emit("tt");
    }

    public override void Next()
    {

    }

    public override void Exit()
    {
    }
}
