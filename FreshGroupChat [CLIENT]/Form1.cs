using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Reflection;


namespace FreshGroupChat
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
        private IContainer components;
		char crLF = (char) 10;
		char crCR = (char) 13;
		private TcpClient myClient;
		private byte[] myData = new byte[1024];
		string strMyName;
        private System.Windows.Forms.TextBox txtSend;
        private FreshTheme FreshTheme1;
        private FreshControlBox_TwoButtons FreshControlBox_TwoButtons1;
        private SpaceButton spaceButton1;
        private NotifyIcon notifyIcon;
        private RichTextBox txtChatroom;
        private Timer timer1;
            
		private StringBuilder myText = new StringBuilder();
		public Form1()
		{
			InitializeComponent();
            StringBuilder strTemp = new StringBuilder();
            txtChatroom.AppendText("Verbindung aufbauen...",Color.DarkGreen);
            txtChatroom.AppendText(crCR.ToString());
            myClient = new TcpClient(FreshGroupChat.Default.server, Convert.ToInt16(FreshGroupChat.Default.port));
                myClient.GetStream().BeginRead(myData, 0, 1024, new System.AsyncCallback(this.doRead), null);
                txtChatroom.AppendText("Verbunden...",Color.Green);
                txtChatroom.AppendText(crCR.ToString());
                strTemp.Append("username:");
                strMyName = FreshGroupChat.Default.username;
                strTemp.Append(strMyName);
                send(strTemp.ToString());
            txtSend.Enabled = true;
            spaceButton1.Enabled = true;
            txtChatroom.ScrollToCaret();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.FreshTheme1 = new FreshTheme();
            this.txtChatroom = new System.Windows.Forms.RichTextBox();
            this.spaceButton1 = new SpaceButton();
            this.FreshControlBox_TwoButtons1 = new FreshControlBox_TwoButtons();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.FreshTheme1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon2";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // FreshTheme1
            // 
            this.FreshTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.FreshTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.FreshTheme1.Controls.Add(this.txtChatroom);
            this.FreshTheme1.Controls.Add(this.spaceButton1);
            this.FreshTheme1.Controls.Add(this.FreshControlBox_TwoButtons1);
            this.FreshTheme1.Controls.Add(this.txtSend);
            this.FreshTheme1.Customization = "Pz8//xQUFP+qqqr/IBq0/wAAAP8=";
            this.FreshTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FreshTheme1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FreshTheme1.Image = null;
            this.FreshTheme1.Location = new System.Drawing.Point(0, 0);
            this.FreshTheme1.MaximumSize = new System.Drawing.Size(613, 291);
            this.FreshTheme1.MinimumSize = new System.Drawing.Size(613, 291);
            this.FreshTheme1.Movable = true;
            this.FreshTheme1.Name = "FreshTheme1";
            this.FreshTheme1.NoRounding = false;
            this.FreshTheme1.ShowIcon = false;
            this.FreshTheme1.Sizable = true;
            this.FreshTheme1.Size = new System.Drawing.Size(613, 291);
            this.FreshTheme1.SmartBounds = true;
            this.FreshTheme1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.FreshTheme1.TabIndex = 11;
            this.FreshTheme1.Text = "FreshTheme1";
            this.FreshTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FreshTheme1.Transparent = false;
            // 
            // txtChatroom
            // 
            this.txtChatroom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtChatroom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChatroom.ForeColor = System.Drawing.Color.LightGray;
            this.txtChatroom.Location = new System.Drawing.Point(3, 36);
            this.txtChatroom.Name = "txtChatroom";
            this.txtChatroom.ShowSelectionMargin = true;
            this.txtChatroom.Size = new System.Drawing.Size(608, 216);
            this.txtChatroom.TabIndex = 12;
            this.txtChatroom.Text = "";
            this.txtChatroom.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.Link_Clicked);
            // 
            // spaceButton1
            // 
            this.spaceButton1.BackColor = System.Drawing.Color.Transparent;
            this.spaceButton1.ButtonColor = CColor.Blue;
            this.spaceButton1.ButtonCurve = 5;
            this.spaceButton1.ButtonStyle = CStyle.Round;
            this.spaceButton1.Location = new System.Drawing.Point(521, 259);
            this.spaceButton1.Name = "spaceButton1";
            this.spaceButton1.Size = new System.Drawing.Size(90, 23);
            this.spaceButton1.TabIndex = 11;
            this.spaceButton1.Text = "Senden";
            this.spaceButton1.Click += new System.EventHandler(this.spaceButton1_Click);
            // 
            // FreshControlBox_TwoButtons1
            // 
            this.FreshControlBox_TwoButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FreshControlBox_TwoButtons1.Customization = "Pj4+/ywsLP8bGxv/qqqq/wAAAFo=";
            this.FreshControlBox_TwoButtons1.Font = new System.Drawing.Font("Verdana", 8F);
            this.FreshControlBox_TwoButtons1.Image = null;
            this.FreshControlBox_TwoButtons1.Location = new System.Drawing.Point(549, 2);
            this.FreshControlBox_TwoButtons1.Name = "FreshControlBox_TwoButtons1";
            this.FreshControlBox_TwoButtons1.NoRounding = false;
            this.FreshControlBox_TwoButtons1.Size = new System.Drawing.Size(53, 28);
            this.FreshControlBox_TwoButtons1.TabIndex = 3;
            this.FreshControlBox_TwoButtons1.Text = "FreshControlBox_TwoButtons1";
            this.FreshControlBox_TwoButtons1.Transparent = false;
            // 
            // txtSend
            // 
            this.txtSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.txtSend.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSend.ForeColor = System.Drawing.Color.LightGray;
            this.txtSend.Location = new System.Drawing.Point(7, 262);
            this.txtSend.MaxLength = 600;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(512, 16);
            this.txtSend.TabIndex = 4;
            this.txtSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSend_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(613, 291);
            this.Controls.Add(this.FreshTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(613, 291);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(613, 291);
            this.Name = "Form1";
            this.Text = "Fresh GroupChat";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FreshTheme1.ResumeLayout(false);
            this.FreshTheme1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (FreshGroupChat.Default.username == "firstRun")
            {
                Application.Run(new Register());
            }
            else { Application.Run(new Login()); }
		}


		private void send(string t)
		{
			StringBuilder strSendString = new StringBuilder();
			strSendString.Append(t);
			strSendString.Append(crCR);
			System.IO.StreamWriter w = new System.IO.StreamWriter(myClient.GetStream());
			w.Write(strSendString.ToString());
			w.Flush();
		}


        private void checkSmileys()
        {
            if (txtChatroom.Text.Contains(":-)"))
            {
                MessageBox.Show( ":-)" );
                Clipboard.SetImage(Properties.Resources.happy);
                txtChatroom.SelectionStart = txtChatroom.Find(":-)", RichTextBoxFinds.WholeWord);
                txtChatroom.Paste();
            }

            if (txtChatroom.Text.Contains(":)"))
            {
                txtChatroom.SelectionStart = txtChatroom.Find(":)", RichTextBoxFinds.WholeWord);
                Clipboard.SetImage(Properties.Resources.happy);
                this.txtChatroom.Paste();
            }

            if (txtChatroom.Text.Contains(";)"))
            {
                Clipboard.SetImage(Properties.Resources.zwinkern);
                txtChatroom.SelectionStart = txtChatroom.Find(";)", RichTextBoxFinds.WholeWord);
                txtChatroom.Paste();
            }

            if (txtChatroom.Text.Contains(";-)"))
            {
                txtChatroom.SelectionStart = txtChatroom.Find(";-)", RichTextBoxFinds.WholeWord);
                Clipboard.SetImage(Properties.Resources.zwinkern);
                this.txtChatroom.Paste();
            }

      
            if (txtChatroom.Text.Contains("LOL"))
            {
                txtChatroom.SelectionStart = txtChatroom.Find("LOL", RichTextBoxFinds.WholeWord);
                Clipboard.SetImage(Properties.Resources.lol);
                this.txtChatroom.Paste();
            }

            if (txtChatroom.Text.Contains("WTF"))
            {
                txtChatroom.SelectionStart = txtChatroom.Find("WTF", RichTextBoxFinds.WholeWord);
                Clipboard.SetImage(Properties.Resources.wtf);
                this.txtChatroom.Paste();
            }

            if (txtChatroom.Text.Contains("hmm"))
            {
                txtChatroom.SelectionStart = txtChatroom.Find("hmm", RichTextBoxFinds.WholeWord);
                Clipboard.SetImage(Properties.Resources.hmm);
                this.txtChatroom.Paste();
            }

            if (txtChatroom.Text.Contains("cool"))
            {
                txtChatroom.SelectionStart = txtChatroom.Find("cool", RichTextBoxFinds.WholeWord);
                Clipboard.SetImage(Properties.Resources.cool);
                this.txtChatroom.Paste();
            }


            if (txtChatroom.Text.Contains("Cool"))
            {
                txtChatroom.SelectionStart = txtChatroom.Find("Cool", RichTextBoxFinds.WholeWord);
                Clipboard.SetImage(Properties.Resources.cool);
                this.txtChatroom.Paste();
            }

            if (txtChatroom.Text.Contains(":("))
            {
                txtChatroom.SelectionStart = txtChatroom.Find(":(", RichTextBoxFinds.WholeWord);
                Clipboard.SetImage(Properties.Resources.mies);
                this.txtChatroom.Paste();
            }

            if (txtChatroom.Text.Contains(":-("))
            {
                txtChatroom.SelectionStart = txtChatroom.Find(":-(", RichTextBoxFinds.WholeWord);
                Clipboard.SetImage(Properties.Resources.mies);
                this.txtChatroom.Paste();
            }

            if (txtChatroom.Text.Contains(":-/"))
            {
                txtChatroom.SelectionStart = txtChatroom.Find(":-/", RichTextBoxFinds.WholeWord);
                Clipboard.SetImage(Properties.Resources.Damn);
                this.txtChatroom.Paste();
            }
            if (txtChatroom.Text.Contains(":/ "))
            {

                txtChatroom.SelectionStart = txtChatroom.Find(":/ ", RichTextBoxFinds.WholeWord);
                Clipboard.SetImage(Properties.Resources.Damn);
                this.txtChatroom.Paste();
            }
        }
        private void Link_Clicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

		private void doRead(IAsyncResult ar)
		{
			int nCount;
			StringBuilder strTemp = new StringBuilder();
			try
			{
				nCount = myClient.GetStream().EndRead(ar);
				if(nCount<1)
				{
                    strTemp.Append("Getrennt !");
                    

                    txtChatroom.AppendText(strTemp.ToString(), Color.Red);
                    txtChatroom.Refresh(); txtChatroom.ScrollToCaret();
				}
				else
				{
					buildString(myData,0,nCount);
					myClient.GetStream().BeginRead(myData,0,1024,new AsyncCallback(this.doRead),null);
				}
			}
			catch(Exception e)
			{
				if (strTemp.Length>0)
					strTemp.Remove(0,strTemp.Length);
				strTemp.Append("Getrennt !");
				strTemp.Append(e.ToString());
				strTemp.Append(crCR);
                txtChatroom.AppendText(strTemp.ToString(), Color.Red);
                txtChatroom.Refresh(); txtChatroom.ScrollToCaret();
			}
            
		}

		private void buildString(byte[] bytes, int offset, int count)
		{
			int nIndex;
			for(nIndex=offset; nIndex<=(offset+count-1); nIndex++)
			{
				if (bytes[nIndex]==10)
				{
                    myText.Append(crLF); txtChatroom.Refresh();
					displayText(myText.ToString());
					myText.Remove(0,myText.Length);
				}
				else
				{
					myText.Append(Convert.ToChar(bytes[nIndex]));
				}
			}
		}

		private void displayText(string strMessage)
		{
			if(strMessage.IndexOf("clear")>=0)
			{
                txtChatroom.AppendText(""); txtChatroom.Refresh();
			}
			else
			{
				if(strMessage.IndexOf("client:")>=0)
				{
					StringBuilder strBuddyName = new StringBuilder();
					strBuddyName.Append(strMessage.ToString().Substring(7,strMessage.Length-9));
                    txtChatroom.AppendText(""); txtChatroom.Refresh(); txtChatroom.ScrollToCaret();
				}
				else
				{
                    if ((strMessage.IndexOf("closenow") >= 0) || (strMessage.IndexOf("username:") >= 0)){txtChatroom.AppendText("");}
					else
					{
                        txtChatroom.AppendText(strMessage,Color.LightGray);
						txtChatroom.AppendText(crCR.ToString());
                        txtChatroom.AppendText(crLF.ToString());
                        deskNotify(strMessage); txtChatroom.ScrollToCaret();                    
					}
				}
			}
		}



		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{			
			StringBuilder strTemp = new StringBuilder();
			strTemp.Append("closenow");
            strTemp.Append(FreshGroupChat.Default.username);
			send(strTemp.ToString());
		}


        private void deskNotify(string message)
        {
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipTitle = "[" + Application.ProductName + "]";
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(5000);        
        }

        private void spaceButton1_Click(object sender, EventArgs e)
        {
            if (txtSend.Text.Length > 0)
            {
                StringBuilder strTemp = new StringBuilder();
                string zeit = "[" + DateTime.Now.ToShortTimeString() + "] ";
                strTemp.Append(zeit + strMyName);
                strTemp.Append(" sagte ");
                strTemp.Append(txtSend.Text);
                send(strTemp.ToString());
                txtSend.Clear(); txtChatroom.Refresh();
            }
        }

        private void txtSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSend.Text.Length > 0)
                {
                    StringBuilder strTemp = new StringBuilder();
                    string zeit = "[" + DateTime.Now.ToShortTimeString() + "] ";
                    strTemp.Append(zeit+strMyName);
                    strTemp.Append(" sagte ");
                    strTemp.Append(txtSend.Text);
                    send(strTemp.ToString());
                    txtSend.Clear(); txtChatroom.Refresh(); 
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StringBuilder strTemp = new StringBuilder();
            strTemp.Append("closenow");
            strTemp.Append(strMyName);
            send(strTemp.ToString());
            Application.Exit();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e){this.WindowState = FormWindowState.Normal;}
        private void timer1_Tick(object sender, EventArgs e){checkSmileys();}

		
	}
}
public static class RichTextBoxExtensions
{
    public static void AppendText(this RichTextBox box, string text, Color color)
    {
        box.SelectionStart = box.TextLength;
        box.SelectionLength = 0;
        box.SelectionColor = color;
        box.AppendText(text);
        box.SelectionColor = box.ForeColor;
    }
}
