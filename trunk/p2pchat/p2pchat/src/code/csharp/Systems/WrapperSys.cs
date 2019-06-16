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
        private ScriptEngine pyEngine = null;
        private WrapperSys()
        {

        }

        public void Init()
        {
            继续写这里,然后就pywrapper写一写.UI让lida来
            var pyStr = LoadPythonWrapperFromFile();
            pyEngine = Python.CreateEngine(); //脚本引擎
            ScriptScope pyScore = pyEngine.CreateScope(); //脚本上下文变量之类存放处
            var script = pyEngine.CreateScriptSourceFromFile(@"E:\Atin_Py_project\p2pchat\testfordel\test2.py");
            var compiled = script.Compile();
            compiled.Execute(pyScore);

            //pyScore.SetVariable("vauleList", 1);
            //var vauleList = pyScore.GetVariable("vauleList");
            //Console.WriteLine("");
            //pyEngine.Execute(pyStr, pyScore);
            //pyEngine.Operations.Invoke(pyScore.GetVariable("test222"), 2);
            var r = pyEngine.Operations.InvokeMember(pyScore, "test222", 2);
            Console.WriteLine((string)r);
            Console.Read();
        }

        public void Update(double deltaTime)
        {

        }

        public void Destroy()
        {

        }

        static string LoadPythonWrapperFromFile()
        {
            var pyStr = File.ReadAllText(@"E:\Atin_Py_project\p2pchat\testfordel\test2.py", Encoding.UTF8);
            //反正到时候根据c#程序入口去找到需要加入到python的sys的path的路径即可
            //Console.Write(pyStr);
            return pyStr;
        }

        static void Main(string[] args)
        {

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
