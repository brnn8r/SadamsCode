using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSum
{
    internal static class ListExtensions
    {
        internal static T Shift<T>(this IList<T> list)
        {
            if (!list.Any())
            {
                return default(T);
            }

            T t = list.First();

            list.RemoveAt(0);

            return t;
        }

        internal static IEnumerable<T> Shift<T>(this IList<T> list, int numberToShift)
        {          
            var elements = new List<T>();

            for (int i = 0; i < numberToShift; i++)
            {
                elements.Add(list.Shift());
            }

            return elements;

        }
    }
}
