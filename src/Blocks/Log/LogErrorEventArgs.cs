using System;

namespace Rovidi.Blocks.Log
{
    public class LogErrorEventArgs : EventArgs
    {
        public readonly string Info;

        public readonly Exception Exception;

        public LogErrorEventArgs(string info, Exception ex)
        {
            Info = info;
            Exception = ex;
        }
    }
}
