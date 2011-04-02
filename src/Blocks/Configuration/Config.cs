using System;
using System.Collections.Generic;
using System.Text;

namespace Rovidi.Blocks.Configuration
{
    public class Config
    {


        #region Properties

        public string Name { get; set; }
        public string Path { get; set; }

        public Type Type { get; set; }
        public DateTime? DtChanged { get; set; }

        public string Value { get; set; }

        #endregion

    }
}
