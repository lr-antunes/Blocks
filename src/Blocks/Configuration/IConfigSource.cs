using System;
using System.Collections.Generic;
using Rovidi.Blocks.Core;

namespace Rovidi.Blocks.Configuration
{
    public interface IConfigSource
    {

        #region Methods

        IResult Initialization();


        IResult LoadConfig(string configPath, string configName);

        IResult LoadConfigs(string configPath);


        IResult SaveConfig(List<Config> configs);

        IResult SaveConfig(Config config);

        #endregion

    }
}
