using Core.CommonInterface;
using System;
using System.Collections.Generic;
using System.Text;
using IronPython.Hosting;
using System.IO;
using Microsoft.Scripting.Hosting;

namespace ChatChatChat.src.code.csharp.Systems
{
    public class WrapperSys : TSingleton<WrapperSys>, ISystem
    {
        private ScriptEngine pyEngine;
        private WrapperSys()
        {

        }

        public void Init()
        {
            int a = 1;
            var str = System.AppDomain.CurrentDomain.BaseDirectory;
            str = System.Windows.Forms.Application.StartupPath;
            DirectoryInfo info = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);

            String path = info.Parent.Parent.FullName;
            var pyStr = LoadPythonWrapperFromFile(path + @"\src\code\py\pymain.py");

            pyEngine = Python.CreateEngine(); //脚本引擎
            ScriptScope pyScore = pyEngine.CreateScope(); //脚本上下文变量之类存放处
            var script = pyEngine.CreateScriptSourceFromString(pyStr);
            var compiled = script.Compile();
            compiled.Execute(pyScore);

            //pyScore.SetVariable("vauleList", 1);
            //var vauleList = pyScore.GetVariable("vauleList");
            //Console.WriteLine("");
            //pyEngine.Execute(pyStr, pyScore);
            //pyEngine.Operations.Invoke(pyScore.GetVariable("test222"), 2);
            //var r = pyEngine.Operations.InvokeMember(pyScore, "test222", 2);
        }

        public void Update(double deltaTime)
        {

        }

        public void Destroy()
        {

        }

        private string LoadPythonWrapperFromFile(string path)
        {
            var pyStr = File.ReadAllText(path, Encoding.UTF8);
            return pyStr;
        }

        static object CallPyMethod(List<object> paramList)
        {
            //下面是自己的例子
            //pyEngine.Operations.Invoke(pyScore.GetVariable("test222"), 2);

            //或者这样写
            //var pythonWrapper = pyScore.GetVariable("pythonWrapper");
            //pyEngine.Operations.InvokeMember(pythonWrapper, "test222", 2);

            //又或者这样
            // pyEngine.Operations.InvokeMember(pyScore, "test222", 2);


            //这个直接访问一个Python的Wrapper,然后通过Wrapper返回值
            //    public void CallMethod(string method, params dynamic[] arguments)
            //{
            //    engine.Operations.InvokeMember(pythonClass, method, arguments);
            //}

            //public dynamic CallFunction(string method, params dynamic[] arguments)
            //{
            //    return engine.Operations.InvokeMember(pythonClass, method, arguments);
            //}
            return null;
        }

        static object GetPyValue()
        {
            //通过 CreateScope 的scope去读取变量
            // var vauleList = pyScore.GetVariable("vauleList");
            return null;
        }

        static void SetPyValue()
        {
            //pyScore.SetVariable("vauleList", 1);
        }
    }
}
