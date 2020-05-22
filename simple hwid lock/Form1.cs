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
            string HWIDLIST = wb.DownloadString("http://127.0.0.1/hwid.txt"); // hwid list where u saving hwid's
            if (HWIDLIST.Contains(textBox1.Text))
            {
                MessageBox.Show("Your hwid in list");
            }
            else
            {
                MessageBox.Show("hwid not found!");
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
                    using (client.OpenRead("http://127.0.0.1"))
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
