using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMDUtilities.ObjectExtensions.Cloner
{
    public interface ICloner<T>
    {
        /// <summary>
        /// Clone method interface 
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>        
        /// <returns>Returns a clone of an object</returns>
        T Clone();
    }
}
