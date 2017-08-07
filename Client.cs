using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Client
    {
        private string uid;
        private string timestamp;
        private string serviceServerName;
        private string messageContainer;
        private string encMessageContainer;
        private string csKey;
        private string tgsKey;
        private string ticket;


        public Client()
        {
            this.uid = "studentuser";
         
        }
        public void setEncMessage(string message)
        {
            encMessageContainer = message;
        }
        public string getEncMessage()
        {
            return encMessageContainer;
        }
        public void setMessage(string message)
        {
            messageContainer = message;
        }
        public string getMessage()
        {
            return messageContainer;
        }
        public string getId()
        {
            return this.uid;
        }
        public void setTGSKey(string key)
        {
            tgsKey = key;
        }
        public void setCSKey(string key)
        {
            csKey = key;
        }
        public string getTGSKey()
        {
            return tgsKey;
        }
        public string getCSKey()
        {
            return csKey;
        }
        public string getTimeStamp()
        {
            return timestamp;
        }
        public void setTimeStamp(string time)
        {
            timestamp = time;
        }
        public void setTicket(string t)
        {
            ticket = t;
        }
        public string getTicket()
        {
            return ticket;
        }
        public void setServiceName(string name)
        {
            serviceServerName = name;
        }
        public string getServiceName()
        {
            return serviceServerName;
        }
    }
}
