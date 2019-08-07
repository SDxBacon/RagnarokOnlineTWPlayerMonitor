

# RagnarokOnlineTWPlayerMonitor

　　此專案主要是開源我在2016年分享於巴哈姆特的文章[【密技】程式分享 - 查詢伺服器人數](https://forum.gamer.com.tw/Co.php?bsn=04212&sn=2733244)
，此程式當前版本主要是透過監聽登入RO時，login server所回傳的各character server 名稱、IP與人數

　　此外，由於本人已經鮮少遊玩台灣版RO，請恕我無法回答現在Server IP, port/ start bytes等資訊
![](https://imgur.com/sGb6qqS.png)
## Getting Started

此Readme是目標給開發人員參考，如果您是一般使用者，請參考下列步驟：
1. 下載Release版程式 - [Google drive](http://ref.gamer.com.tw/redir.php?url=https%3A%2F%2Fdrive.google.com%2Ffile%2Fd%2F0B-_O7A9rVgxsVjZIWm94aVZId3M%2Fview%3Fusp%3Dsharing) / [Github Release page](https://github.com/SDxBacon/RagnarokOnlineTWPlayerMonitor/releases/tag/2.1.4)
2. 閱讀使用說明 - [巴哈姆特](https://forum.gamer.com.tw/Co.php?bsn=04212&sn=2733244) / [How To Use](HowToUse.md)

> ***Warning***: 由於RO是運行於Windows下的遊戲，因此本專案是我唯一開發的C#程式，而且我僅使用一個晚上就擬定第一版大部分程式架構，並且第二版以使用metro修改UI為主。倘若您是專業的C#或是.Net開發人員，對於結構的鬆散請保持樂觀、開朗的心態面對，切勿影響自身安全。


### Prerequisites

- .NET framework 4.5.2以上的版本 - [Microsoft .NET](https://dotnet.microsoft.com/)
- Visual Studio - [Microsoft Visual Studio](https://visualstudio.microsoft.com/zh-hant/?rr=https%3A%2F%2Fwww.google.com%2F)


### Installing
1. **下載此repository**
    - 透過Github下載master壓縮檔: [Download link](https://github.com/SDxBacon/RagnarokOnlineTWPlayerMonitor/archive/master.zip)
    - 使用git 指令下載
```sh
git clone https://github.com/SDxBacon/RagnarokOnlineTWPlayerMonitor.git
```
2. **用Visual Studio打開RagnarokMonitor_metro.sln**

## Codes that you will need to change
#### packet start bytes- file `RagnarokMonitor_metro\ragnarokPacket.cs`
如果官方修改封包start bytes，請修改以下部分。
```c#
namespace RagnarokMonitor_metro
{
    ...

    class ragnarokPacket
    {
        public static bool verifyServerInfo(byte[] data, int nRecv)
        {
            if (data[0] == 0xdb && data[1] == 0x54)  // CHANGE ME
                return true;
            else
                return false;
        }
        ...
    }
}
```

#### Login server IP - file `RagnarokMonitor_sysinfo\sysinfo.cs`
如果官方修改Login server IP & port，請修改以下部分。
```c#
namespace RagnarokMonitor_sysinfo
{
    public class sysinfo
    {
        private int intVersion = 213;
        private string strVersion = "v2.1.4";
        private string strReleaseDate = "2019/06/15";
        private string strAuthor = "Ren-Wei, Luo.";
        private string strContact = "http://naeilproj.blogspot.tw/";

        /* following two servers are deprecated */
        public ServerInfo UpdateSever = new ServerInfo("0.0.0.0", 25250);
        public ServerInfo CollectServer = new ServerInfo("52.197.221.106", 25245);

        /* Taiwan Ragnarok Online Login Server IP address and port */
        public ServerInfo RagnarokOfficialServer = new ServerInfo("219.84.200.54", 6900); // CHANGE ME

        ...
    }

}
```

## Versioning
#### 2018/10/16 -- v2.1.3

#### 2016/07/26 -- v2.1.2釋出

#### 2016/07/26 -- v2.1.1釋出

#### 2016/07/20 -- 修正IP問題

#### 2016/07/18 -- 新版介面釋出
![](https://imgur.com/sGb6qqS.png)

### 2016/07/17 -- 修正IP問題

### 2016/06/30 -- 取消登入制，改為監聽制，支援重力社台灣RO
![](https://i.imgur.com/wcD4zxE.png)
#### 2016/04/24 -- v1.0.0釋出，輸入帳號/密碼登入
![](https://truth.bahamut.com.tw/s01/201604/4b93f7ba7ccc819d8a1dcc6441a1e0d2.PNG)

## Authors

* **SDxBacon** 
  - [LinkedIn](https://www.linkedin.com/in/renwei-luo-40207885/)
  - [Gmail](mailto:rock5566r@gmail.com)
  - [巴哈姆特](https://home.gamer.com.tw/homeindex.php?owner=nancy820704)


## License

This project is licensed under the MIT License
