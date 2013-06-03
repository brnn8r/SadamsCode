using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WMDUtilities.ObjectExtensions.Converter
{
    public class Converter<T> : IConverter<T>
    {
        protected object _o;

        public Converter(object o)
        {
            _o = o;
        }

        public T Convert()
        {
            if (_o is T)
            {
                return (T)_o;
            }            

            if (ReferenceEquals(_o, null))
            {
                return default(T);
            }

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            return (T)converter.ConvertFrom(_o);
            
        }
    }
}
