using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMDUtilities.ObjectExtensions.Converter;
using WMDUtilities.ObjectExtensions.Tracer;
using WMDUtilities.ObjectExtensions.Cloner;

namespace WMDUtilities.ObjectExtensions
{
    public static class ObjectExtender
    {
        public static IConverter<T> Converter<T>(this object o)
        {
            return new Converter<T>(o);
        }

        public static ITracer Tracer(this object o)
        {
            return new DebugTracer(o);
        }

        public static ICloner<T> Cloner<T>(this T o)
        {
            return new SerializingCloner<T>(o);
        }
    }
}
