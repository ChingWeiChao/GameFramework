interface IDictionary {
    GetKeys(): any[];
    GetValues(): any[];
    Add(key: any, value: any);
    Remove(key: any);
    Clear();
}

class Dictionary implements IDictionary {
    private keys: any[] = new Array();
    private values: any[] = new Array();

    constructor(defaultData: { key: any, value: any }[]) {
        defaultData.forEach(v => this.Add(v.key, v.value));
    }

    public GetKeys(): any[] {
        return this.keys;
    }

    public GetValues(): any[] {
        return this.values;
    }

    public Add(key: any, value: any) {
        this[key] = value;
        this.keys.push(key);
        this.values.push(value);
    }

    public Remove(key: any) {
        const idx: number = this.keys.indexOf(key);

        if (idx == -1) {
            GameBase.Log(LogType.ERROR, `Key【${key}】doesn't exist.`);
            return;
        }

        this.keys.splice(idx, 1);
        this.values.splice(idx, 1);
        delete this[key];
    }

    public Clear() {
        this.keys.forEach(v => delete this[v]);
        this.keys.splice(0, this.keys.length);
        this.values.splice(0, this.values.length);
    }
}