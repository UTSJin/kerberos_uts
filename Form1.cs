using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
       
        private authServerPage auPage;
        private servicePage servPage;
        private ticketGrantingServerPage tgsPage;
        private mainForm mPage;
        public Client  p1 = new Client(); // User Role
        public authServer asp = new authServer(); // Authentication server role
        public rsaServiceServer rss =new rsaServiceServer(); // Service server role and the service type is RSA
        public tgsServer tgsp = new tgsServer(); // Ticket Granting Server Role
        public tableCollection tabCol = new tableCollection(); // Collection of tables, such as pbox, sbox, expansion p box and soon.
        public securityCollection secCol = new securityCollection(); // collection security operation, key generation, enncryption and so on.
        public Form1()
        {
            InitializeComponent();
            mPage = new mainForm(this);
            auPage = new authServerPage(this, p1, tabCol, secCol, tgsp, asp, mPage);
            tgsPage = new ticketGrantingServerPage(this, p1, tabCol, secCol, tgsp, asp, rss, mPage);
            servPage = new servicePage(this, p1, tabCol, secCol, tgsp, asp, rss, mPage);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           this.panel1.Controls.Clear();
           this.panel1.Controls.Add(mPage);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(mPage);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(auPage);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(tgsPage);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(servPage);
        }


        internal void printProcess(string msg, System.Drawing.Color color)
        {
            //Print to rich text through the system.
            this.richTextBox1.SelectionColor = color;
            this.richTextBox1.AppendText(msg + "\r\n");
            this.richTextBox1.ScrollToCaret();
        }
        public void setFlag(int i)
        {
            string labelName = "stage" + i.ToString();
            foreach (Control controler in this.Controls)
            {
                if (controler is Label)
                {
                    if (((Label)controler).Name.ToString() == labelName)
                    {
                        controler.ForeColor = Color.Red;
                        break;
                    }
                }
            }
        }
        
        
    }
}
