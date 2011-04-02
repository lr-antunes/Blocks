using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Rovidi.Blocks.AddIn
{
    [XmlRoot]
    public class AddIn
    {

        #region Fields

        private string id;
        private string name;
        private string author;
        private string version;
        private string namspace;
        private string description;

        private bool defaultEnabled = true;

        private List<AddInDependency> dependencies;

        #endregion


        #region Properties

        [XmlAttribute]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [XmlAttribute]
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        [XmlAttribute]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [XmlAttribute]
        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        [XmlAttribute]
        public string Namespace
        {
            get { return namspace; }
            set { namspace = value; }
        }

        [XmlArray]
        [XmlArrayItem("Dependency")]
        public List<AddInDependency> Dependencies
        {
            get { return dependencies; }
            set { dependencies = value; }
        }

        [XmlAttribute]
        public bool Enabled
        {
            get { return defaultEnabled; }
            set { defaultEnabled = value; }
        }

        #endregion


        #region Constructors

        public AddIn()
        {

        }

        #endregion


        public override string ToString()
        {
            return this.name;
        }
    }
}
