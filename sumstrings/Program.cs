using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sumstrings
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                try
                {
                    Console.WriteLine("The sum of {0} and {1} is {2}", args[0], args[1], StringSum.SumStringsAsString(args[0], args[1]));
                }
                catch(Exception e)
                {
                    Console.WriteLine("There was an error: {0}", e);
                }
            }
            else
            {
                Console.WriteLine("Please enter two numbers consisted of 0 and 1");
            }
        }
    }
}
