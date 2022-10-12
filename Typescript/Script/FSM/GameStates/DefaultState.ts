class DefaultState extends GameStateBase {
    public Entry(): void {
        super.Entry();

        this.Next();
    }

    public Next(): void {
        super.Next();
        GM.Inst.StateSystem.Switch(FSMConfig.DefaultGameStateMachine, FSMConfig.DefaultGameStateName);
    }

    public Exit(): void {
        super.Exit();
    }
}