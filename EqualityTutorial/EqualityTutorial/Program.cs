using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Area a45 = new Area(4, 5);
            object b45 = new Area(4, 5);
            Area c47 = new Area(4, 7);
            Area d210 = new Area(2, 10);

            bool result;

            result = a45.Equals(b45);
            result = a45 == (Area)b45;
            result = a45.Equals(c47);
            result = a45 != c47;

            int a45Hashcode = a45.GetHashCode();
            int b45Hashcode = b45.GetHashCode();
            int c47Hashcode = c47.GetHashCode();
            int d210Hashcode = d210.GetHashCode();

            result = a45.Equals(d210);
        }
    }
}
