using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator_Singleton
{
    class User : IUser
    {
        public Guid Id { get; private set; }
        public IChat Chat { get; private set; }
        public string Name { get; private set; }

        public void Recieve(string message, IUser sender)
        {
            Console.WriteLine(Name + " recieved message: " + message);
        }

        public void Send(string message)
        {
            Console.WriteLine(Name + " sent message: " + message);
            Chat.SendMessage(message, this);
        }

        public User(IChat chat, string name)
        {
            Id = Guid.NewGuid();

            Chat = chat;
            Name = name;

            Chat.AddUser(this);
        }
    }
}
