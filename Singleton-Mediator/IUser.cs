using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator_Singleton
{
    interface IUser
    {
        Guid Id { get; }
        IChat Chat { get; }
        String Name { get; }

        void Send(string message);
        void Recieve(string message, IUser sender);
    }
}
