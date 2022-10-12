class GM {
    private static _Inst: GM;
    public static get Inst(): GM { if (this._Inst == null) this._Inst = new GM(); return this._Inst; }

    private _Event: GameEvent;
    public get Event(): GameEvent { if (this._Event == null) this._Event = new GameEvent(); return this._Event; }

    private _Time: GameTime;
    public get Time(): GameTime { if (this._Time == null) this._Time = new GameTime(); return this._Time; }

    private _StateSystem: GameStateSystem;
    public get StateSystem(): GameStateSystem { if (this._StateSystem == null) this._StateSystem = new GameStateSystem(); return this._StateSystem; }


    constructor() {
        this._Event = new GameEvent();
        this._Time = new GameTime();
        // this._StateSystem = new GameStateSystem();
    }

    public async Start() {
        // this.Stage = stage;
        // await this.loadResource()
        // this.createGameScene();
        // const result = await RES.getResAsync("description_json")
        // this.startAnimation(result);
        // await platform.login();
        // const userInfo = await platform.getUserInfo();
        // console.log(userInfo);

        // const dict = new Dictionary([]);
        // dict.Add("RR", 100);
        // dict.Add(0, 100);
        // dict.Add(1, 100);
        // dict.Add("wsss", 100);
        // dict.Clear();
        // console.log(dict);

        // this.StateSystem.GetCurrentGameStateMachine().Run(DefaultState.StateName);
    }

    private IsUpdate: boolean = false;
    public Update() {
        if (this.IsUpdate) {
            GameBase.Log(LogType.NORMAL, "GM Update");

        }
    }
}