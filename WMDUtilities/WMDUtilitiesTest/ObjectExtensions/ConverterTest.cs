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
    public class ConverterTest
    {

        private int IntegerConvertTest(string s)
        {
            "test".Tracer().Trace();

            int parsedValue = 0;

            int.TryParse(s, out parsedValue);

            parsedValue.Tracer().Trace("parsedValue");

            int convertedValue = s.Converter<int>().Convert();

            convertedValue.Tracer().Trace("convertedValue");

            return convertedValue;
        }

        [TestCase("82")]
        [TestCase("0")]
        [TestCase("-123")]        
        public void TestValidStringToIntger(String stringInt)
        {
            IntegerConvertTest(stringInt);
        }

        [TestCase("ABC")]
        [ExpectedException(typeof(Exception))]
        public void TestInValidStringToIntger(string badString)
        {
            IntegerConvertTest(badString);
        }

        [TestCase("6 February 1982")]
        public void TestStringToDate(string testDate)
        {
            DateTime parsedDate;
            DateTime.TryParse(testDate, out parsedDate);

            parsedDate.Tracer().Trace("parsedDate");

            DateTime dt = testDate.Converter<DateTime>().Convert();
            dt.Tracer().Trace("dt");

            Assert.AreEqual(parsedDate, dt);
        }
        
        public void TestDateToDate(DateTime testDate)
        {
            testDate = DateTime.Today;

            DateTime dt = testDate.Converter<DateTime>().Convert();
            dt.Tracer().Trace("dt");

            Assert.AreEqual(testDate, dt);
        }

        private TrafficLight TrafficLightConversionTest(string testLight)
        {
            TrafficLight tl = testLight.Converter<TrafficLight>().Convert();

            tl.Tracer().Trace("tl");

            return tl;
            
        }

        [TestCase("Red")]
        [TestCase("Orange")]
        [TestCase("Green")]
        public void TestStringToEnum(string testLight)
        {
            TrafficLight tl = TrafficLightConversionTest(testLight);

            TrafficLight parsedLight;
            Assert.IsTrue(Enum.TryParse(testLight, out parsedLight));
        }
        
        [TestCase("Black")]
        [ExpectedException(typeof(FormatException))]
        public void TestStringToEnumException(string testLight)
        {
            TrafficLight tl = TrafficLightConversionTest(testLight);

            TrafficLight parsedLight;

            Assert.IsTrue(Enum.TryParse(testLight, out parsedLight));
            
        }
    }
}
