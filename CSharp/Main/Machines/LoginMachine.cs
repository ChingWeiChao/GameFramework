using System;
using System.Collections.Generic;

// Default StateMachine for Starting Game Logic ¡õ
public class LoginMachine: JW_Base_Machine
{
    public LoginMachine()
    {
        LoginEnterState loginEnterState = new LoginEnterState();
        AddState(loginEnterState.StateName, loginEnterState);

        LoginIdleState loginIdleState = new LoginIdleState();
        AddState(loginIdleState.StateName, loginIdleState);
    }
}
