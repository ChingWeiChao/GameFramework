using System.Collections;
using System.Collections.Generic;

public class GameIdleState : JW_Base_State
{
    public override void Entry()
    {
        JW_Tool_Logger.Log(nameof(GameIdleState) + "Entry");

       
    }

    public override void Next()
    {
        JW_Tool_Logger.Log(nameof(GameIdleState) + "Next");
    }

    public override void Exit()
    {
        JW_Tool_Logger.Log(nameof(GameIdleState) + "Exit");
    }
}
