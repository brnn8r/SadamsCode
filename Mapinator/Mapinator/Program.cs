using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using AutoMapper;

namespace Mapinator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.CreateMap<Widget, Wotzit>()
                .ForMember(d => d.ManufacturedLocation, s => s.MapFrom(f=>f.Factory.Location));

            var widgetFactory = new WidgetFactory("MegaCorp","Tawa");

            var widget = widgetFactory.CreateWidget(1, "nut");

            Debug.WriteLine(widget);

            try
            {
                var wotzit = Mapper.Map<Widget,Wotzit>(widget);
                Debug.WriteLine(wotzit);
            }
            catch (AutoMapperMappingException ame)
            {
                Debug.WriteLine(ame.Message);
            }

            
        }
    }
}
