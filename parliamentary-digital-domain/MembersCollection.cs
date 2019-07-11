using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PD.Domain
{
    [Serializable]
    [XmlRoot("Members")]
    public class MembersCollection
    {
        [XmlElement("Member")]
        public MemberDetails MemberDetails { get; set; }
    }
}