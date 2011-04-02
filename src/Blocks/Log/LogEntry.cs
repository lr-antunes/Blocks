using System;

namespace Rovidi.Blocks.Log
{
    public class LogEntry
    {

        #region Fields


        #endregion

        #region Properties

        public DateTime Timestamp { get; set; }
        public LogSeverity Severity { get; set; }

        public string Tag { get; set; }
        public string LogMessage { get; set; }

        #endregion

        #region Constructors

        public LogEntry(LogSeverity severity, string tag, String logMessage)
            : this(severity, tag, logMessage, DateTime.Now)
        {
        }

        public LogEntry(LogSeverity severity, string tag, string logMessage, DateTime logTimestamp)
        {
            Severity = severity;
            LogMessage = logMessage;
            Timestamp = logTimestamp;
            Tag = tag;
        }

        #endregion

        #region Public Methods

        public override String ToString()
        {
            //TODO: this should be done by the default formatter...in BeforeLog method...
            return "[" + Timestamp.ToString("dd/MM/yyyy hh:mm:ss.fff") + "] [" + Severity.ToString("G").ToUpperInvariant() + "] [" + Tag + "] " + LogMessage;
        }

        #endregion

    }
}