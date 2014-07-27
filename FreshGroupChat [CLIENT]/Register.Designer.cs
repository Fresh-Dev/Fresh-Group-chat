namespace FreshGroupChat
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.FreshTheme1 = new FreshTheme();
            this.regAllowed = new System.Windows.Forms.Panel();
            this.stLabel1 = new STLabel();
            this.regButton = new SpaceButton();
            this.regUser = new SpaceTextBox();
            this.stLabel2 = new STLabel();
            this.regPass = new SpaceTextBox();
            this.FreshControlBox_TwoButtons1 = new FreshControlBox_TwoButtons();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.stLabel4 = new STLabel();
            this.stLabel3 = new STLabel();
            this.hwid = new SpaceTextBox();
            this.FreshTheme1.SuspendLayout();
            this.regAllowed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FreshTheme1
            // 
            this.FreshTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.FreshTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.FreshTheme1.Controls.Add(this.FreshControlBox_TwoButtons1);
            this.FreshTheme1.Controls.Add(this.pictureBox1);
            this.FreshTheme1.Controls.Add(this.panel1);
            this.FreshTheme1.Controls.Add(this.regAllowed);
            this.FreshTheme1.Customization = "Pz8//xQUFP+qqqr/wMAA/wAAAP8=";
            this.FreshTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FreshTheme1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FreshTheme1.Image = null;
            this.FreshTheme1.Location = new System.Drawing.Point(0, 0);
            this.FreshTheme1.MaximumSize = new System.Drawing.Size(586, 250);
            this.FreshTheme1.MinimumSize = new System.Drawing.Size(586, 250);
            this.FreshTheme1.Movable = true;
            this.FreshTheme1.Name = "FreshTheme1";
            this.FreshTheme1.NoRounding = false;
            this.FreshTheme1.ShowIcon = false;
            this.FreshTheme1.Sizable = true;
            this.FreshTheme1.Size = new System.Drawing.Size(586, 250);
            this.FreshTheme1.SmartBounds = true;
            this.FreshTheme1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.FreshTheme1.TabIndex = 2;
            this.FreshTheme1.Text = "FreshTheme1";
            this.FreshTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FreshTheme1.Transparent = false;
            // 
            // regAllowed
            // 
            this.regAllowed.Controls.Add(this.stLabel1);
            this.regAllowed.Controls.Add(this.regButton);
            this.regAllowed.Controls.Add(this.regUser);
            this.regAllowed.Controls.Add(this.stLabel2);
            this.regAllowed.Controls.Add(this.regPass);
            this.regAllowed.Location = new System.Drawing.Point(133, 144);
            this.regAllowed.Name = "regAllowed";
            this.regAllowed.Size = new System.Drawing.Size(277, 94);
            this.regAllowed.TabIndex = 10;
            this.regAllowed.Visible = false;
            // 
            // stLabel1
            // 
            this.stLabel1.Font = new System.Drawing.Font("Verdana", 8F);
            this.stLabel1.Location = new System.Drawing.Point(16, 14);
            this.stLabel1.Name = "stLabel1";
            this.stLabel1.Size = new System.Drawing.Size(59, 14);
            this.stLabel1.Text = "Username";
            this.stLabel1.TextColor = System.Drawing.Color.White;
            this.stLabel1.TextColorBack = System.Drawing.Color.Black;
            // 
            // regButton
            // 
            this.regButton.BackColor = System.Drawing.Color.Transparent;
            this.regButton.ButtonColor = CColor.Blue;
            this.regButton.ButtonCurve = 5;
            this.regButton.ButtonStyle = CStyle.Round;
            this.regButton.Enabled = false;
            this.regButton.Location = new System.Drawing.Point(96, 63);
            this.regButton.Name = "regButton";
            this.regButton.Size = new System.Drawing.Size(115, 23);
            this.regButton.TabIndex = 3;
            this.regButton.Text = "Register";
            this.regButton.Click += new System.EventHandler(this.spaceButton1_Click);
            // 
            // regUser
            // 
            this.regUser.BackColor = System.Drawing.Color.Transparent;
            this.regUser.Curve = 1;
            this.regUser.Enabled = false;
            this.regUser.Font = new System.Drawing.Font("Verdana", 8F);
            this.regUser.Lines = new string[0];
            this.regUser.Location = new System.Drawing.Point(81, 11);
            this.regUser.MaxLength = 2147483647;
            this.regUser.Multiline = false;
            this.regUser.Name = "regUser";
            this.regUser.ReadOnly = false;
            this.regUser.Size = new System.Drawing.Size(156, 20);
            this.regUser.TabIndex = 1;
            this.regUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.regUser.UseSystemPasswordChar = false;
            // 
            // stLabel2
            // 
            this.stLabel2.Font = new System.Drawing.Font("Verdana", 8F);
            this.stLabel2.Location = new System.Drawing.Point(16, 43);
            this.stLabel2.Name = "stLabel2";
            this.stLabel2.Size = new System.Drawing.Size(55, 14);
            this.stLabel2.Text = "Password";
            this.stLabel2.TextColor = System.Drawing.Color.White;
            this.stLabel2.TextColorBack = System.Drawing.Color.Black;
            // 
            // regPass
            // 
            this.regPass.BackColor = System.Drawing.Color.Transparent;
            this.regPass.Curve = 1;
            this.regPass.Enabled = false;
            this.regPass.Font = new System.Drawing.Font("Verdana", 8F);
            this.regPass.Lines = new string[0];
            this.regPass.Location = new System.Drawing.Point(81, 37);
            this.regPass.MaxLength = 2147483647;
            this.regPass.Multiline = false;
            this.regPass.Name = "regPass";
            this.regPass.ReadOnly = false;
            this.regPass.Size = new System.Drawing.Size(156, 20);
            this.regPass.TabIndex = 2;
            this.regPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.regPass.UseSystemPasswordChar = true;
            // 
            // FreshControlBox_TwoButtons1
            // 
            this.FreshControlBox_TwoButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FreshControlBox_TwoButtons1.Customization = "Pj4+/ywsLP8bGxv/qqqq/wAAAFo=";
            this.FreshControlBox_TwoButtons1.Font = new System.Drawing.Font("Verdana", 8F);
            this.FreshControlBox_TwoButtons1.Image = null;
            this.FreshControlBox_TwoButtons1.Location = new System.Drawing.Point(521, 2);
            this.FreshControlBox_TwoButtons1.Name = "FreshControlBox_TwoButtons1";
            this.FreshControlBox_TwoButtons1.NoRounding = false;
            this.FreshControlBox_TwoButtons1.Size = new System.Drawing.Size(53, 28);
            this.FreshControlBox_TwoButtons1.TabIndex = 1;
            this.FreshControlBox_TwoButtons1.Text = "FreshControlBox_TwoButtons1";
            this.FreshControlBox_TwoButtons1.Transparent = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FreshGroupChat.Properties.Resources.Unbenannt_3;
            this.pictureBox1.Location = new System.Drawing.Point(80, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(422, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.stLabel4);
            this.panel1.Controls.Add(this.stLabel3);
            this.panel1.Controls.Add(this.hwid);
            this.panel1.Location = new System.Drawing.Point(131, 144);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 94);
            this.panel1.TabIndex = 11;
            // 
            // stLabel4
            // 
            this.stLabel4.Font = new System.Drawing.Font("Verdana", 8F);
            this.stLabel4.Location = new System.Drawing.Point(16, 60);
            this.stLabel4.Name = "stLabel4";
            this.stLabel4.Size = new System.Drawing.Size(142, 14);
            this.stLabel4.Text = "Please give this to admin";
            this.stLabel4.TextColor = System.Drawing.Color.White;
            this.stLabel4.TextColorBack = System.Drawing.Color.Black;
            // 
            // stLabel3
            // 
            this.stLabel3.Font = new System.Drawing.Font("Verdana", 8F);
            this.stLabel3.Location = new System.Drawing.Point(16, 14);
            this.stLabel3.Name = "stLabel3";
            this.stLabel3.Size = new System.Drawing.Size(35, 14);
            this.stLabel3.Text = "HWID";
            this.stLabel3.TextColor = System.Drawing.Color.White;
            this.stLabel3.TextColorBack = System.Drawing.Color.Black;
            // 
            // hwid
            // 
            this.hwid.BackColor = System.Drawing.Color.Transparent;
            this.hwid.Curve = 1;
            this.hwid.Font = new System.Drawing.Font("Verdana", 8F);
            this.hwid.Lines = new string[0];
            this.hwid.Location = new System.Drawing.Point(16, 34);
            this.hwid.MaxLength = 2147483647;
            this.hwid.Multiline = false;
            this.hwid.Name = "hwid";
            this.hwid.ReadOnly = false;
            this.hwid.Size = new System.Drawing.Size(249, 20);
            this.hwid.TabIndex = 2;
            this.hwid.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.hwid.UseSystemPasswordChar = false;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 250);
            this.Controls.Add(this.FreshTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(586, 250);
            this.MinimumSize = new System.Drawing.Size(586, 250);
            this.Name = "Register";
            this.Text = "Register";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FreshTheme1.ResumeLayout(false);
            this.FreshTheme1.PerformLayout();
            this.regAllowed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FreshTheme FreshTheme1;
        private System.Windows.Forms.Panel regAllowed;
        private STLabel stLabel1;
        private SpaceButton regButton;
        private SpaceTextBox regUser;
        private STLabel stLabel2;
        private SpaceTextBox regPass;
        private FreshControlBox_TwoButtons FreshControlBox_TwoButtons1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private STLabel stLabel4;
        private STLabel stLabel3;
        private SpaceTextBox hwid;
    }
}