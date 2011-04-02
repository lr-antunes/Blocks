using System;
using Rovidi.Blocks.Log.LogEntryFilters;

namespace Rovidi.Blocks.Log
{
    public abstract class Logger
    {

        #region Static

        public static event EventHandler<LogErrorEventArgs> LogErrorEvt;

        protected static void OnLogError(Logger logger, string errorMessage, Exception ex)
        {
            if (LogErrorEvt != null)
            {
                try
                {
                    LogErrorEvt(logger, new LogErrorEventArgs(errorMessage, ex));
                }
                catch (Exception) { }
            }
        }

        #endregion

        #region Fields

        private bool isEnable = true;
        private LogEntryFilter entriesFilter;

        #endregion

        #region Properties

        public bool IsEnabled
        {
            get { return isEnable; }
            set { isEnable = value; }
        }

        public LogEntryFilter EntriesFilter
        {
            get { return entriesFilter; }
            set { entriesFilter = value; }
        }

        #endregion

        #region Constructor

        public Logger()
            : base()
        {
            this.EntriesFilter = new DefaultLogEntryFilter();
        }

        #endregion

        #region Private Methods

        private bool ShouldLog(LogEntry logEntry)
        {
            return (this.IsEnabled && EntriesFilter.ShouldLog(logEntry));
        }

        private LogEntry CreateLogEntry(LogSeverity severity, string tag, string logMessage)
        {
            return new LogEntry(severity, tag, logMessage);
        }

        #endregion

        #region Protected Methods

        protected internal bool Log(LogEntry logEntry)
        {
            lock (this)
            {
                try
                {
                    return ShouldLog(logEntry) ? BeforeLog(logEntry) : true;
                }
                catch (Exception ex)
                {
                    OnLogError(this, "", ex);
                    return false;
                }
            }
        }

        protected virtual bool WriteToLog(string strLogEntry)
        {
            return true;
        }

        #endregion

        #region Public Methods

        protected internal virtual bool BeforeLog(LogEntry logEntry)
        {
            // TODO: Include here a Formatter...
            if (logEntry != null)
                return WriteToLog(logEntry.ToString());

            return true;
        }

        #region Log

        public void Log(LogSeverity severity, string logMessage)
        {
            Log(severity, null, logMessage);
        }

        public void Log(LogSeverity severity, string tag, string logMessage)
        {
            Log(CreateLogEntry(severity, tag, logMessage));
        }

        #endregion

        #region Log Debug

        public void LogDebug(string anObject)
        {
            Log(LogSeverity.Debug, anObject);
        }
        public void LogDebug(string tag, string anObject)
        {
            Log(LogSeverity.Debug, tag, anObject);
        }

        #endregion

        #region Log Info

        public void LogInfo(string anObject)
        {
            Log(LogSeverity.Info, anObject);
        }
        public void LogInfo(string tag, string anObject)
        {
            Log(LogSeverity.Info, tag, anObject);
        }

        #endregion

        #region Log Warning

        public void LogWarning(string anObject)
        {
            Log(LogSeverity.Warning, anObject);
        }
        public void LogWarning(string tag, string anObject)
        {
            Log(LogSeverity.Warning, tag, anObject);
        }

        #endregion

        #region Log Error

        public void LogError(string anObject)
        {
            Log(LogSeverity.Error, anObject);
        }
        public void LogError(string tag, string anObject)
        {
            Log(LogSeverity.Error, tag, anObject);
        }

        #endregion

        #region Log Critical

        public void LogCritical(string anObject)
        {
            Log(LogSeverity.Critical, anObject);
        }
        public void LogCritical(string tag, string anObject)
        {
            Log(LogSeverity.Critical, tag, anObject);
        }

        #endregion

        #region Log Fatal

        public void LogFatal(string anObject)
        {
            Log(LogSeverity.Fatal, anObject);
        }
        public void LogFatal(string tag, string anObject)
        {
            Log(LogSeverity.Fatal, tag, anObject);
        }

        #endregion

        #endregion

    }
}