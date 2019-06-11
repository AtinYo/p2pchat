namespace ChatChatChat
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSend = new System.Windows.Forms.Button();
            this.panelFriends = new System.Windows.Forms.Panel();
            this.listBoxFriends = new System.Windows.Forms.ListBox();
            this.lblFriends = new System.Windows.Forms.Label();
            this.tbxInputContent = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblChatContent = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.账号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭并退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.好友管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加好友ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.整理好友ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除好友ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.聊天记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.支持开发人员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.软件版本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHide = new System.Windows.Forms.Button();
            this.panelFriends.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSend.Location = new System.Drawing.Point(546, 41);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(78, 30);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // panelFriends
            // 
            this.panelFriends.Controls.Add(this.listBoxFriends);
            this.panelFriends.Controls.Add(this.lblFriends);
            this.panelFriends.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelFriends.Location = new System.Drawing.Point(12, 40);
            this.panelFriends.Name = "panelFriends";
            this.panelFriends.Size = new System.Drawing.Size(295, 509);
            this.panelFriends.TabIndex = 1;
            // 
            // listBoxFriends
            // 
            this.listBoxFriends.FormattingEnabled = true;
            this.listBoxFriends.ItemHeight = 20;
            this.listBoxFriends.Location = new System.Drawing.Point(3, 85);
            this.listBoxFriends.Name = "listBoxFriends";
            this.listBoxFriends.Size = new System.Drawing.Size(289, 404);
            this.listBoxFriends.TabIndex = 2;
            // 
            // lblFriends
            // 
            this.lblFriends.AutoSize = true;
            this.lblFriends.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFriends.Location = new System.Drawing.Point(3, 66);
            this.lblFriends.Name = "lblFriends";
            this.lblFriends.Size = new System.Drawing.Size(72, 16);
            this.lblFriends.TabIndex = 0;
            this.lblFriends.Text = "好友列表";
            // 
            // tbxInputContent
            // 
            this.tbxInputContent.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxInputContent.Location = new System.Drawing.Point(15, 41);
            this.tbxInputContent.Multiline = true;
            this.tbxInputContent.Name = "tbxInputContent";
            this.tbxInputContent.Size = new System.Drawing.Size(513, 68);
            this.tbxInputContent.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.lblChatContent);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(323, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 378);
            this.panel1.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(15, 90);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(620, 304);
            this.listBox1.TabIndex = 3;
            // 
            // lblChatContent
            // 
            this.lblChatContent.AutoSize = true;
            this.lblChatContent.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblChatContent.Location = new System.Drawing.Point(12, 71);
            this.lblChatContent.Name = "lblChatContent";
            this.lblChatContent.Size = new System.Drawing.Size(72, 16);
            this.lblChatContent.TabIndex = 0;
            this.lblChatContent.Text = "聊天内容";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnHide);
            this.panel2.Controls.Add(this.tbxInputContent);
            this.panel2.Controls.Add(this.btnSend);
            this.panel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(323, 424);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 125);
            this.panel2.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.账号ToolStripMenuItem,
            this.好友管理ToolStripMenuItem,
            this.查看ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 账号ToolStripMenuItem
            // 
            this.账号ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.注销ToolStripMenuItem,
            this.关闭并退出ToolStripMenuItem});
            this.账号ToolStripMenuItem.Name = "账号ToolStripMenuItem";
            this.账号ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.账号ToolStripMenuItem.Text = "账号";
            // 
            // 注销ToolStripMenuItem
            // 
            this.注销ToolStripMenuItem.Name = "注销ToolStripMenuItem";
            this.注销ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.注销ToolStripMenuItem.Text = "注销";
            // 
            // 关闭并退出ToolStripMenuItem
            // 
            this.关闭并退出ToolStripMenuItem.Name = "关闭并退出ToolStripMenuItem";
            this.关闭并退出ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.关闭并退出ToolStripMenuItem.Text = "关闭并退出";
            this.关闭并退出ToolStripMenuItem.Click += new System.EventHandler(this.关闭并退出ToolStripMenuItem_Click);
            // 
            // 好友管理ToolStripMenuItem
            // 
            this.好友管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加好友ToolStripMenuItem,
            this.整理好友ToolStripMenuItem,
            this.删除好友ToolStripMenuItem});
            this.好友管理ToolStripMenuItem.Name = "好友管理ToolStripMenuItem";
            this.好友管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.好友管理ToolStripMenuItem.Text = "好友管理";
            // 
            // 添加好友ToolStripMenuItem
            // 
            this.添加好友ToolStripMenuItem.Name = "添加好友ToolStripMenuItem";
            this.添加好友ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.添加好友ToolStripMenuItem.Text = "添加好友";
            // 
            // 整理好友ToolStripMenuItem
            // 
            this.整理好友ToolStripMenuItem.Name = "整理好友ToolStripMenuItem";
            this.整理好友ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.整理好友ToolStripMenuItem.Text = "整理好友";
            // 
            // 删除好友ToolStripMenuItem
            // 
            this.删除好友ToolStripMenuItem.Name = "删除好友ToolStripMenuItem";
            this.删除好友ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除好友ToolStripMenuItem.Text = "删除好友";
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.聊天记录ToolStripMenuItem});
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            this.查看ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查看ToolStripMenuItem.Text = "查看";
            // 
            // 聊天记录ToolStripMenuItem
            // 
            this.聊天记录ToolStripMenuItem.Name = "聊天记录ToolStripMenuItem";
            this.聊天记录ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.聊天记录ToolStripMenuItem.Text = "消息管理器";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.支持开发人员ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.软件版本ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 支持开发人员ToolStripMenuItem
            // 
            this.支持开发人员ToolStripMenuItem.Name = "支持开发人员ToolStripMenuItem";
            this.支持开发人员ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.支持开发人员ToolStripMenuItem.Text = "支持开发人员";
            this.支持开发人员ToolStripMenuItem.Click += new System.EventHandler(this.支持开发人员ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 软件版本ToolStripMenuItem
            // 
            this.软件版本ToolStripMenuItem.Name = "软件版本ToolStripMenuItem";
            this.软件版本ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.软件版本ToolStripMenuItem.Text = "软件版本";
            // 
            // btnHide
            // 
            this.btnHide.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHide.Location = new System.Drawing.Point(546, 79);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(78, 30);
            this.btnHide.TabIndex = 2;
            this.btnHide.Text = "隐藏";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.BtnHide_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelFriends);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主窗口";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.panelFriends.ResumeLayout(false);
            this.panelFriends.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Panel panelFriends;
        private System.Windows.Forms.Label lblFriends;
        private System.Windows.Forms.TextBox tbxInputContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblChatContent;
        private System.Windows.Forms.ListBox listBoxFriends;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 账号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭并退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 好友管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加好友ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 整理好友ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除好友ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 聊天记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 支持开发人员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 软件版本ToolStripMenuItem;
    }
}

