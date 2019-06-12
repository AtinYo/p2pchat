using Core.src.CommonInterface;
using Core.src.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatChatChat.src.code.csharp.Systems
{
    public class WrapperSys : TSingleton<SystemManager>, ISystem
    {
        public void Init()
        {
            这里接入ironpython
            throw new NotImplementedException();
        }

        public void Update(double deltaTime)
        {
            throw new NotImplementedException();
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
