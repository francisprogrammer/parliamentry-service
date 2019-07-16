using System.IO;
using System.Xml.Serialization;

namespace PD.Services.Tasks.GetParliamentData
{
    public static class XmlConvert
    {
        public static T DeserializeObject<T>(string content)
        {
            var xmlSerialize = new XmlSerializer(typeof(T));
            return (T) xmlSerialize.Deserialize(new StringReader(content));
        }
    }
}