using System;
using Rovidi.Blocks.Log;
using System.IO;

namespace Rovidi.Blocks.Log.Loggers
{
    public class FileLogger : Logger
    {

        #region Fields


        #endregion


        #region Properties

        public string LogFilePath { get; set; }

        #endregion


        #region Constructor

        public FileLogger()
            : base()
        {

        }


        public FileLogger(string logFilePath)
            : this()
        {
            LogFilePath = logFilePath;
        }

        #endregion


        #region Protected Methods


        private FileStream GetFileStream()
        {
            var LogDirPath = (new FileInfo(LogFilePath)).DirectoryName;

            if (!Directory.Exists(LogDirPath))
                Directory.CreateDirectory(LogDirPath);

            return new FileStream(LogFilePath, FileMode.Append);
        }


        protected override bool WriteToLog(String s)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(GetFileStream()))
                {
                    writer.WriteLine(s);
                }
            }
            catch (Exception)
            {
                //OnLoggingError(this, "Error writing to file", ex);
                return false;
            }

            return true;
        }

        #endregion
    }
}
