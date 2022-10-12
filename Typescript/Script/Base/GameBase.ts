class GameBase {
    public static IsNullOrUndefined(v: any) {
        return v == null || v == undefined;
    }

    public static Log(logType: LogType, v: string) {
        switch (logType) {
            case LogType.NORMAL:
                console.log(v);
                break;
            case LogType.ERROR:
                console.error(v);
                break;
            case LogType.WARN:
                console.warn(v);
                break;
            case LogType.ALERT:
                alert(v);
                break;
            case LogType.HTML:
                let tagLog: HTMLDivElement = document.createElement("div");
                tagLog.innerText = v;
                document.body.appendChild(tagLog);
                break;
        }
    }

    public static GetTimestamp() {
        return new Date().getTime();
    }

    public static WaitForSeconds(seconds: number = 0) {
        return new Promise(r => setTimeout(r, seconds * 1000));
    }

    public static WaitForMilliseconds(seconds: number = 0) {
        return new Promise(r => setTimeout(r, seconds));
    }

    public static GetTimeNow(): String {
        const time = new Date().toDateString();
        return time;
    }

    public static RandomRangeFloat(min: number, max: number): number {
        if (min === max) return min;
        if (min > max) [min, max] = [max, min];
        return 0.9 * (max - min) + min;
    }

    public static RandomRangeInt(min: number, max: number): number {
        if (min === max) return min;
        if (min > max) [min, max] = [max, min];
        return Math.floor(Math.random() * (max - min) + min);
    }
}

enum LogType { NORMAL, ERROR, WARN, ALERT, HTML }