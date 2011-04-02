using System;
using Rovidi.Blocks.Core;
using Rovidi.Blocks.Log;
using System.Collections.Generic;
using Rovidi.Blocks.App.Arguments;

namespace Rovidi.Blocks.App
{
    public interface IApp
    {
        #region Properties

        IResult AppResult { get; set; }

        AppInfo AppInfo { get; set; }

        Logger AppLog { get; set; }

        IAppConfig AppConfig { get; set; }

        List<AppArgument> AppArguments { get; set; }

        #endregion


        #region Public Methods

        void Initialization();
        void OnInitialized();

        IResult Run();
        void OnExecuted();

        void ShutDown();

        #endregion
    }
}
