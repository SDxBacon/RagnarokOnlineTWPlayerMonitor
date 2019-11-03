
namespace RagnarokMonitor_sysinfo
{
    public class sysinfo
    {
        private int intVersion = 213;
        private string strVersion = "v2.1.6";
        private string strReleaseDate = "2019/11/04";
        private string strAuthor = "Ren-Wei, Luo.";
        private string strContact = "http://naeilproj.blogspot.tw/";
        public ServerInfo UpdateSever = new ServerInfo("0.0.0.0", 25250);
        public ServerInfo CollectServer = new ServerInfo("52.197.221.106", 25245);
        public ServerInfo RagnarokOfficialServer = new ServerInfo("219.84.200.54", 6900);


        #region class sysinfo get members methods.

        public int Version_ID
        {
            get
            {
                return intVersion;
            }
        }
        public string Version
        {
            get
            {
                return strVersion;
            }
        }
        public string ReleaseDate
        {
            get
            {
                return strReleaseDate;
            }
        }  
        public string Author
        {
            get
            {
                return strAuthor;
            }
        }
        public string Contact
        {
            get
            {
                return strContact;
            }
        }


        #endregion
    }

    public class ServerInfo
    {
        public string IP;
        public int Port;

        public ServerInfo(string IP_in, int Port_in)
        {
            IP = IP_in;
            Port = Port_in;
        }
    }

}
