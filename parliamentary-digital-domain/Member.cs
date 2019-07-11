using System.Xml.Serialization;

namespace PD.Domain
{
    public class Member
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        
        [XmlElement("Name")]
        public string Name { get; set; }
    }
}