using System;

namespace Rovidi.Blocks.Core
{
    public class Result : IResult
    {

        #region Fields

        private const int EXCEPTION_RESULT_CODE = -1;

        #endregion


        #region Properties

        public virtual int ResultCode { get; set; }

        public virtual string UserMessage { get; set; }

        public virtual string SystemMessage { get; set; }

        public Exception Exception { get; set; }

        public virtual bool Succeeded { get { return (ResultCode >= 0); } }

        #endregion


        #region Constructors

        public Result(int resultCode)
        {
            this.ResultCode = resultCode;
        }

        public Result(int resultCode, string message)
            : this(resultCode)
        {
            this.UserMessage = message;
        }

        public Result(Exception exception, string message)
            : this(EXCEPTION_RESULT_CODE)
        {
            this.UserMessage = message;
            this.Exception = exception;
            this.SystemMessage = (exception != null) ? exception.Message : "";
        }

        #endregion

    }
}
