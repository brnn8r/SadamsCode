using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMDUtilitiesTest.TestData
{
    class ClonerTestDataFactory
    {
        public static IEnumerable<string[]> ArrayCloneTestCases
        {
            get
            {
                yield return new[] { "1", "2", "3", "82" };
            }
        }
    }
}
