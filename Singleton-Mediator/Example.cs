using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator_Singleton
{
    class Example
    {
        static void Main(string[] args)
        {
            List<string> blacklistedWords = new List<string>();
            blacklistedWords.Add("cat");
            Chat chat = new Chat(blacklistedWords);

            User u1 = new User(chat, "Stoyan");
            User u2 = new User(chat, "Martin");
            User u3 = new User(chat, "Petar");

            u1.Send("Hello!");
            u1.Send("What's happening.");
            u1.Send("I'm just playing with my cat.");
            u2.Send("Woah, you can't say that word");
            u2.Send("I'll fix it.");
            u2.Send("!addBot");
            u3.Send("You can't say cat?");
            u3.Send("Wait did I get kicked?");
            u1.Send("!addBot");
            u2.Send("!kick asdsa");
        }
    }
}
