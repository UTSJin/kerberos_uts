using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class rsaServiceServer
    {
        private string csKey;
        private string service;
        private string pubKey;
        private string prvKey;
        private string tgssKey;

        public rsaServiceServer()
        {
            this.csKey=null;
            this.service = "RSA Service"; // Service name, it will be used to compare the message with Client's request message.
            this.pubKey = "BOB's Public Key"; // Sample public key to give to client
            this.prvKey = "Client's Private Key"; // Sample private key to give to client
            this.tgssKey = "tgsskey1";//Key TGS-S is built in key in scenario
        }
        public void setCSkey(string key)
        {
            csKey = key;
        }

        public string getCSkey()
        {
            return csKey;
        }
        public string getServiceName()
        {
            return service;
        }
        public string getPubKey()
        {
            return pubKey;
        }
        public string getPrvKey()
        {
            return prvKey;
        }
        public string getTGSSkey()
        {
            return tgssKey;
        }
    }
}
