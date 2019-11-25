using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EDIFACT_Message
{
    class Parser
    {
        private readonly string _projectPath;
        private readonly string _filePath;
        public Parser(string filePath)
        {
            _projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
            _filePath = filePath;
        }
        public async Task<List<string[]>> ParseMessageAsync(string segment)
        {
            List<string[]> result = new List<string[]>();
            try
            {
                string[] messageLines = await File.ReadAllLinesAsync(string.Concat(_projectPath, _filePath));
                foreach (var line in messageLines)
                {
                    var lineData = line.Split(@"+");
                    if (lineData[0] == segment)
                    {
                        var array = new string[] { lineData[1], lineData[2] };
                        result.Add(array);
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
