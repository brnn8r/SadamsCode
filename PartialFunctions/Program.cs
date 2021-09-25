using System;
using System.Linq;
using System.Collections.Generic;

namespace PartialFunctions
{
    class Program
    {

        static void Main(string[] args)
        {

            Program p = new Program();

            var numbers = new List<Decimal> { 1.0M, 2.0M, 4.0M, 8.0M };

            var double_numbers = numbers.Select(p.multiplyBy2);

            Console.WriteLine($"Hello World! {String.Join(",", double_numbers)}");
        }

        private Func<Decimal, Decimal> multiplyBy2 = (x) => multiply(1M, 2M, x);

        private static Decimal multiply(Decimal a, Decimal b, Decimal c)
        {
            return a * b * c;
        }
    }
}
