using System;

namespace Rovidi.Blocks.Core
{
    public interface IResult
    {

        #region Properties

        int ResultCode { get; set; }

        bool Succeeded { get; }

        string UserMessage { get; set; }

        string SystemMessage { get; set; }

        Exception Exception { get; set; }

        #endregion
    }
}
