using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mediator_Singleton
{
    class ChatBot : IUser
    {
        #region singleton
        private static ChatBot instance;
        private static readonly object threadLock = new object();
        public static ChatBot Instance
        {
            get
            {
                lock (threadLock)
                {
                    if (instance == null)
                    {
                        instance = new ChatBot("WordFilterBot");
                    }
                    return instance;
                }
            }
        }
        #endregion
        public Guid Id { get; private set; }
        public IChat Chat { get; private set; }
        public string Name { get; private set; }
        public List<string> BadWords { get; set; }

        public void Recieve(string message, IUser sender)
        {
            foreach (String word in BadWords)
            {
                if (message.Contains(word))
                {
                    Send("!kick " + sender.Id);
                    Send("Kicked " + sender.Name + " for saying bad word: " + word);
                }
            }
        }

        public void Send(string message)
        {
            if (Chat == null)
            {
                Debug.Write("Chat is null");
                return;
            }
            Console.WriteLine(Name + " sent message: " + message);
            Chat.SendMessage(message, this);
        }

        public void SetChat(IChat chat)
        {
            Chat = chat;
            Chat.AddUser(this);
        }

        ChatBot(string name)
        {
            Id = Guid.NewGuid();

            Name = name;
        }
    }
}
