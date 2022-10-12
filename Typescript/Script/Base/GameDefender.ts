interface IGameDefender {
    Update();
}

class GameDefender implements IGameDefender {
    private readonly IDLETIME: number;
    private readonly IDLECHECKINTERVAL: number;
    private readonly ISENABLED: boolean = false;

    private Check() {

    }

    public Update() {
        if (this.ISENABLED) {
            this.Check();
        }
    }
}
