using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    class User : IObs
    {
        private String id;
        private IObserved stream;

        public User(string id)
        {
            this.id = id;
        }

        public void setObservable(IObserved observable)
        {
            stream = observable;
        }

        public void update()
        {
            if(stream == null)
            {
                Console.WriteLine(id + "has null topic");
                return;
            }
            String last = stream.getUpdate();
            Console.WriteLine(id + " recived an update: " + last);
        }
    }
}
