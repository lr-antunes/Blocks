using System;
using System.Collections.Generic;
using System.Text;
using Rovidi.Blocks.Core;

namespace Rovidi.Blocks.Configuration
{
    public class ConfigSourceBase : IConfigSource
    {

        #region Constructors

        public ConfigSourceBase()
        {
            Initialization();
        }

        #endregion


        #region IConfigSource Members


        public virtual IResult LoadConfig(string configPath, string configName)
        {
            throw new NotImplementedException();
        }

        public virtual IResult LoadConfigs(string configPath)
        {
            throw new NotImplementedException();
        }

        public virtual IResult SaveConfig(List<Config> configs)
        {
            throw new NotImplementedException();
        }

        public virtual IResult SaveConfig(Config config)
        {
            throw new NotImplementedException();
        }

        public virtual IResult Initialization()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
