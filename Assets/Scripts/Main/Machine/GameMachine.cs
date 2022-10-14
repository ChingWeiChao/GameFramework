using System;
using System.Collections.Generic;
using JWCore;

public class GameMachine : MachineBase
{
    public GameMachine()
    {
        GameEnterState gameEnterState = new GameEnterState();
        AddState(gameEnterState.StateName, gameEnterState);

        GameIdleState gameIdleState = new GameIdleState();
        AddState(gameIdleState.StateName, gameIdleState);
    }
}
