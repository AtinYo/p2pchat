using ChatChatChat.src.code.csharp.Logger;
using ChatChatChat.src.code.csharp.ProgramMain;
using ChatChatChat.src.code.csharp.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ChatChatChat.src.code.csharp.ProgramMain
{
    public static class ProgramMain
    {
        public static void Init()
        {
            InitExceptionHandler();//初始化异常处理

            InitTimer();//初始化timer用于update

            InitAllSystem();
        }

        #region ExceptionHandler异常处理
        public static void InitExceptionHandler()
        {
            //异常处理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常   
            Application.ThreadException += ApplicationThreadException;
            //处理非UI线程异常   
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        }

        public static void ApplicationThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Logger.Logger.Log(e.Exception);
            MessageBox.Show("Error occurs!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }

        static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Logger.Log(e.ExceptionObject as Exception);
            MessageBox.Show("Error occurs!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(0);
        }
        #endregion

        #region Timer定时器
        private static System.Timers.Timer timer;
        private static DateTime lastDateTime;
        private static void InitTimer()
        {
            // Create a timer with a 500ms interval. (0.5秒一次)
            timer = new System.Timers.Timer(500);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            lastDateTime = DateTime.Now;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (SystemManager.HasInit)
            {
                var deltaTime = e.SignalTime - lastDateTime;
                lastDateTime = e.SignalTime;
                SystemManager.Instance.Update(deltaTime.TotalMilliseconds);
            }
        }
        #endregion

        #region SystemInit 系统初始化
        static void InitAllSystem()
        {
            SystemManager.Instance.Init();
        }
        #endregion
    }
}
