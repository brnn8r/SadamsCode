using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapinator
{
    class Widget
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime ManufacturedDate { get; private set; }
        public IWidgetFactory Factory { get; private set; }

        internal Widget()
        {
        }

        internal Widget(IWidgetFactory myFactory, int id, string name, DateTime? manufactureDate = null)
        {
            Id = id;
            Name = name;
            ManufacturedDate = manufactureDate ?? DateTime.Now;
            Factory = myFactory;
        }

        public override string ToString()
        {
            return string.Format("Widget:{{Id:{0}, Name:{1}, ManufacturedDate:{2}, FactoryName:{3}, FactoryLocation:{4}}}", Id, Name, ManufacturedDate, Factory.Name, Factory.Location);
        }
    }   
}
