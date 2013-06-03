using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WMDUtilities.ObjectExtensions.Tracer
{
    public class DebugTracer : ITracer 
    {
        protected object _o;

        public DebugTracer(object o)
        {
            _o = o;
        }
        
        public void Trace(string s = null)
        {
#if DEBUG
            var output = string.Format("{0}{1}::{2}:{3}{4}", Environment.NewLine,new StackTrace().GetFrame(1).GetMethod().Name,
                s, _o,  Environment.NewLine);
          
            Debug.WriteLine(output);
            Console.WriteLine(output);
#endif
        }
    }
}
