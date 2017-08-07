using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class tgsServer
    {
        private string tgsKey;
        private string csKey;
        private string tgssKey;
        
        public tgsServer()
        {
            tgsKey = "TGSKeypw";
            tgssKey = "tgsskey1";
            csKey = "csKEYwod";
        }
        public string geTGSkey()
        {
            return tgsKey;
        }
        public void setCSkey(string key)
        {
            csKey = key;
        }
        public string getCSkey()
        {
            return csKey;
        }
        public string getTGSSkey()
        {
            return tgssKey;
        }
    }
}
