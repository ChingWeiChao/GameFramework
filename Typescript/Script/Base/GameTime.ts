interface IGameTime {
    Update();
}

class GameTime {
    private Timers: Array<Timer> = new Array();

    public AddTimer(label: any, countdown: number, callback: Function) {
        this.Timers.push(new Timer(label, GameBase.GetTimestamp() + countdown, callback));
    }

    public RemoveTimer(label: any) {
        this.Timers = this.Timers.filter((v: Timer) => v.Label != label);
    }

    public Update() {
        if (this.Timers.length > 0) {
            this.Timers.forEach((v: Timer) => v.Countdown());
            this.Timers = this.Timers.filter((v: Timer) => v.IsEnabled);
        }
    }
}

class Timer {
    private _Label: string;
    public get Label(): string { return this._Label; };
    private _TimeoutTimestamp: number;
    private _Callback: Function;
    private _IsEnabled: boolean;
    public get IsEnabled(): boolean { return this._IsEnabled; };

    constructor(label: string, timeoutTimestamp: number, callback: Function) {
        this._Label = label;
        this._TimeoutTimestamp = timeoutTimestamp;
        this._Callback = callback;
        this._IsEnabled = true;
    }

    public Countdown() {
        if (this._IsEnabled && this._TimeoutTimestamp > GameBase.GetTimestamp()) {
            this._IsEnabled = false;
            this._Callback();
        }
    }
}