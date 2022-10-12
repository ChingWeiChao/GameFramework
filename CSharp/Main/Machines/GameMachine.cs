using System;
using System.Collections.Generic;

public class GameMachine : JW_Base_Machine
{
    public GameMachine()
    {
        GameEnterState gameEnterState = new GameEnterState();
        AddState(gameEnterState.StateName, gameEnterState);
    }
}
