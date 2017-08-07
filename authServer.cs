using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class authServer
    {
        private string clientId;
        private string clientPassword;
        private string tgsKey;


        public authServer()
        {
            clientId = null;
            tgsKey = "TGSKeypw";
            clientPassword = "security"; // In our scenario the client's ID:student, PW:security
        }
        
        public void setClient(Client c1)
        {
            clientId = c1.getId();
            //clientPassword = c1.getPassword();
        }
        public void setTGSkey(string key)
        {
            tgsKey = key;// set Client's Key TGS
        }
        public string getPassword(string name)
        {
            if (name == "student")
            {
                return clientPassword;
            }
            else
                return "NotAUser";
        }

        public string getTGSkey()
        {
            return tgsKey;
        }
        
    }
}
