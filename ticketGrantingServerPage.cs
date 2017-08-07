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
    public partial class ticketGrantingServerPage : UserControl
    {
        Color ncolor;
        Client p;
        tableCollection tabCol;
        securityCollection secCol;
        tgsServer tgServer;
        authServer aServer;
        rsaServiceServer sServer;
        private string decMessage;
        Form1 f;
        mainForm mainPage;
        public ticketGrantingServerPage(Form1 mf, Client p1, tableCollection tc, securityCollection sc, tgsServer tgs, authServer asp, rsaServiceServer rss, mainForm mPage)
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


        private void button2_Click(object sender, EventArgs e)
        {
            
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Get the request from client and the get the ticket and timestamp, and get the Key TGS from Authentication Server.
             * 1. Get Request
             * 2. Get Key TGS from Authentication Server
             * 3. Split to timestamp section and ticket section 
             * */
            f.printProcess("\n\nGet Encrypted message from Client", ncolor);
            
            textBox1.Text = aServer.getTGSkey();
            textBox2.Text = p.getEncMessage();
            button3.Enabled = true;
            button1.Enabled = false;

        }


        private void button3_Click(object sender, EventArgs e)
        {
            //verification Timestamp
            /* 1. get time stamp 
             * 2. get first 9char 
             * 3. it the first chun is timestamp then it is timestamp pakcet if not return it is invalid
             * 4. get next chunks y,m,h,m 4 chnuks
             * 5. if the time has difference then 2 minuts, the message is invalid*/
          f.printProcess("\n\nDecrypt Message using Key TGS (Scenario 8)", ncolor);
          f.printProcess("If the time stamp is sent in five minute, then it is valid (Scenario 9)", ncolor);

          decMessage = secCol.decryption(p.getEncMessage(), tabCol, tgServer.geTGSkey(), f);
          decMessage = secCol.getCharString(decMessage);
          textBox9.Text = decMessage;
          string[] result = ((decMessage).Split(':'));//splitting message
          
          
          if (result.Length == 10) // check the message whether it has correct timestamp format
          {
              string ticket = "";

              for (int i = 0; i < result.Length - 2; i++)
              {
                  if(i==result.Length-3)
                  {

                      ticket += result[i];
                  }
                  else
                  {
                      ticket += result[i]+":";
                  }
              }
              string timestamp = result[result.Length-1];
              textBox13.Text = ticket;
              string curTime = DateTime.Now.ToString("yyyyMMddHHmm");
              long flag = Convert.ToInt64(curTime) - Convert.ToInt64(timestamp);
              //if the time is send in five minutes
              if (flag < 5)
              {
                  button4.Enabled = true;
                  textBox8.Text = timestamp;
                  textBox3.Text = "valid";
              }
              else
              {
                  textBox8.Text = timestamp;
                  textBox3.Text = "invalid";
              }
          }

          else
          {
                textBox3.Text = "invalid";
          }
          button3.Enabled = false;
          mainPage.setFlag(8);
          mainPage.setFlag(9);
       }

        private void button4_Click(object sender, EventArgs e)
        {
            /* Create Key CS and encrypt the Key using Key TGS before send it to Client
             * 1. generate Key CS
             * 2. store in TGS server
             * 3. encrypt the Key CS, using Key TGS
             **/

            f.printProcess("\n\nEncrpyt Key CS using Key TGS to send to Client (Scenario 10)", ncolor);
            f.printProcess("Encrpyt Key CS using Key TGS-S to send to Service Server (Scenario 11)", ncolor);
            string encToclient = secCol.encryption(secCol.getBit(tgServer.getCSkey()), tabCol, tgServer.geTGSkey(), f);
            string encToSServer = secCol.encryption(secCol.getBit(tgServer.getCSkey()), tabCol, tgServer.getTGSSkey(), f);
            textBox4.Text = tgServer.getCSkey();
            textBox5.Text = encToclient;
            textBox10.Text = tgServer.getTGSSkey();
            textBox11.Text = encToSServer;
            button5.Enabled = true;
            button4.Enabled = false;
            mainPage.setFlag(10);
            mainPage.setFlag(11);
        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            /* Send the encrypted Key to Client 
             * Send the key CS to Service Server (RSA SERVICE SERVER)
             * 
             * 1. Get Encrypted key
             * 2, Set to TGS SERVER
             * 3. Set to Service Server
             * */
            f.printProcess("\n\nSend Key CS to RSA server and Client (Scenario 12)", ncolor);

            sServer.setCSkey(textBox11.Text.ToString());//Send to RSA server 
            p.setCSKey(textBox5.Text.ToString());
            button5.Enabled = false;
            mainPage.setFlag(12);
            f.setFlag(4);
        }


        
    }
}
