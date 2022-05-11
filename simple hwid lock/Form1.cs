using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
Changes:
Changed from textBox1.Text to hwid-HWID CHECK
Changed to 1.1.1.1-ONLINE CHECK
*/
namespace simple_hwid_lock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            check();
        }

        string hwid;

        private void Form1_Load(object sender, EventArgs e)
        {
            hwid = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value;
            textBox1.Text = hwid;
            textBox1.ReadOnly = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            string HWIDLIST = wb.DownloadString("http://127.0.0.1/hwid.txt"); // Your hwid list
            if (HWIDLIST.Contains(hwid)) //Changed from textBox1.Text to hwid
            {
                MessageBox.Show("Your hwid is in the list!");
            }
            else
            {
                MessageBox.Show("Your hwid isnt in the list!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(hwid);
            button2.Enabled = false;
            button2.Text = "Copied";
        }

        private void check()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("https://1.1.1.1")) //Changed to 1.1.1.1
                    {
                        label3.ForeColor = Color.Green;
                        label3.Text = ("Online");
                    }
                }
            }
            catch
            {
                label3.ForeColor = Color.Red;
                label3.Text = ("Offline");
            }
        }
    }
}
