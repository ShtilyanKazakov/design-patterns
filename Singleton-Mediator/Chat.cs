using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Mediator_Singleton
{
    class Chat : IChat
    {
        public List<string> WordsBlacklist { get; private set; }

        private List<IUser> users;
        private List<IUser> admins;
        private List<IUser> toKick;

        private int depth = 0;

        public Chat(List<string> blacklistedWords)
        {
            users = new List<IUser>();
            admins = new List<IUser>();
            toKick = new List<IUser>();

            WordsBlacklist = blacklistedWords;
        }

        private void SendMessage(string message)
        {
            depth++;
            Debug.WriteLine(depth);

            foreach (IUser user in users)
            {
                user.Recieve(message, null);
            }

            KickDepthCheck();
        }

        public void SendMessage(string message, IUser sender)
        {
            if (!users.Contains(sender))
            {
                sender.Recieve("You are not registered in the chat!", null);
                return;
            }

            if (CommandFilter(message, sender)) return;

            depth++;
            Debug.WriteLine(depth);

            foreach (IUser user in users)
            {
                if (user == sender) continue;
                user.Recieve(message, sender);
            }

            KickDepthCheck();
        }

        private bool CommandFilter(string message, IUser sender)
        {
            string[] para = message.Split(' ');
            switch (para[0])
            {
                case "!addBot":
                    AddBot();
                    return true;

                case "!kick":
                    if (!admins.Contains(sender))
                    {
                        sender.Recieve("You don't have permissions to use command: " + para[0], null);
                        return true;
                    }
                    ToKick(para[1]);
                    return true;

                default:
                    break;
            }
            return false;
        }
        public void AddUser(IUser user)
        {
            users.Add(user);
        }

        private void AddBot()
        {
            ChatBot bot = ChatBot.Instance;
            if (admins.Contains(bot))
            {
                SendMessage("Bot has already been added");
                return;
            }
            SendMessage("Adding Bot");
            bot.SetChat(this);
            bot.BadWords = WordsBlacklist;
            admins.Add(bot);
        }

        private void ToKick(string guid)
        {
            Guid id = Guid.Parse(guid);
            IUser user = users.Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
            {
                Debug.WriteLine("User to kick: " + user.Name);
                if (admins.Contains(user)) return;
                toKick.Add(user);
            }
        }

        private void KickDepthCheck()
        {
            if (depth == 1)
            {
                Kick();
            }
            depth--;
        }

        private void Kick()
        {
            foreach (IUser user in toKick)
            {
                try
                {
                    users.Remove(user);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }

            toKick.Clear();
        }
    }
}
