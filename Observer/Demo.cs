using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public class Demo
    {
        public static void Main(String[] args)
        {
            Stream stream1 = new Stream();

            User user1 = new User("sub1");
            User user2 = new User("sub2");
            User user3 = new User("sub3");

            stream1.subscribe(user1);
            stream1.subscribe(user2);
            stream1.subscribe(user3);


            stream1.StreamInfo = "Going live soon!";
            Console.WriteLine("------------------------------------------");
            stream1.StreamInfo = "Art tutorials";
            Console.WriteLine("------------------------------------------");

            stream1.unsubscribe(user1);

            stream1.StreamInfo = "Joe Biden is USA president";
        }
    }
}
