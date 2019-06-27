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
        private ScriptScope pyScore;
        private WrapperSys()
        {

        }

        public void Init()
        {
            //var str = System.AppDomain.CurrentDomain.BaseDirectory;
            //str = System.Windows.Forms.Application.StartupPath;
            DirectoryInfo info = new DirectoryInfo(System.Windows.Forms.Application.StartupPath);

            String path = info.Parent.Parent.FullName;
            var pyStr = LoadPythonWrapperFromFile(path + @"\src\code\py\pymain.py");

            pyEngine = Python.CreateEngine(); //脚本引擎
            var paths = pyEngine.GetSearchPaths();
            paths.Add(path + @"\src\code\py\");
            pyEngine.SetSearchPaths(paths);
            pyScore = pyEngine.CreateScope(); //脚本上下文变量之类存放处
            var script = pyEngine.CreateScriptSourceFromString(pyStr);
            var compiled = script.Compile();
            compiled.Execute(pyScore);

            CallPyMethod("init");
            //object v = GetPyValue("a");
            //SetPyValue("a", 12+"a");
            //v = GetPyValue("a");
            //v = CallPyMethod("update", 1, "s");
            //v = CallPyMethod("start");
            
        }

        public void Update(double deltaTime)
        {
            CallPyMethod("update", deltaTime);
        }

        public void Destroy()
        {

        }

        private string LoadPythonWrapperFromFile(string path)
        {
            var pyStr = File.ReadAllText(path, Encoding.UTF8);
            return pyStr;
        }

        public object CallPyMethod(string methodName, params object[] parameters)
        {
            if (!String.IsNullOrEmpty(methodName))
            {
                return pyEngine.Operations.Invoke(pyScore.GetVariable(methodName) as object, parameters);
            }

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

        public object GetPyValue(string valueName)
        {
            if (!String.IsNullOrEmpty(valueName) && pyScore != null)
            {
                //通过 CreateScope 的scope去读取变量
                return pyScore.GetVariable(valueName);
            }
            return null;
        }

        public void SetPyValue(string valueName, object value)
        {
            if (!String.IsNullOrEmpty(valueName) && pyScore != null)
            {
                //通过 CreateScope 的scope去设置变量
                pyScore.SetVariable(valueName, value);
            }
        }
    }
}
