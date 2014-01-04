using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapinator
{
    interface IFactory
    {
        string Name { get; }
        string Location { get; }
    }
}
