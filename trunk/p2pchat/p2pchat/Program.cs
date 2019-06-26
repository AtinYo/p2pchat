using Core;
using Core.Logger;
using p2pchat.src.code.csharp.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace p2pchat
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                ProgramMain.Init();
                Start();
            }
            catch (Exception e)
            {
                Logger.Log(e);
                MessageBox.Show("Error occurs!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        static void Start()
        {
            //下面找个事件做成UI架构的调用
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainPanel());
        }
    }
}
