# 《Game Research》

## 預估進度
> 2022.10.12 整合散落文件 
> 2022.10.12 撰寫JW_Core_GameManager
> 2022.10.12 撰寫JW_Core_AppManager
> 2022.10.12 撰寫JW_Core_ResourceManager
> 2022.10.12 撰寫JW_Core_StateManager

## 真實進度
- [x] 2022.10.12 整合散落文件
- [ ] 2022.10.12 撰寫JW_Core_GameManager
- [ ] 2022.10.12 撰寫JW_Core_AppManager
- [ ] 2022.10.12 撰寫JW_Core_ResourceManager
- [ ] 2022.10.12 撰寫JW_Core_StateManager

## 核心組件 (2D & 3D)
> 遊戲管理: 通稱GameManager,Nexon用GM來表示，唯一掛在物件上的核心組件。
> 應用管理: 提供遊戲底層的介面。
> 資源管理: 負責遊戲內所有非腳本資源載入。
> 狀態管理: 通過切割遊戲場景&狀態，簡化開發。
> 事件管理: 通過切割行為&狀態，降低腳本間的依賴。
> 音效管理: 負責管理音效控制。
> 網路管理: 負責管理與Server的封包。
> 線程管理: 負責管理多線程。
> 數據管理: 負責緩存遊戲數據。
> 物件管理: 負責管理重複物件資源的建立與刪除。
> 時間管理: 負責遊戲時間處理。

## 一般組件 (2D & 3D)
> 計時工具: 註冊&註銷計時行為
> 更新工具: 負責應用的冷熱更新。
> HTTP管理: 管理網頁請求發起&接收。
> UI管理: 負責管理玩家操作介面的顯示。
> 單元測試工具: 負責資料傳輸介面的穩定性。
> 單機模式工具: 負責模擬正式環境的操作。
> 動畫管理:
> 多語系工具:
> 影像管理:
> 系統訊息管理:
> 字體管理:
> Webview管理:
> 剪貼工具:
> 螢幕自適應工具:
> 碰撞檢測工具:
> 人物移動工具:

## 命名
> 遊戲管理: JW_Core_GameManager
> 應用管理: JW_Core_AppManager
> 資源管理: JW_Core_ResourceManager
> 狀態管理: JW_Core_StateManager
> 事件管理: JW_Core_EventManager
> 音效管理: JW_Core_AudioManager
> 網路管理: JW_Core_NetworkManager
> 數據管理: JW_Core_DataManager
> 線程管理: JW_Core_ThreadManager
> 時間管理: JW_Core_TimeManager


## 物件屬性
> Object ID
> ID -> Conversation
> ID -> Move Type
> ID -> Object Name
> ID -> Reactor Script


## 核心組件介紹
> 『UI』
>> 負責緩存場景中的遊戲物件
>> 通常情況下，需要避免外部直接調用遊戲物件
>> 通常情況下，需要變更遊戲物件屬性時，會開放純粹的接口給外部使用 (謹記單一職責原則)
>> 通常情況下，撰寫接口時，需要明確指出遊戲物件屬性需要的資料類型，不允許使用結構體
>> 對於提供輸入輸出的遊戲物件，當需要執行跨腳本的邏輯呼叫時，會通過"EventEmitter"實現

> 『Controller』
>> 負責UI與資料之間的介接
>> 通常情況下，會負責與UI層邏輯的實現，在資料進入UI層之前進行預處理
>> 通常情況下，會開放固定的接口，讓StateMachine可以呼叫，例如Entry()、Initialize()、Open()...

> 『EventEmitter』
>> 負責輸入與輸出之間的介接，實現跨腳本邏輯呼叫，進而降低腳本之間的依賴
>> 事件的註冊與呼叫，分別是EventEmitter.on以及EventEmitter.emit
>> 通常情況下，當邏輯具有"輸入輸出"涵義時，會使用EventEmitter.emit進行介接，執行呼叫
>> 通常情況下，當邏輯具有"資料處理"涵義時，會使用EventEmitter.on進行介接，等待被呼叫

> 『StateMachine』
>> 負責場景切換與介面切換，其管理的狀態，作為各腳本邏輯的進入點
>> 通常情況下，在Entry狀態時，會註冊需要監聽的網路事件、遊戲事件
>> 通常情況下，在Exit狀態時，會註銷正在監聽的網路事件、遊戲事件

``` mermaid
graph LR
 A[玩家登入]
 B[進入大廳流程]
 C[檢查運動彩券數據]
 D{是否中獎}
 E[彈出中獎視窗]
 F[顯示活動與公告]
 G[確認中獎訊息]

 A --> B
 B --> C
 C --> D
 D -- True --> E
 D -- false --> F
 E --> G
 G --> F
```