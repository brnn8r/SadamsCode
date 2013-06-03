using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMDUtilities.ObjectExtensions.Converter
{
    public interface IConverter<T>
    {
        /// <summary>
        /// Generic type converter
        /// </summary>
        /// <returns>*this* to T</returns>
        T Convert();
    }
}
