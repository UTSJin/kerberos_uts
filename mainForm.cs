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
    public partial class mainForm : UserControl
    {
        Form1 f;
        public mainForm(Form1 mf)
        {
            InitializeComponent();
            this.f = mf;
        }
        public void setFlag(int i)
        {
            string labelName = "scenario" + i.ToString();
            foreach(Control controler in this.Controls)
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
