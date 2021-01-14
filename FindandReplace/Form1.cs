using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace FindandReplace
{
    public partial class Form1 : Form
    {
        public static string complete1;
        public static string complete2;
        public static string incomplete1;
        public static string incomplete2;
        public string[] fullpath3;
        public string[] fullpath4;
        public static string text1;
        public static string text2;
        public static char delim = (',');
        public static string paths;
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("config.cfg"))
            {
                try
                {
                    string line1 = File.ReadLines("config.cfg").Take(1).First();
                    string line2 = File.ReadLines("config.cfg").Skip(1).Take(1).First();
                    string line3 = File.ReadLines("config.cfg").Skip(2).Take(1).First();
                    string line4 = File.ReadLines("config.cfg").Skip(3).Take(1).First();
                    pathBox1.Text = (line1.Replace("Line1 = ", ""));
                    pathBox2.Text = (line2.Replace("Line2 = ", ""));
                    textBox2.Text = (line3.Replace("Line3 = ", ""));
                    textBox3.Text = (line4.Replace("Line4 = ", ""));
                }
                catch (InvalidOperationException)
                {
                    
                }
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked & !checkBox2.Checked)
            {
                path1.Enabled = false;
                pathBox1.Enabled = false;
                path2.Enabled = true;
                pathlabel2.Enabled = true;
                pathBox2.Enabled = true;

            }
            if (!checkBox1.Checked & !checkBox2.Checked)
            {
                path1.Enabled = true;
                pathBox1.Enabled = true;
                path2.Enabled = false;
                pathlabel2.Enabled = false;
                pathBox2.Enabled = false;
            }
            else if (checkBox2.Checked)
            {
                path1.Enabled = true;
                pathBox1.Enabled = true;
                path2.Enabled = true;
                pathlabel2.Enabled = true;
                pathBox2.Enabled = true;
            }
        }
        public void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkBox1.Checked || checkBox2.Checked)
                {
                    foreach (string fullpath32 in fullpath3)
                    {
                        string[] fullpath31 = { fullpath32 };
                        int size2 = fullpath31.Max(a => a.Length);
                        for (int a = 0; a < fullpath31.Length; a++)

                            if (File.Exists(fullpath31[a]))
                            {
                                string text = File.ReadAllText(fullpath3[a]);
                                text = text.Replace(text1, text2);
                                File.WriteAllText(fullpath31[a], text);
                                Form1.complete1 += (fullpath31[a].PadRight(65) + "--done\n");
                            }
                            else
                            {
                                Form1.incomplete1 += (fullpath31[a].PadRight(65) + "--No such file.\n");
                            }
                    }
                }
                if (checkBox1.Checked || checkBox2.Checked)
                {
                    foreach (string fullpath42 in fullpath4)
                    {
                        string[] fullpath41 = { fullpath42 };
                        int size3 = fullpath41.Max(b => b.Length);
                        for (int b = 0; b < fullpath41.Length; b++)
                        { 
                        string[] Users = Directory.GetDirectories("C:\\Users");
                        foreach (string path in Users)
                                {
                                    string fullPath1 = (path + "\\" + fullpath41[b]);
                                    string[] files = { fullPath1 };
                                    int size = files.Max(f => f.Length);
                                    for (int f = 0; f < files.Length; f++)

                                        if (File.Exists(files[f]))
                                        {
                                            string text3 = File.ReadAllText(files[f]);
                                            text3 = text3.Replace(text1, text2);
                                            File.WriteAllText(files[f], text3);
                                            Form1.complete2 += (files[f].PadRight(65) + "\t--done.\n");

                                        }
                                        else
                                        {
                                            Form1.incomplete2 += (files[f].PadRight(65) + "--No such file.\n");
                                        }

                                }
                            }
                    }
                }
                Form2 frm = new Form2();
                frm.Show();
                complete1 = null;
                complete2 = null;
                incomplete1 = null;
                incomplete2 = null;
                paths = null;
                }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Directory Not Found");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Unauthorized, Try running as administrator");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please enter information into all fields");
            }

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void path2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void flowLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        public void pathBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string pathbox11 = pathBox1.Text;
                fullpath3 = pathbox11.Split(delim);


            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please enter information into all fields");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
             text1 = textBox2.Text;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please enter information into all fields");
            }
}

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                text2 = textBox3.Text;
            }
            
            catch (NullReferenceException)
            {
                MessageBox.Show("Please enter information into all fields");
            }
        }

        public void pathBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string pathbox21 = pathBox2.Text;
                fullpath4 = pathbox21.Split(delim);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please enter information into all fields");
            }

        }

        public void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Enabled = false;
                path1.Enabled = true;
                pathBox1.Enabled = true;
                path2.Enabled = true;
                pathlabel2.Enabled = true;
                pathBox2.Enabled = true;
            }
            if (!checkBox2.Checked & checkBox1.Checked)
            {
                checkBox1.Enabled = true;
                path1.Enabled = false;
                pathBox1.Enabled = false;
                path2.Enabled = true;
                pathlabel2.Enabled = true;
                pathBox2.Enabled = true;
            }
            else if (!checkBox2.Checked & !checkBox1.Checked)
            {
                checkBox1.Enabled = true;
                path1.Enabled = true;
                pathBox1.Enabled = true;
                path2.Enabled = false;
                pathlabel2.Enabled = false;
                pathBox2.Enabled = false;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.WriteAllText("Config.cfg", "Line1 = " + pathBox1.Text + Environment.NewLine + "Line2 = " + pathBox2.Text + Environment.NewLine + "Line3 = " + textBox2.Text + Environment.NewLine + "Line4 = " + textBox3.Text);
        }
    }
    //written by Joshh916
}
