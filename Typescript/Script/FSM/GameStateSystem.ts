interface IGameStateSystem {
    Switch(gameStateMachine: GameStateMachineBase, gameStateName: string);
    GetCurrentGameStateMachine(): IGameStateMachineBase;
}

class GameStateSystem extends GameBase implements IGameStateSystem {
    private CurrentGameStateMachine: IGameStateMachineBase;

    constructor() {
        super();
        this.CurrentGameStateMachine = new DefaultMachine();
    }

    public Switch(gameStateMachine: GameStateMachineBase, gameStateName: string) {
        this.CurrentGameStateMachine.Close();
        this.CurrentGameStateMachine = gameStateMachine;
        this.CurrentGameStateMachine.Run(gameStateName);
    }

    public GetCurrentGameStateMachine(): IGameStateMachineBase {
        return this.CurrentGameStateMachine;
    }
}