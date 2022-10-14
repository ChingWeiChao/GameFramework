using System;
using System.Collections.Generic;
using JWCore;

public class LoginMachine: MachineBase
{
    public LoginMachine()
    {
        LoginEnterState loginEnterState = new LoginEnterState();
        AddState(loginEnterState.StateName, loginEnterState);

        LoginIdleState loginIdleState = new LoginIdleState();
        AddState(loginIdleState.StateName, loginIdleState);
    }
}
