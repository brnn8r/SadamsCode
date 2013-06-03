using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WMDUtilities.ObjectExtensions.Tracer
{
    public interface ITracer
    {
        /// <summary>
        /// Generic tracing interface
        /// </summary>
        /// <param name="s">a string value to trace</param>        
        void Trace(string s = null);
    }
}
