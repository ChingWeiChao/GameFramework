using System.Collections;
using System.Collections.Generic;

public class LoginIdleState : JW_Base_State
{
    public override void Entry()
    {
        JW_Tool_Logger.Log(nameof(LoginIdleState) + "Entry");

        Next();
    }

    public override void Next()
    {
        JW_Tool_Logger.Log(nameof(LoginIdleState) + "Next");
        JW_Core_StateManager.Instance.SwitchMachine(new GameMachine());
    }

    public override void Exit()
    {
        JW_Tool_Logger.Log(nameof(LoginIdleState) + "Exit");
    }
}
