using System.Collections;
using System.Collections.Generic;

public class LoginEnterState:JW_Base_State
{
    public override void Entry()
    {
        JW_Tool_Logger.Log(nameof(LoginEnterState) + "Entry");

        Next();
    }

    public override void Next()
    {
        JW_Tool_Logger.Log(nameof(LoginEnterState) + "Next");
        JW_Core_StateManager.Instance.Run(nameof(LoginIdleState));
    }

    public override void Exit()
    {
        JW_Tool_Logger.Log(nameof(LoginEnterState) + "Exit");
    }
}
