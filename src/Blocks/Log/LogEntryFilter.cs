using System;

namespace Rovidi.Blocks.Log
{
    public abstract class LogEntryFilter
    {

        #region Fields

        private LogSeverity severityLimit = LogSeverity.Debug;

        #endregion

        #region Properties

        public LogSeverity SeverityLimit
        {
            get { return severityLimit; }
            set { severityLimit = value; }
        }

        #endregion

        #region Protected Methods

        protected virtual bool CanLogEntry(LogEntry logEntry)
        {
            return true;
        }

        protected internal bool ShouldLog(LogEntry logEntry)
        {
            if (logEntry == null)
                return CanLogEntry(logEntry);

            return (logEntry.Severity >= SeverityLimit) && CanLogEntry(logEntry);
        }

        #endregion

        #region Constructors

        public LogEntryFilter()
        {

        }

        public LogEntryFilter(LogSeverity severityLimit)
            : this()
        {
            SeverityLimit = severityLimit;
        }

        #endregion

    }
}