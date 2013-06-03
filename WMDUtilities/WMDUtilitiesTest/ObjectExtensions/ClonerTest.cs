using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WMDUtilities.ObjectExtensions;
using WMDUtilitiesTest.TestData;

namespace WMDUtilitiesTest.ObjectExtensions
{
    [TestFixture]
    public class ClonerTest    
    {
        [TestCase(82)]
        public void TestIntegerClone(int i)
        {
            int clone = i.Cloner<int>().Clone();

            clone.Tracer().Trace("clone");

            Assert.AreEqual(clone, i);
            Assert.IsFalse(ReferenceEquals(clone, i));
        }
        [TestCase("I'll Be Back!")]
        public void TestStringClone(string s)
        {
            string clone = s.Cloner<string>().Clone();

            clone.Tracer().Trace("clone");

            Assert.AreEqual(clone, s);
            Assert.IsFalse(ReferenceEquals(clone, s));
        }
    }
}
