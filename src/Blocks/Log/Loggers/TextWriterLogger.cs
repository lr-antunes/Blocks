using System;
using Rovidi.Blocks.Log;
using System.IO;

namespace Rovidi.Blocks.Log.Loggers
{
    public class TextWriterLogger : Logger
    {

        #region Properties

        public TextWriter Writer { get; set; }

        #endregion


        #region Constructors

        public TextWriterLogger()
            : base()
        {

        }

        public TextWriterLogger(TextWriter writer)
            : this()
        {
            Writer = writer;
        }

        #endregion


        #region Protected Methods

        protected override bool WriteToLog(string strLogEntry)
        {
            try
            {
                Writer.WriteLine(strLogEntry);
                return true;
            }
            catch (Exception exc)
            {
                OnLogError(this, "Error writing to log.", exc);
                throw;
            }
        }

        #endregion

    }
}
