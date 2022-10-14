using System;
using System.Collections.Generic;
using JWCore;

// Default StateMachine for Starting Game Logic ��
public class AwakeMachine : MachineBase
{
    public AwakeMachine()
    {
        AwakeEnterState awakeEnterState = new AwakeEnterState();
        AddState(awakeEnterState.StateName, awakeEnterState);
    }
}
