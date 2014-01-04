using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapinator
{
    class WidgetFactory : IWidgetFactory
    {
        public string Name { get; private set; }
        public string Location { get; private set; }

        public WidgetFactory(string name, string location)
        {
            Name = name;
            Location = location;
        }

        public Widget CreateWidget(int id, string name, DateTime? manufactureDate = null)
        {
            return new Widget(this, id, name, manufactureDate);
        }
    }
}
