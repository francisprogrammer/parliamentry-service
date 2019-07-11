using System;
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

        [XmlElement("Members")]
    }
}