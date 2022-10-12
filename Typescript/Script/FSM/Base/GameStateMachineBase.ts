interface IGameStateMachineBase {
    AddState(gameState: GameStateBase);
    Run(gameStateName: string);
    Close();
}

class GameStateMachineBase extends GameBase implements IGameStateMachineBase {
    protected States: Dictionary = new Dictionary([]);
    protected CurrentState: GameStateBase;

    public Run(gameStateName: string) {
        if (GameBase.IsNullOrUndefined(this.States[gameStateName])) {
            GameBase.Log(LogType.ERROR, `State Running is failed, State ${gameStateName} is not defined.`);
            return
        }

        if (!GameBase.IsNullOrUndefined(this.CurrentState)) {
            this.CurrentState.Exit();
        }

        this.CurrentState = this.States[gameStateName];
        this.CurrentState.Entry();
    };

    public AddState(gameState: GameStateBase) {
        if (!GameBase.IsNullOrUndefined(this.States[gameState["name"]]))
            this.States[gameState["name"]] = gameState;
        else
            this.States.Add(gameState["name"], gameState)
    }

    public Close() {
        if (!GameBase.IsNullOrUndefined(this.CurrentState)) {
            this.CurrentState.Exit();
        }
        this.States.Clear();
    };
}