using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlDocument.Models;

namespace XmlDocument
{
    class Parser
    {
        private readonly string _projectPath;
        private readonly XElement _doc;
        public Parser(string filePath)
        {
            _projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())));
            _doc = XElement.Load(string.Concat(_projectPath, filePath));
        }

        public Task<List<Reference>> ParseReferenceAsync(string refCode)
        {
            try
            {
                var result = Task.Factory.StartNew((code) =>
                {
                    string searchCode = (string)code;
                    var references = (
                        from data in _doc.Descendants("Reference")
                        where data.Attribute("RefCode").Value == searchCode
                        select new Reference { RefCode = searchCode, RefText = data.Element("RefText").Value }
                    ).ToList();

                    return references;
                }, refCode);

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        public Task<List<Reference>> ParseReferenceAsync(List<string> refCodes)
        {
            try
            {
                var result = Task.Factory.StartNew((codes) =>
                {
                    List<Reference> references = new List<Reference>();
                    foreach (var data in _doc.Descendants("Reference"))
                    {
                        foreach (var code in (List<string>)codes)
                        {
                            if (data.Attribute("RefCode").Value == code)
                            {
                                references.Add(new Reference { RefCode = code, RefText = data.Element("RefText").Value });
                            }
                        }
                    }
                    return references;
                }, refCodes);

                return result;
            }
            catch (Exception e)
            {
                return null;
            }            
        }
    }
}
