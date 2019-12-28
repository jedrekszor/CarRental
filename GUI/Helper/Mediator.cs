using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Helper
{
    public class Mediator
    {
        static IDictionary<string, List<Action<object>>> _dictionary = new Dictionary<string, List<Action<object>>>();

        static public void Register(string token, Action<object> callback)
        {
            //create new assignment
            if (!_dictionary.ContainsKey(token))
            {
                var list = new List<Action<object>>();
                list.Add(callback);
                _dictionary.Add(token, list);
            }
            else
            {
                bool found = false;
                foreach (var item in _dictionary[token])
                {
                    //searching for command with the same name
                    if(item.Method.ToString() == callback.Method.ToString())
                    {
                        found = true;
                    }
                    if(!found)
                    {
                        _dictionary[token].Add(callback);
                    }
                }
            }
        }

        static public void Unregister(string token, Action<object> callback)
        {
            if (_dictionary.ContainsKey(token))
            {
                _dictionary[token].Remove(callback);
            }
        }

        static public void NotifyColleagues(string token, object args)
        {
            if (_dictionary.ContainsKey(token))
            {
                foreach (var callback in _dictionary[token])
                {
                    callback(args);
                }
            }
        }
    }
}
