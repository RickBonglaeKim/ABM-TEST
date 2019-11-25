using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDIFACT_Message
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Parser parser = new Parser(@"./Docs/Edifact.txt");
            List<string[]> resultData = await parser.ParseMessageAsync("LOC");

            if (resultData != null)
            {
                foreach (var data in resultData)
                {
                    Console.WriteLine(string.Format("2nd data : {0}, 3rd data : {1}", data[0], data[1]));
                }
            }
            else
            {
                Console.WriteLine("parsing error.");
            }
            

            Console.ReadKey();
        }
    }
}
