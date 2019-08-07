## Introduction
此文件會教導您如何使用**RagnarokTW線上人數查詢**程式，內容與分享於巴哈姆特文章- [【密技】程式分享 - 查詢伺服器人數](https://forum.gamer.com.tw/Co.php?bsn=04212&sn=2733244)大致相同，僅以Markdown版本撰寫。

## How to use RagnarokTW線上人數查詢
### Step1. 下載程式
請至以下連結下載，擇一即可：
- [Google drive](https://ref.gamer.com.tw/redir.php?url=https%3A%2F%2Fdrive.google.com%2Ffile%2Fd%2F0B-_O7A9rVgxsVjZIWm94aVZId3M%2Fview%3Fusp%3Dsharing)  
- [Github Release](https://github.com/SDxBacon/RagnarokOnlineTWPlayerMonitor/releases/tag/2.1.4)
  
您必須擁有 .NET framework 4.5.2以上的版本，如果沒有的人請去MSDN下載:
- [MSDN](https://docs.microsoft.com/zh-tw/dotnet/framework/install/guide-for-developers)

### Step 2. 解壓縮  

解壓縮後，資料夾較為重要的檔案如下：

(1)  _**RagnarokMonitor_metro.exe**_

(2)  **_WindowsVista_and_above.bat_**

(3)  **_WindowsXP.bat_**

(4)  **_必讀.txt_**

![](https://i.imgur.com/Hq6ylaN.png)

  ### Step 3. 將應用程式加入防火牆例外名單 

 由於本程式需要使用Raw socket，所以需要管理員權限，同時也需要將本程式加入windows的防火牆例外中。否則執行是不會有任何結果的唷！

***若您的電腦本身是把Windows防火牆關閉的，那這步驟就可以跳過了***

請照下列圖片所示，以系統管理員身分執行唷！因為需要插入防火牆的例外規則，此次步驟只要執行一次就可以囉。
- 若您的作業是Windows Vista以上（含Vista、Win 7、Win 8、Win 8.1以及Win 10），請執行【WindowsVista_and_above.bat】

- 若是Windows XP的作業系統請執行，【WindowsXP.bat】
  
![](https://i.imgur.com/X4asNii.png)

  
### Step 4. 選擇網路介面卡
  
如果您只有一個網路介面卡，那麼就只會有一個選項，就大膽的選擇它吧！如下圖：
  ![](https://imgur.com/MbmZmlN.png)

  
如果您不只有一個選項，請選擇您用來與default gateway溝通的interface。

看不懂的也不用擔心，請參閱下列步驟選擇：
 

1. 打開【**網路共和中心**】

![](https://i.imgur.com/ZfZ5gcM.png)

  
2. 開啟【**變更介面卡設定**】
![](https://i.imgur.com/b0OdeyE.png)
  
3. **查找網路介面卡IP**
![](https://imgur.com/ymEsyab.png)

  

### Step 5. 開始監控

按下【開始】按鈕後，打開您的RO並正常登入遊戲
  ![](https://i.imgur.com/DjKR9C1.png)

### Step 6. 監控結果
成功登入後應該會有結果拉！

  ![](https://i.imgur.com/hizFntV.png)