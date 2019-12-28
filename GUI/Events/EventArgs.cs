using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Events
{
    //enhancing EventArgs class of being Template class, to fit all neede classes
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
    }
}
