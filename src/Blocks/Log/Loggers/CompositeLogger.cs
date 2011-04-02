using System;
using Rovidi.Blocks.Log;
using System.Collections;

namespace Rovidi.Blocks.Log.Loggers
{
    public class CompositeLogger : Logger
    {

        #region Fields

        private Hashtable loggers;

        #endregion


        #region Properties

        public Hashtable Loggers
        {
            get { return loggers; }
        }

        public Logger this[string logName]
        {
            get
            {
                if (loggers.ContainsKey(logName))
                    return (Logger)(this.loggers[logName]);

                return null;
            }
        }

        #endregion


        #region Constructors

        public CompositeLogger()
            : base()
        {

        }

        #endregion


        #region Protected Methods

        protected internal override bool BeforeLog(LogEntry logEntry)
        {
            foreach (var item in this.loggers.Values)
            {
                ((Logger)item).BeforeLog(logEntry);
            }

            return true;
        }

        #endregion


        #region Public Methods

        public bool AddLogger(string loggerName, Logger logger)
        {
            if (string.IsNullOrEmpty(loggerName) || logger == null)
                return false;

            if (this.loggers == null)
                this.loggers = new Hashtable();

            this.loggers.Add(loggerName, logger);

            return true;
        }

        public bool RemoveLogger(string loggerName)
        {
            if (this.loggers != null && this.loggers.ContainsKey(loggerName))
            {
                this.loggers.Remove(loggerName);
                return true;
            }

            return false;
        }

        #endregion

    }
}
