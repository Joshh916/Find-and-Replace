using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindandReplace
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            string str1 = Form1.complete1;
            string str2 = Form1.complete2;
            string str3 = Form1.incomplete1;
            string str4 = Form1.incomplete2;
            msg1.Text = str1 + str2 + str3 + str4;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Ok_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void msg1_Click(object sender, EventArgs e)
        {
            
        }

        
        
        
    }
}
