class DefaultMachine extends GameStateMachineBase {
    constructor() {
        super();
        this.AddState(new DefaultState());
    }
}