using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapinator
{
    interface IWidgetFactory : IFactory
    {
        Widget CreateWidget(int id, string name, DateTime? manufactureDate = null);
    }
}
