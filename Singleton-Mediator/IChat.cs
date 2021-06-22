using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator_Singleton
{
    interface IChat
    {
        void SendMessage(string message, IUser sender);
        void AddUser(IUser user);
    }
}
