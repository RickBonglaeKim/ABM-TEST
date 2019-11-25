using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace XmlDocument
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Parser parser = new Parser("./Docs/XmlSample.xml");
            var mwbRefText = await parser.ParseReferenceAsync("MWB");
            if (mwbRefText != null && mwbRefText.Count > 0)
            {
                foreach (var item in mwbRefText)
                {
                    Console.WriteLine(string.Format(@"RefCode : {0}, RefText : {1}",item.RefCode, item.RefText));
                }
                Console.WriteLine(Environment.NewLine);
            }

            

            var groupRefText = await parser.ParseReferenceAsync(new List<string> { "MWB", "TRV", "CAR" });
            if (groupRefText != null && groupRefText.Count > 0)
            {
                foreach (var item in groupRefText)
                {
                    Console.WriteLine(string.Format(@"RefCode : {0}, RefText : {1}", item.RefCode, item.RefText));
                }
            }

            Console.ReadKey();

        }
    }
}
