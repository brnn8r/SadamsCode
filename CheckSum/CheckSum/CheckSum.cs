using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Ninject;

namespace CheckSum
{
    class CheckSum
    {

        static readonly string commandlinePattern = @"^\s*\-f\s+([^\s]+)(\s+\-a\s+([^\s]+))?(\s+\-e\s*([^\s]+))?$";    

        static int Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<ICheckSumGenerator>().To<SHA1CheckSumGenerator>();

            var commandlineString = string.Join(" ",args);

            var commandLineRegEx = new Regex(commandlinePattern);

            IEnumerable<Match> matches = commandLineRegEx.Matches(commandlineString).Cast<Match>();
            if (!matches.Any())
            {
                Usage();
            }

            IEnumerable<GroupCollection> groupCollections = matches.Select(m => m.Groups).Cast<GroupCollection>();            

            var groups = new List<String>();
            foreach (GroupCollection gc in groupCollections)
            {
                for (int i = 0; i < gc.Count; i++)
                {
                    if(!String.IsNullOrWhiteSpace(gc[i].Value)) groups.Add(gc[i].Value);
                }
            }

            //The first group is the whole match or the commandline itself so remove it.            
            groups.Shift();
            //The file name *should* be the first element now
            var fileName = groups.Shift();
            var algorithm = groups.Shift(2).LastOrDefault();

            var expectedCheckSum = groups.Shift(2).LastOrDefault();
            

            Debug.WriteLine(fileName);

            var generator = kernel.Get<ICheckSumGenerator>();

            string checkSum = generator.ComputeCheckSum(File.ReadAllBytes(fileName));

            Console.WriteLine(checkSum);
            Debug.WriteLine(checkSum);
      
            return 0;
        }

        static void Usage()
        {
            var usageMessage = String.Format("{0}.exe -f {{File}} [-a {{Alogorithm, default:SHA1}}, -e {{ExpectedValue}}]", Assembly.GetExecutingAssembly().GetName().Name);
            Console.WriteLine(usageMessage);
            Debug.WriteLine(usageMessage);
        }
    }
}
