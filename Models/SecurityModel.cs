using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Models
{
    [Serializable]
    public class SecurityModel
    {
        [XmlAttribute]
        public string Symbol { get; set; }

        [XmlAttribute]
        public string Description { get; set; }
        
        [XmlAttribute]
        public string Type { get; set; }

        [XmlAttribute]
        public string Exchange { get; set; }
    }
}
