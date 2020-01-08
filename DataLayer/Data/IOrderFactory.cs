using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    interface IOrderFactory
    {
        Client Client { get; }
        Car Car { get; }
    }
}
