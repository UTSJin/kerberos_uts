using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class servicePage : UserControl
    {
        Client p;
        tableCollection tabCol;
        securityCollection secCol;
        tgsServer tgServer;
        authServer aServer;
        Color ncolor;
        rsaServiceServer sServer;
        private string encMessage;
        private string decMessage;
        Form1 f;
        mainForm mainPage;
        public servicePage(Form1 mf, Client p1, tableCollection tc, securityCollection sc, tgsServer tgs, authServer asp, rsaServiceServer rss, mainForm mPage)
        {
            InitializeComponent();
            this.f = mf;
            this.p = p1;
            this.tabCol = tc;
            this.secCol = sc;
            this.tgServer = tgs;
            this.aServer = asp;
            this.sServer = rss;
            this.mainPage = mPage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Client get the encrypted Key CS from Ticket Granting Server 
             * */
            f.printProcess("\n\nGet Encrypted CS Key from Ticket Granting Server", ncolor);
            textBox1.Text = p.getCSKey();//user get encrypted key from TGSserver
            button6.Enabled = true;
            button1.Enabled = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            /* decrypt the key using TGS key and get CS key
             */
            f.printProcess("\n\nDecrypt Key CS using Key TGS (Scenario 13)", ncolor); 
            textBox5.Text = secCol.getCharString(secCol.decryption(p.getCSKey(), tabCol, p.getTGSKey(), f));
            p.setCSKey(secCol.getCharString(secCol.decryption(p.getCSKey(), tabCol, p.getTGSKey(),f)));
            button7.Enabled = true;
            button6.Enabled = false;
            mainPage.setFlag(13);

        }
        private void button7_Click(object sender, EventArgs e)
        {
            /* encrypt Service Request message and send it to Service Server.
            * show the message on display.
            * */
            f.printProcess("\n\nCreate request message and ecnrypt the message using Key CS (Scenario 14, 15)", ncolor);
            encMessage = secCol.encryption(secCol.getBit(p.getServiceName()), tabCol, p.getCSKey(), f);
            textBox11.Text = p.getServiceName();
            textBox12.Text = encMessage;
            button2.Enabled = true;
            button7.Enabled = false;
            mainPage.setFlag(14);
            mainPage.setFlag(15);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            f.printProcess("\n\nSend Request Message to RSA Service Server (Scenario 16)", ncolor);

            textBox8.Text = sServer.getTGSSkey();
            textBox9.Text = sServer.getCSkey();
            textBox2.Text = encMessage;
            button5.Enabled = true;
            button2.Enabled=false;
            mainPage.setFlag(16);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            f.printProcess("\n\nDecrypt Key CS, using Key TGS-S (Scenario 17)", ncolor);
            string decCSkey = secCol.decryption(sServer.getCSkey(), tabCol, sServer.getTGSSkey(), f);
            textBox10.Text = secCol.getCharString(decCSkey);
            sServer.setCSkey(secCol.getCharString(decCSkey));
            button3.Enabled = true;
            button5.Enabled = false;
            mainPage.setFlag(17);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            /* as RSA server, decrypt the message and show the validity
             * 1. Decrypt the message
             * 2. Check validity by comparing the message and Service name
             * 3. If they are same, it is correct Request
             * 4. Activate Accept button to give service to Client.
             * */
            f.printProcess("\n\nDecrypt Request Message using Key CS (Scenario 18)", ncolor);
            f.printProcess("\n\nIf the request message and service name is same then acivate valid button (Scenario 19)", ncolor);

            decMessage = secCol.decryption(encMessage, tabCol, sServer.getCSkey(), f); // Decrpyt the message
            textBox3.Text = secCol.getCharString(decMessage); //Change the message into Character type string

            if (textBox3.Text == sServer.getServiceName()) // Check Validity
            {
                textBox4.Text = "Valid";
                button4.Enabled = true;
            }
            else
            {
                textBox4.Text = "invalid";
            }
            button3.Enabled = false;
            mainPage.setFlag(18);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            f.printProcess("\n\nProvide Service (Scenario 19)", ncolor);
            textBox6.Text = sServer.getPubKey();
            textBox7.Text = sServer.getPrvKey();
            button4.Enabled = false;
            mainPage.setFlag(19);
            f.setFlag(5);
        }
        


        
        
    }
}
