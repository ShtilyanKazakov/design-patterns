using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public interface IObserved
    {
        void subscribe(IObs observer);
        void unsubscribe(IObs observer);
        String getUpdate();
        void notifyObservers();
    }
}
