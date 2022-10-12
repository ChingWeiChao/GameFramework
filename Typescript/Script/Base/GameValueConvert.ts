// class GameValueConvert {

//     public static ParseValueToBoolean(value, defaultValue = null): boolean | undefined {
//         try {
//             let str = Method.ParseValueToString(value, defaultValue).toLowerCase();
//             let result: boolean = false;
//             switch (str) {
//                 case "0":
//                 case "false": result = false; break;
//                 case "1":
//                 case "true": result = true; break;

//                 default:

//                     if (isNullOrUndefined(defaultValue)) {
//                         Debug.LogError("轉換value「" + value + "」To Boolean參數失敗，可以設定預設參數，否則回傳undefined");
//                         return undefined;
//                     }

//                     str = Method.ParseValueToString(defaultValue).toLowerCase();

//                     switch (str) {
//                         case "0":
//                         case "false": result = false; break;
//                         case "1":
//                         case "true": result = true; break;
//                         default:
//                             Debug.LogError("轉換defaultValue「" + str + "」To Boolean參數失敗，回傳undefined");
//                             return undefined;
//                     }
//             }
//             return result;
//         }
//         catch (e) {
//             Debug.LogError("轉換value「" + value + "」To Boolean參數失敗，回傳undefined");
//             return undefined;
//         }
//     }
//     public static ParseValueToFloat(value, defaultValue = null): number | undefined {
//         return this.ParseValueToNumber(value, defaultValue);
//     }
//     public static ParseValueToNumber(value, defaultValue = null): number | undefined {
//         try {
//             let result: number = JSON.parse(value);
//             return result;
//         }
//         catch (e) {
//             if (isNullOrUndefined(defaultValue)) {
//                 Debug.LogError("轉換value「" + value + "」To Number參數失敗，可以設定預設參數，否則回傳undefined");
//                 return undefined;
//             }
//             if (isNaN(defaultValue)) return NaN;

//             try {
//                 let result: number = JSON.parse(defaultValue);
//                 return result;
//             }
//             catch (e) {
//                 Debug.LogError("轉換defaultValue「" + defaultValue + "」To Number參數失敗，回傳undefined");
//                 return undefined;
//             }
//         }
//     }
//     public static ParseValueToInteger(value, defaultValue = null): number | undefined {
//         let number: number = this.ParseValueToNumber(value, defaultValue);

//         if (isNullOrUndefined(number)) {
//             return undefined;
//         }

//         try {
//             let result: number = parseInt(number.toString());
//             return result;
//         }
//         catch (e) {
//             if (isNullOrUndefined(defaultValue)) {
//                 Debug.LogError("轉換number「" + number + "」To Integer參數失敗");
//                 return undefined;
//             }
//         }
//     }

//     public static ParseValueToString(value, defaultValue = null): string {
//         try {
//             let result: string = value.toString();
//             return result;
//         }
//         catch (e) {
//             if (isNullOrUndefined(defaultValue)) {
//                 Debug.LogError("轉換value「" + value + "」To String參數失敗，可以設定預設參數，否則回傳空字串");
//                 return "";
//             }

//             try {
//                 let result: string = defaultValue.toString();
//                 return result;
//             }
//             catch (e) {
//                 Debug.LogError("轉換defaultValue「" + defaultValue + "」To Boolean參數失敗，回傳空字串");
//                 return "";
//             }
//         }
//     }

//     /** 無視KEY值，直接照Dic的排序強制把Dic的Value值轉換成Array */
//     public static ParseDicValueToArray(dic: any) {
//         let result: any[] = [];

//         if (dic != null) {
//             let keys = Object.keys(dic);

//             for (let i = 0, max = keys.length; i < max; i++) {
//                 result.push(dic[keys[i]]);
//             }
//         }
//         return result;
//     }

//     /** 無視KEY值，直接照Dic的排序強制把Dic的Value值轉換成Array */
//     public static ParseDicValueToNumberArray(dic: any) {
//         let result: number[] = [];

//         if (dic != null) {
//             let keys = Object.keys(dic);

//             for (let i = 0, max = keys.length; i < max; i++) {
//                 result.push(this.ParseValueToNumber(dic[keys[i]], NaN));
//             }
//         }
//         return result;
//     }

//     public static ParseValueToArray(value, defaultValue = null): any[] {
//         try {
//             if (Array.isArray(value)) {
//                 return value;
//             }

//             if ((typeof value) == "string") {
//                 let result: any[] = JSON.parse(value);
//                 return result;
//             }
//             else {
//                 let result: any[] = JSON.parse(JSON.stringify(value));
//                 return result;
//             }
//         }
//         catch (e) {
//             let str: string = Method.ParseValueToString(value, defaultValue);

//             if (!stringIsNullOrEmpty(str)) {
//                 str = this.FixStringStartCharAndEndChar(str, "[", "]");
//                 try {
//                     let result: any[] = JSON.parse(str);
//                     return result;
//                 }
//                 catch (e) {
//                 }
//             }

//             if (isNullOrUndefined(defaultValue)) {
//                 Debug.LogError("轉換value「" + value + "」To Array參數失敗，可以設定預設參數，否則回傳空Array");
//                 return [];
//             }

//             try {
//                 if (Array.isArray(defaultValue)) {
//                     return defaultValue;
//                 }
//                 let result: any[] = JSON.parse(defaultValue);
//                 return result;
//             }
//             catch (e) {
//                 let str: string = Method.ParseValueToString(defaultValue);

//                 if (!stringIsNullOrEmpty(str)) {
//                     str = this.FixStringStartCharAndEndChar(str, "[", "]");
//                     try {
//                         let result: any[] = JSON.parse(str);
//                         return result;
//                     }
//                     catch (e) {
//                     }
//                 }
//                 Debug.LogError("轉換defaultValue「" + defaultValue + "」To Array參數失敗，回傳空Array");
//                 return [];
//             }
//         }
//     }

//     public static ParseValueToAny(value, defaultValue = null): any {
//         try {
//             let result: any = JSON.parse(value);

//             if (isNullOrUndefined(result)) {
//                 if (isNullOrUndefined(defaultValue)) {
//                     return null;
//                 }
//                 result = JSON.parse(defaultValue);
//             }
//             return result;
//         }
//         catch (e) {
//             return null;
//         }
//     }

//     public static ParseValueToEnumString(enumObject, enumMember): string | undefined {
//         if (enumObject[enumMember] !== null && enumObject[enumMember] !== undefined) {
//             let int = parseInt(enumMember);
//             if (isNaN(int)) {
//                 return enumMember.toString();
//             }
//             else {
//                 return enumObject[int];
//             }
//         }
//         return undefined;
//     }
//     public static ParseValueToEnum(enumObject, enumMember): number | undefined {
//         if (enumObject[enumMember] !== null && enumObject[enumMember] !== undefined) {
//             let int = parseInt(enumMember);
//             if (isNaN(int)) {
//                 return enumObject[enumMember];
//             }
//             else {
//                 return int;
//             }
//         }
//         return undefined;
//     }
// }