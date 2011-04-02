using System;
using System.Xml.Serialization;

namespace Rovidi.Blocks.AddIn
{
    [XmlRoot]
    public class AddInDependency
    {
        [XmlAttribute]
        public string Name { get; set; }
    }
}
