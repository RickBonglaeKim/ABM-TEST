using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebService.Models
{
    [XmlRoot(ElementName = "DeclarationHeader")]
    public class DeclarationHeader
    {
        [XmlElement(ElementName = "Jurisdiction")]
        public string Jurisdiction { get; set; }
        [XmlElement(ElementName = "CWProcedure")]
        public string CWProcedure { get; set; }
        [XmlElement(ElementName = "DeclarationDestination")]
        public string DeclarationDestination { get; set; }
        [XmlElement(ElementName = "DocumentRef")]
        public string DocumentRef { get; set; }
        [XmlElement(ElementName = "SiteID")]
        public string SiteID { get; set; }
        [XmlElement(ElementName = "AccountCode")]
        public string AccountCode { get; set; }
    }

    [XmlRoot(ElementName = "Declaration")]
    public class Declaration
    {
        [XmlElement(ElementName = "DeclarationHeader")]
        public DeclarationHeader DeclarationHeader { get; set; }
        [XmlAttribute(AttributeName = "Command")]
        public string Command { get; set; }
        [XmlAttribute(AttributeName = "Version")]
        public string Version { get; set; }
    }

    [XmlRoot(ElementName = "DeclarationList")]
    public class DeclarationList
    {
        [XmlElement(ElementName = "Declaration")]
        public Declaration Declaration { get; set; }
    }

    [XmlRoot(ElementName = "InputDocument")]
    public class InputDocument
    {
        [XmlElement(ElementName = "DeclarationList")]
        public DeclarationList DeclarationList { get; set; }
    }
}
