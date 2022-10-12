class GameWeb {
    public static EmbedJavascriptUrl(url: string, tagID?: string) {
        const tagScript: HTMLScriptElement = document.createElement("script");
        tagScript.id = tagID || "EmbedJavascript";
        tagScript.src = url;
        document.body.appendChild(tagScript);
    }

    public static EmbedJavascript(script: string, tagID?: string) {
        const tagScript: HTMLScriptElement = document.createElement("script");
        tagScript.id = tagID || "EmbedJavascript";;
        tagScript.innerHTML = script;
        document.body.appendChild(tagScript);
    }

    // Most game engines disabled function "location.href", so set default to "_blank".
    public static OpenPage(url: string, isNewTab: boolean = true) {
        window.scrollTo(0, 0);

        if (isNewTab)
            window.open(url, "_blank")
        else
            window.open(url)
    }

    public static ReloadPage() {
        window.parent.location.reload();
    }

    //Force cookie being expired by setting time "Thu, 01 Jan 1970 00:00:00 GMT" to it. 
    public static ClearCookie(key: string) {
        const allCookies: string[] = document.cookie.split(';');

        for (let i = 0; i < allCookies.length; i++) {
            if (allCookies[i].split('=')[0] == key) {
                document.cookie = allCookies[i] + "=;expires=" + new Date(0).toUTCString();
                break;
            }
        }
    }

    //Force cookies being expired by setting time "Thu, 01 Jan 1970 00:00:00 GMT" to it. 
    public static ClearAllCookies() {
        const allCookies: string[] = document.cookie.split(';');

        for (let i = 0; i < allCookies.length; i++) {
            document.cookie = allCookies[i] + "=;expires=" + new Date(0).toUTCString();
        }
    }
}