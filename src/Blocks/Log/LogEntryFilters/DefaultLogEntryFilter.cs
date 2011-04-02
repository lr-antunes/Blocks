using System;
using Rovidi.Blocks.Log;

namespace Rovidi.Blocks.Log.LogEntryFilters
{
    public class DefaultLogEntryFilter : LogEntryFilter
    {

        #region Constructors

        public DefaultLogEntryFilter()
            : base()
        {
        }

        #endregion


        #region Protected Methods

        protected override bool CanLogEntry(LogEntry logEntry)
        {
            return true;
        }

        #endregion

    }
}
