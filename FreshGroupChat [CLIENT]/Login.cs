using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace FreshGroupChat
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            spaceTextBox1.Text = FreshGroupChat.Default.username;
        }
        private void spaceButton1_Click(object sender, EventArgs e)
        {
            string User = spaceTextBox1.Text;
            string Pass = spaceTextBox2.Text;
            string sURL = FreshGroupChat.Default.authUrl;
            string input = new StreamReader(WebCasts.HttpPOST(sURL, "login=true&user=" + User + "&pass=" + Pass, true, true, "").GetResponseStream()).ReadToEnd();
            if (input == "success")
            {
                Form form = new Form1();
                form.Show();
                FreshGroupChat.Default.username = User;
                FreshGroupChat.Default.Save();
                this.Hide();
            }
            else { MessageBox.Show(input); }
        }

        private void RegLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
    }
}
