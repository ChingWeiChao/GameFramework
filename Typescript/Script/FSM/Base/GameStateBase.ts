class GameStateBase extends GameBase {
    public static get StateName(): string { return this['name']; }

    public Entry(): void {
        GameBase.Log(LogType.NORMAL, `${this["name"]} Entry`);
    };

    public Next(): void {
        GameBase.Log(LogType.NORMAL, `${this["name"]} Next`);
    };

    public Exit(): void {
        GameBase.Log(LogType.NORMAL, `${this["name"]} Exit`);
    };
}