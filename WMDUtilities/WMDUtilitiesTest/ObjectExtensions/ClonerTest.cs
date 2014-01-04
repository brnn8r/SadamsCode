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

            Assert.That(clone, Is.EqualTo(i));
            Assert.That(clone, Is.Not.SameAs(i));
        }

        [TestCase("I'll Be Back!")]
        public void TestStringClone(string s)
        {
            string clone = s.Cloner<string>().Clone();

            clone.Tracer().Trace("clone");

            Assert.That(clone, Is.EqualTo(s));
            Assert.That( clone, Is.Not.SameAs(s) );
        }

        [TestCaseSource(typeof(ClonerTestDataFactory), "ArrayCloneTestCases")]
        public void TestArrayClone(string[] strings)
        {
            string[] clone = strings.Cloner<string[]>().Clone();

            clone[0].Tracer().Trace("clone[0]");

            Assert.That(clone, Is.EqualTo(strings));
            Assert.That(clone, Is.Not.SameAs(strings));
        }


    }
}
