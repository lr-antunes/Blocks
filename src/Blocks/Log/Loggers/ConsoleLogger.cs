using System;
using Rovidi.Blocks.Log;

namespace Rovidi.Blocks.Log.Loggers
{
    public class ConsoleLogger : TextWriterLogger
    {

        #region Constructors

        public ConsoleLogger()
            : base(Console.Out)
        {

        }

        #endregion

    }
}
