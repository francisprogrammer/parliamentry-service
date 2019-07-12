using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PD.Domain
{
    public class Event
    {
        [XmlAttribute]
        public int Id { get; set; }

        [XmlElement("StartDate")]
        public DateTime StartDate { get; set; }

        [XmlElement("StartTime")]
        public string StartTime { get; set; }

        [XmlElement("EndDate")]
        public DateTime EndDate { get; set; }

        [XmlElement("EndTime")]
        public string EndTime { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }
        
        [XmlElement("Type")]
        public string Type { get; set; }
        
        [XmlElement("House")]
        public string House { get; set; }
        
        [XmlElement("Category")]
        public string Category { get; set; }

        [XmlArrayItem("Member", IsNullable=false)]
        [XmlArray("Members")]
        public List<Member> Members { get; set; }
    }
}