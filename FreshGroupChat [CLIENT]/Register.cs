using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.IO;

namespace FreshGroupChat
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            hwid.Text = getCPUID();
            string sURL = FreshGroupChat.Default.authUrl;
            string input = new StreamReader(WebCasts.HttpPOST(sURL, "hwid=" + getCPUID(), true, true, "").GetResponseStream()).ReadToEnd();
            if (input == "hwid found")
            {
                regAllowed.Visible = true;
                panel1.Visible = false;
                regUser.Enabled = true;
                regPass.Enabled = true;
                regButton.Enabled = true;
            }      
        }
        private string getCPUID()
        {
            string cpuInfo = "";
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();
            foreach (ManagementObject managObj in managCollec)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = managObj.Properties["processorID"].Value.ToString();
                    break;
                }
            }

            return cpuInfo;
        }

        private void spaceButton1_Click(object sender, EventArgs e)
        {
            string sURL = FreshGroupChat.Default.authUrl;
            string input = new StreamReader(WebCasts.HttpPOST(sURL, "registration=true&user=" + regUser.Text + "&pass=" + regPass.Text, true, true, "").GetResponseStream()).ReadToEnd();
            if (input == "registration done")
            {
                FreshGroupChat.Default.username = regUser.Text;
                FreshGroupChat.Default.Save();
                this.Hide(); Form form = new Login();
                form.Show();
            }
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
