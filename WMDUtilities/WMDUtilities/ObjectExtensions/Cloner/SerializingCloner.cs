using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WMDUtilities.ObjectExtensions.Cloner
{
    public class SerializingCloner<T> : ICloner<T>
    {
        private object _o;

        public SerializingCloner(object o)
        {
            _o = o;
        }

        public T Clone()        
        {
            if (typeof(T).IsValueType)
            {
                return _o.Converter<T>().Convert();
            }

            if (ReferenceEquals(_o, null))
            {
                return default(T);
            }

            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException(string.Format("Type {0} is not serializable"));
            }

            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();

                formatter.Serialize(stream, _o);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
            
        }
        
    }
}
