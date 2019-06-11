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
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string strID = tbxID.Text;//get ID
            string strPswd = tbxPassword.Text;//get password
            //check the ID
            if(strID.Length<=0)
            {
                MessageBox.Show("ID为空！");
                return;
            }
            for (int i=0;i<strID.Length;i++)
            {
                if((strID[i]<'a'&&strID[i]>'z')||(strID[i]<'A'&&strID[i]>'Z')||(strID[i]<'0'&&strID[i]>'9'))
                {
                    MessageBox.Show("ID输入有误，请重新输入！");
                    return;
                }
            }
            
            //check the password
            if(strPswd.Length<=0)
            {
                MessageBox.Show("密码无输入！");
                return;
            }
            else if(strPswd.Length>12)
            {
                MessageBox.Show("密码字符总长度不得超过12！");
                return;
            }
            Form newForm = new MainForm();
            newForm.Show();
            this.Visible = false;
         }
    }
}
