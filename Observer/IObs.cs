using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public interface IObs
    {
        void update();
        void setObservable(IObserved observable);
    }
}
