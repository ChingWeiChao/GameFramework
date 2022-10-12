interface IList<T> {
    Add(value: T);
    Get(idx: number);
    Contains(value: T): boolean;
    Clear();
    ToArray(): T[];
    Remove(idx: number);
}

class List<T> implements IList<T> {
    private valueType: string;
    private value: T[] = new Array();

    public Add(value: T) {
        if (GameBase.IsNullOrUndefined(value)) return;

        if (this.valueType == null) {
            this.valueType = typeof (value);
        } else {
            if (typeof (value) != this.valueType) {
                GameBase.Log(LogType.ERROR, `List<${this.valueType}> can't add value<${typeof (value)}>.`);
                return;
            }
        }

        this[this.value.length] = value;
        this.value.push(value);
    }

    public Get(idx: number) {
        if (GameBase.IsNullOrUndefined(idx)) return null;

        if (idx < 0 || idx >= this.value.length) {
            GameBase.Log(LogType.ERROR, `Index is out of range.`);
            return null;
        }

        return this.value[idx];
    }

    public Contains(value: T): boolean {
        if (GameBase.IsNullOrUndefined(value)) return false;

        return this.value.indexOf(value) != -1
    }

    public Clear() {
        this.value.splice(0, this.value.length);
        this.valueType = "";
        this.Update();
    }

    public ToArray(): T[] {
        const arr: any = new Array();
        this.value.forEach(v => arr.push(v));
        return arr;
    }

    public Remove(idx: number) {
        if (GameBase.IsNullOrUndefined(idx)) return;
        this.value.splice(idx, 1);
        this.Update();
    }

    private Update() {
        let count = 0;
        while (count < this.value.length + 2) {
            if (!GameBase.IsNullOrUndefined(this.value[count]))
                this[count] = this.value[count];
            else
                delete this[count]

            count++;
        }
    }
}