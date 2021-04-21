using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    class Stream : IObserved
    {
        private List<IObs> observers;
        private String streamInfo = "";

        public string StreamInfo
        {
            get { return streamInfo; }
            set 
            { 
                streamInfo = value;
                notifyObservers();
            }
        }

        public Stream()
        {
            observers = new List<IObs>();
        }
        public string getUpdate()
        {
            return StreamInfo;
        }

        public void notifyObservers()
        {
            foreach(var observer in observers)
            {
                observer.update();
            }
        }

        public void subscribe(IObs observer)
        {
            observers.Add(observer);
            observer.setObservable(this);
        }

        public void unsubscribe(IObs observer)
        {
            observers.Remove(observer);
            observer.setObservable(null);
        }
    }
}
