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
    public partial class authServerPage : UserControl
    {
        Form1 f;
        Client p;
        tableCollection tabCol;
        securityCollection secCol;
        tgsServer tgServer;
        authServer aServer;
        Color ncolor;
        mainForm mainPage;
        private string decKey;
        private string encKey;



        public authServerPage(Form1 mf, Client p1, tableCollection tc, securityCollection sc, tgsServer tgs, authServer asp, mainForm mPage)
        {
            InitializeComponent();
            this.f = mf;
            this.p = p1;
            this.tabCol = tc;
            this.secCol = sc;
            this.tgServer = tgs;
            this.aServer = asp;
            this.mainPage = mPage;
            comboBox1.SelectedIndex = 0;
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*
             * this button send  Client ID to Authentication Server and request Key TGS and ticket
             * Key encrypted with Password
             *  if the ID is in the A.S then It gets ticket and encrypted key from them.
            */
            
            if (idBox.Text =="")
            {

                MessageBox.Show("Invalid Username");
            }
            else
            {
                ncolor = Color.Black;
                f.printProcess("Message encryption using Password in Authentication Server (Scenario 1,2)", ncolor);
                /* 1. Create Key TGS
                 * 2. Create Ticket which has client id, create time and Key tgs.
                 * 4. Create message with Ticket and Key TGS
                 * 3. Encrypt the Message with client's password
                 * 4. send the encrypted Message to Client.
                 * */

                string ticket = "ID:" + idBox.Text + ":time:" + (DateTime.Now.ToString("yyyyMMddHHmm")); //Create ticket
                textBox1.Text = aServer.getTGSkey();
                ticketBox.Text = ticket;
                textBox3.Text = ticket + ":key:" + aServer.getTGSkey();
                encKey = secCol.encryption(secCol.getBit(ticket + ":key:" + aServer.getTGSkey()), tabCol, aServer.getPassword(idBox.Text), f); // Encrypt the ticket using Password.
                encKeyBox.Text = encKey;
                button3.Enabled = true;
                mainPage.setFlag(1);
                mainPage.setFlag(2);
                f.setFlag(1);
                
             }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /* Send Encrypted message to Client
             * */
            f.printProcess("\n\nSend Encrypted Message to Client(Scenario 3) ", ncolor);
            button1.Enabled = true;
            p.setMessage(encKeyBox.Text.ToString());
            mainPage.setFlag(3);
            f.setFlag(2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /* 
             * 1. get client's pw
             * 2. decrypt Encrpyted Message, using PW then display the KEY(TGS)
             * 2. if the password is right then show ticket and Key TGS
             * 3. but current procedure is not right. actually whether pw is right or not, the values should be same, and TGSerer will check it by decrypting
             * 4. Create timestamp by system
             */
            if (pwBox.Text.Length !=8)
            {
                MessageBox.Show("Password should be 8 characters");
                
                
            }
            else
            {
                f.printProcess("\n\nMessage decryption using Password in PW Text Box(Scenario 4,5)", ncolor);
                decKey = secCol.decryption(p.getMessage(), tabCol, pwBox.Text, f); // decrypt encrypyed Key tgs using password
                p.setMessage(secCol.getCharString(decKey));
                decKeyBox.Text = p.getMessage();// get char string format of decrypted message
                
                string[] result = (p.getMessage()).Split(':');//splitting message
                string timestamp=null;// create timestamp
                
                timestamp += (DateTime.Now.ToString("yyyyMMddHHmm"));
                p.setTimeStamp(timestamp);
                timeStamp.Text = p.getTimeStamp();
                
                try
                {
                    if (result[5] != null)
                    {
                        textBox2.Text = result[5];
                        p.setTGSKey(result[5]);//Client get TGS Key by decrypting message
                       
                    }
                }
                catch
                {
                    textBox2.Text = "";
                    timeStamp.Text = "";
                    MessageBox.Show("Failed to decrypt Message");
                }

                button2.Enabled = true;
                mainPage.setFlag(4);
                mainPage.setFlag(5);
            }
         }

        private void button2_Click(object sender, EventArgs e)
        {
            /* 1. Set Service name from the combobox
             * 2. Create Encrypted timestamp and append it in the ticket
             * 3. Give the ticket to Client Class
             * 4. Give the encrypted timestamp to Client class
             * 
             * */
            f.printProcess("\n\nCreate Message and Encryption using Key TGS(Scenario 6)", ncolor);
            p.setServiceName(comboBox1.Text);
            string ticket = "ID:" + idBox.Text + ":createdtime:" + (DateTime.Now.ToString("yyyyMMddHHmm")) + ":expritytime:" + (DateTime.Now.AddMinutes(5).ToString("yyyyMMddHHmm")) + ":service:" + comboBox1.SelectedItem;
            string message = ticket + ":timestamp:" + p.getTimeStamp();
            p.setMessage(message);
            messageTextBox.Text = p.getMessage();
            string encMessage = secCol.encryption(secCol.getBit(p.getMessage()), tabCol, p.getTGSKey(), f); //encrypt time stamp
            messageBox.Text = encMessage;
            p.setTicket(ticket);
            p.setServiceName(comboBox1.Text);
            p.setEncMessage(encMessage);
            button4.Enabled = true;
            button2.Enabled = false;
            mainPage.setFlag(6);            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Send request to Authentication Server
            f.printProcess("\n\nSend encrypted message to TGS (Scenario 7)", ncolor);
            button4.Enabled = false;
            mainPage.setFlag(7);
            f.setFlag(3);
        }

       
       
    }
}
