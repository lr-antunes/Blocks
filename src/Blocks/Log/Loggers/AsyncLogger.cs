using System;
using Rovidi.Blocks.Log;
using System.Collections.Generic;
using System.Threading;

namespace Rovidi.Blocks.Log.Loggers
{
    public class AsyncLogger : Logger
    {

        #region Static

        private static Thread LogWorkerThread { get; set; }
        private static AutoResetEvent ThreadSignal { get; set; }
        private static List<KeyValuePair<Logger, LogEntry>> LogQueue { get; set; }

        static AsyncLogger()
        {
            ThreadSignal = new AutoResetEvent(false);
            LogQueue = new List<KeyValuePair<Logger, LogEntry>>();

            LogWorkerThread = new Thread(new ThreadStart(LogWorker))
            {
                Name = "Asynchronous Logger",
                IsBackground = true
            };

            LogWorkerThread.Start();
        }


        private static void LogWorker()
        {
            while (true)
            {
                ThreadSignal.WaitOne();
                List<KeyValuePair<Logger, LogEntry>> logEntriesQueue = null;
                lock (LogQueue)
                {
                    logEntriesQueue = new List<KeyValuePair<Logger, LogEntry>>(LogQueue); //LogQueue.ToList();
                    LogQueue.Clear();
                }
                foreach (KeyValuePair<Logger, LogEntry> kv in logEntriesQueue)
                {
                    try
                    {
                        kv.Key.Log(kv.Value);
                    }
                    catch (Exception ex)
                    {
                        OnLogError(kv.Key, "Asynchronous Logger error.", ex);
                    }
                }
            }
        }

        #endregion


        #region Properties

        public Logger Logger { get; set; }

        #endregion


        #region Constructors

        public AsyncLogger(Logger logger)
            : base()
        {
            Logger = logger;
        }

        #endregion


        #region Protected Methods

        protected internal override bool BeforeLog(LogEntry logEntry)
        {
            lock (LogQueue)
            {
                LogQueue.Add(new KeyValuePair<Logger, LogEntry>(this.Logger, logEntry));
            }
            ThreadSignal.Set();
            return true;
        }

        #endregion

    }
}
