using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapinator
{
    class Wotzit
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime ManufacturedDate { get; private set; }
        public string FactoryName { get; private set; }
        public string ManufacturedLocation { get; private set; }

        public Wotzit()
        {
        }

        public Wotzit(int id, string name, DateTime? manufactureDate = null)
        {
            Id = id;
            Name = name;
            ManufacturedDate = manufactureDate ?? DateTime.Now;
        }

        public override string ToString()
        {
            return string.Format("Wotzit:{{Id:{0}, Name:{1}, ManufacturedDate:{2}, FactoryName:{3}, ManufacturedLocation:{4}}}", 
                Id, Name, ManufacturedDate, FactoryName, ManufacturedLocation);
        }
    }
}
