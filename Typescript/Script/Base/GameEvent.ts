interface IGameEvent {
    AddListener(label: any, callback: Function, isOnce: boolean);
    RemoveListener(eventListener: GameEventListener);
    DispatchEvent(label: any, data?: any);
}

class GameEvent implements IGameEvent {
    private _GameEventListenerGroup: object = new Object();

    public AddListener(label: any, callback: Function, isOnce: boolean = false) {
        let gameEventListeners: Array<GameEventListener> = this._GameEventListenerGroup[label];

        if (GameBase.IsNullOrUndefined(gameEventListeners)) {
            gameEventListeners = new Array();
        }

        gameEventListeners.push(new GameEventListener(label, callback, isOnce));
    }

    public RemoveListener(gameEventListener: GameEventListener) {
        if (GameBase.IsNullOrUndefined(gameEventListener)) {
            return;
        }

        let gameEventListeners: Array<GameEventListener> = this._GameEventListenerGroup[gameEventListener.Label];

        if (GameBase.IsNullOrUndefined(gameEventListeners)) {
            GameBase.Log(LogType.ERROR, `Couldn't map to event group ${gameEventListener.Label}.`);
            return;
        }

        gameEventListeners = gameEventListeners.filter((v: GameEventListener) => v.Timestamp != gameEventListener.Timestamp);
    }

    public DispatchEvent(label: any, data?: any) {
        let gameEventListeners: Array<GameEventListener> = this._GameEventListenerGroup[label];

        if (GameBase.IsNullOrUndefined(gameEventListeners)) {
            GameBase.Log(LogType.ERROR, `Couldn't map to event group ${label}.`);
            return;
        }

        gameEventListeners.forEach((v: GameEventListener, idx: number) => {
            v.Trigger(data);
        });

        gameEventListeners = gameEventListeners.filter((v: GameEventListener) => v.IsEnabled);
    }
}

class GameEventListener {
    private _Label: any;
    public get Label() { return this._Label };

    private _Callback: Function;
    private _IsOnce: boolean;

    private _IsEnabled: boolean;
    public get IsEnabled() { return this._IsEnabled };

    private _Timestamp: number;
    public get Timestamp() { return this._Timestamp };

    constructor(label: any, callback: Function, isOnce: boolean = false) {
        this._Label = label;
        this._Callback = callback;
        this._IsOnce = isOnce;
        this._IsEnabled = true;
        this._Timestamp = GameBase.GetTimestamp();
    }

    public Trigger(data: any) {
        if (this._IsOnce) {
            this._IsEnabled = false;
        }

        this._Callback(data);
    }
}