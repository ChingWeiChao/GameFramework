using System.Collections;
using System.Collections.Generic;

public class GameEnterState : JW_Base_State
{
    public override void Entry()
    {
        JW_Tool_Logger.Log(nameof(GameEnterState) + "Entry");

        Next();
    }

    public override void Next()
    {
        JW_Tool_Logger.Log(nameof(GameEnterState) + "Next");
    }

    public override void Exit()
    {
        JW_Tool_Logger.Log(nameof(GameEnterState) + "Exit");
    }
}
