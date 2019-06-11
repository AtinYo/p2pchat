namespace ChatChatChat
{
    partial class FormLogIn
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
            this.tbxID = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.linkLabelRegister = new System.Windows.Forms.LinkLabel();
            this.linkLabelHelp = new System.Windows.Forms.LinkLabel();
            this.linkLabelFindPswd = new System.Windows.Forms.LinkLabel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxID
            // 
            this.tbxID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxID.Location = new System.Drawing.Point(122, 77);
            this.tbxID.Name = "tbxID";
            this.tbxID.Size = new System.Drawing.Size(208, 29);
            this.tbxID.TabIndex = 0;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelID.Location = new System.Drawing.Point(74, 80);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(42, 21);
            this.labelID.TabIndex = 2;
            this.labelID.Text = "账号";
            // 
            // tbxPassword
            // 
            this.tbxPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPassword.Location = new System.Drawing.Point(122, 121);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '⚪';
            this.tbxPassword.Size = new System.Drawing.Size(208, 29);
            this.tbxPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(122, 176);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(208, 42);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // linkLabelRegister
            // 
            this.linkLabelRegister.AutoSize = true;
            this.linkLabelRegister.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelRegister.Location = new System.Drawing.Point(118, 232);
            this.linkLabelRegister.Name = "linkLabelRegister";
            this.linkLabelRegister.Size = new System.Drawing.Size(37, 20);
            this.linkLabelRegister.TabIndex = 4;
            this.linkLabelRegister.TabStop = true;
            this.linkLabelRegister.Text = "注册";
            // 
            // linkLabelHelp
            // 
            this.linkLabelHelp.AutoSize = true;
            this.linkLabelHelp.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelHelp.Location = new System.Drawing.Point(293, 232);
            this.linkLabelHelp.Name = "linkLabelHelp";
            this.linkLabelHelp.Size = new System.Drawing.Size(37, 20);
            this.linkLabelHelp.TabIndex = 5;
            this.linkLabelHelp.TabStop = true;
            this.linkLabelHelp.Text = "帮助";
            // 
            // linkLabelFindPswd
            // 
            this.linkLabelFindPswd.AutoSize = true;
            this.linkLabelFindPswd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelFindPswd.Location = new System.Drawing.Point(190, 232);
            this.linkLabelFindPswd.Name = "linkLabelFindPswd";
            this.linkLabelFindPswd.Size = new System.Drawing.Size(65, 20);
            this.linkLabelFindPswd.TabIndex = 6;
            this.linkLabelFindPswd.TabStop = true;
            this.linkLabelFindPswd.Text = "找回密码";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPassword.Location = new System.Drawing.Point(74, 124);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(42, 21);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "密码";
            // 
            // pbxLogo
            // 
            this.pbxLogo.Location = new System.Drawing.Point(-3, -2);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(468, 64);
            this.pbxLogo.TabIndex = 8;
            this.pbxLogo.TabStop = false;
            // 
            // FormLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 261);
            this.Controls.Add(this.pbxLogo);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.linkLabelFindPswd);
            this.Controls.Add(this.linkLabelHelp);
            this.Controls.Add(this.linkLabelRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.tbxID);
            this.MaximizeBox = false;
            this.Name = "FormLogIn";
            this.Text = "登录";
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxID;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linkLabelRegister;
        private System.Windows.Forms.LinkLabel linkLabelHelp;
        private System.Windows.Forms.LinkLabel linkLabelFindPswd;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.PictureBox pbxLogo;
    }
}