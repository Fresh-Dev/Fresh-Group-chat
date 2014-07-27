using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Net.Sockets;

namespace MainSoftChatClient
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNick;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtIP;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.TextBox txtChatroom;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		char crLF = (char) 10;
		char crCR = (char) 13;
		private TcpClient myClient;
		private byte[] myData = new byte[1024];
		string strMyName;
		private System.Windows.Forms.TextBox txtSend;
		private System.Windows.Forms.PictureBox pictureBox1;
		private StringBuilder myText = new StringBuilder();
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.label1 = new System.Windows.Forms.Label();
			this.txtNick = new System.Windows.Forms.TextBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.txtSend = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtIP = new System.Windows.Forms.TextBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtChatroom = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(168, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "User Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNick
			// 
			this.txtNick.Location = new System.Drawing.Point(240, 8);
			this.txtNick.MaxLength = 15;
			this.txtNick.Multiline = true;
			this.txtNick.Name = "txtNick";
			this.txtNick.Size = new System.Drawing.Size(100, 24);
			this.txtNick.TabIndex = 1;
			this.txtNick.Text = "GrasshopperUser";
			// 
			// btnConnect
			// 
			this.btnConnect.BackColor = System.Drawing.Color.WhiteSmoke;
			this.btnConnect.Location = new System.Drawing.Point(680, 8);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(104, 24);
			this.btnConnect.TabIndex = 2;
			this.btnConnect.Text = "Connect...";
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// txtSend
			// 
			this.txtSend.Location = new System.Drawing.Point(176, 264);
			this.txtSend.MaxLength = 60;
			this.txtSend.Name = "txtSend";
			this.txtSend.Size = new System.Drawing.Size(512, 20);
			this.txtSend.TabIndex = 4;
			this.txtSend.Text = "";
			// 
			// btnSend
			// 
			this.btnSend.BackColor = System.Drawing.Color.WhiteSmoke;
			this.btnSend.Location = new System.Drawing.Point(712, 264);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(72, 40);
			this.btnSend.TabIndex = 5;
			this.btnSend.Text = "Send";
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(352, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 24);
			this.label2.TabIndex = 6;
			this.label2.Text = "Server IP:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtIP
			// 
			this.txtIP.Location = new System.Drawing.Point(416, 8);
			this.txtIP.MaxLength = 15;
			this.txtIP.Multiline = true;
			this.txtIP.Name = "txtIP";
			this.txtIP.Size = new System.Drawing.Size(100, 24);
			this.txtIP.TabIndex = 7;
			this.txtIP.Text = "192.168.0.255";
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(568, 8);
			this.txtPort.MaxLength = 15;
			this.txtPort.Multiline = true;
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(100, 24);
			this.txtPort.TabIndex = 8;
			this.txtPort.Text = "1234";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(528, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 24);
			this.label3.TabIndex = 9;
			this.label3.Text = "Port:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtChatroom
			// 
			this.txtChatroom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtChatroom.Location = new System.Drawing.Point(176, 40);
			this.txtChatroom.Multiline = true;
			this.txtChatroom.Name = "txtChatroom";
			this.txtChatroom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtChatroom.Size = new System.Drawing.Size(608, 216);
			this.txtChatroom.TabIndex = 10;
			this.txtChatroom.Text = "";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(168, 312);
			this.pictureBox1.TabIndex = 11;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AcceptButton = this.btnSend;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(794, 312);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.txtChatroom);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.txtIP);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.txtSend);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.txtNick);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Opacity = 0.95;
			this.Text = "Grasshopper Chat! ";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			StringBuilder strTemp = new StringBuilder();
			if(!txtIP.Text.Equals("") && !txtPort.Text.Equals(""))
			{
				txtChatroom.AppendText("Requesting Connection");
				txtChatroom.AppendText(crCR.ToString());
				txtChatroom.AppendText(crLF.ToString());
				myClient = new TcpClient(txtIP.Text,Convert.ToInt16(txtPort.Text));
				myClient.GetStream().BeginRead(myData,0,1024,new System.AsyncCallback(this.doRead),null);
				txtChatroom.AppendText("Connected...");
				txtChatroom.AppendText(crCR.ToString());
				txtChatroom.AppendText(crLF.ToString());
				strTemp.Append("nick:");
				strMyName = txtNick.Text;
				strTemp.Append(strMyName);
				send(strTemp.ToString());

			}
			btnConnect.Enabled = false;
			txtNick.Enabled = false;
			txtIP.Enabled = false;
			txtPort.Enabled = false;
			txtSend.Enabled = true;
			btnSend.Enabled = true;

		}

		private void send(string t)
		{
			StringBuilder strSendString = new StringBuilder();
			strSendString.Append(t);
			strSendString.Append(crCR);
			strSendString.Append(crLF);
			System.IO.StreamWriter w = new System.IO.StreamWriter(myClient.GetStream());
			w.Write(strSendString.ToString());
			w.Flush();
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
					strTemp.Append("Disconnected ");
					strTemp.Append(crCR);
					strTemp.Append(crLF);
					txtChatroom.AppendText(strTemp.ToString());
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
				strTemp.Append("Disconnected :");
				strTemp.Append(e.ToString());
				strTemp.Append(crCR);
				strTemp.Append(crLF);
				txtChatroom.AppendText(strTemp.ToString());
			}
            
		}

		private void buildString(byte[] bytes, int offset, int count)
		{
			int nIndex;
			for(nIndex=offset; nIndex<=(offset+count-1); nIndex++)
			{
				if (bytes[nIndex]==10)
				{
					myText.Append(crLF);
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
				txtChatroom.AppendText("");
			}
			else
			{
				if(strMessage.IndexOf("client:")>=0)
				{
					StringBuilder strBuddyName = new StringBuilder();
					strBuddyName.Append(strMessage.ToString().Substring(7,strMessage.Length-9));
					txtChatroom.AppendText("");
				}
				else
				{
					if( (strMessage.IndexOf("closenow")>=0) || (strMessage.IndexOf("nick:")>=0) )
					{
						txtChatroom.AppendText("");
					}
					else
					{
						txtChatroom.AppendText(strMessage);
						txtChatroom.AppendText(crCR.ToString());
						txtChatroom.AppendText(crLF.ToString());
					}
				}
			}
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			
			StringBuilder strTemp = new StringBuilder();
			strTemp.Append("closenow");
			strTemp.Append(strMyName);
			send(strTemp.ToString());
		}

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			if (txtSend.Text.Length>0)
			{
				StringBuilder strTemp = new StringBuilder();
				strTemp.Append(strMyName);
				strTemp.Append(" says: ");
				strTemp.Append(txtSend.Text);
				send(strTemp.ToString());
				txtSend.Clear();
			}
		}

		
	}
}
