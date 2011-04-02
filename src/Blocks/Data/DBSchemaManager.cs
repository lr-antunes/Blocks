using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using Rovidi.Blocks.Core;

namespace Rovidi.Blocks.Data
{
    public class DBSchemaManager
    {

        public virtual IResult LoadSchema(ref DBSchema schema, string path)
        {
            IResult result = null;

            if (!File.Exists(path))
                return new Result(new FileNotFoundException("", path), "");



            return result;
        }

        public virtual IResult LoadSchema(ref DBSchema schema, XmlDocument schema)
        {

        }
    }
}
