using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Models
{
    [XmlRoot(ElementName = "Items")]
    public class SecurityInfo
    {
        public const string FileName = "Securities.xml";

        private static Lazy<SecurityInfo> _securities = new Lazy<SecurityInfo>(Load);

        public static IEnumerable<SecurityModel> SecurityItems = _securities.Value.SecurityModels;

        public static SecurityInfo Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SecurityInfo));

            using (XmlReader stream = XmlReader.Create(new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName), FileMode.Open, FileAccess.Read)))
            {
                return serializer.Deserialize(stream) as SecurityInfo;
            }
        }

        [XmlElement(ElementName = "SecurityModel")]
        public Collection<SecurityModel> SecurityModels { get; set; }
    }
}
