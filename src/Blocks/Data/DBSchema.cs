using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Rovidi.Blocks.Data
{
    [XmlRoot("DBSchema")]
    public class DBSchema
    {

        #region Properties

        // Name the application will assume for accessing the database
        [XmlAttribute("Alias")]
        public string Alias { get; set; }

        // Name of the database (can change without change in the application - uses alias, can be keeped forever)
        [XmlAttribute("DBName")]
        public string DBName { get; set; }

        [XmlArray("Tables")]
        [XmlArrayItem("Table")]
        public List<DBSchema.Table> Tables { get; set; }

        #endregion


        #region Internal Classes

        [XmlRoot("Table")]
        internal class Table
        {
            [XmlAttribute("Alias")]
            public string Alias { get; set; }
            [XmlAttribute("Name")]
            public string Name { get; set; }
            [XmlArray("Columns")]
            [XmlArrayItem("Column")]
            List<DBSchema.Column> Columns { get; set; }
        }

        [XmlRoot("Column")]
        internal class Column
        {
            [XmlAttribute("Alias")]
            public string Alias { get; set; }
            [XmlAttribute("Name")]
            public string Name { get; set; }
        }

        #endregion
    }
}
