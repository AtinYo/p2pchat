using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatChatChat
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            string strInput;//输入的字符串
            if(tbxInputContent.Text==null)
            {
                MessageBox.Show("输入为空，请重新输入！");
            }
            else
            {
                strInput = tbxInputContent.Text;
                MessageBox.Show("输入字符串为：" + strInput);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(MessageBox.Show("确定要关闭对话框并退出登陆？", "警告", MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                System.Environment.Exit(0);//彻底退出
            }
            else
            {
                return;
            }
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void 关闭并退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 支持开发人员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/AtinYo/p2pchat");
        }
    }
}
