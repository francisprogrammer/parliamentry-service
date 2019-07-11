using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PD.Domain
{
    [Serializable]
    [XmlRoot("ArrayOfEvent")]
    public class Events
    {
        [XmlElement("Event")]
        public List<Event> Event { get; set; }
    }
}