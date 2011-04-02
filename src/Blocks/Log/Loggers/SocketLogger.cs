using System;
using System.Net.Sockets;
using Rovidi.Blocks.Log;
using System.IO;

namespace Rovidi.Blocks.Log.Loggers
{
    public class SocketLogger : Logger
    {

        #region Fields

        TcpClient tcpClient;
        Stream socketStream;
        StreamWriter socketWriter;

        #endregion


        #region Properties

        public int Port { get; set; }
        public string HostName { get; set; }

        #endregion


        #region Constructors

        public SocketLogger(string hostName, int port)
            : base()
        {
            this.Port = port;
            this.HostName = hostName;
        }


        ~SocketLogger()
        {
            if (this.socketWriter != null)
                this.socketWriter.Close();

            if (this.socketStream != null)
                this.socketStream.Close();
        }

        #endregion


        #region Protected Methods

        protected internal override bool BeforeLog(LogEntry logEntry)
        {
            try
            {
                WriteToLog(logEntry.ToString());
                return true;
            }
            catch (Exception ex)
            {
                return OnLogFailure(logEntry, ex);
            }
        }

        protected override bool WriteToLog(string strLogEntry)
        {
            this.socketWriter.WriteLine(strLogEntry);
            return true;
        }

        #endregion


        #region Private Methods

        private bool OnLogFailure(LogEntry logEntry, Exception exc)
        {
            ReInitializeSocket();
            try
            {
                WriteToLog(logEntry.ToString());
                return true;
            }
            catch (Exception e)
            {
                OnLogError(this, "Error logging to socket", e);
                return false;
            }
        }

        private void ReInitializeSocket()
        {
            this.tcpClient = new TcpClient(HostName, Port);
            this.socketStream = tcpClient.GetStream();
            this.socketWriter = new StreamWriter(socketStream);
        }

        #endregion

    }
}
