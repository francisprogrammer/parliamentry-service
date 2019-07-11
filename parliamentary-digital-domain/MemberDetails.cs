using System.Xml.Serialization;

namespace PD.Domain
{
    public class MemberDetails
    {
        [XmlAttribute("Member_Id")]
        public int Id { get; set; }
        
        [XmlElement("Party")]
        public string Party { get; set; }
        
        [XmlElement("MemberFrom")]
        public string MemberFrom { get; set; }
        
        [XmlElement("FullTitle")]
        public string FullTitle { get; set; }
    }
}