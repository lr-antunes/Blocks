using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace Rovidi.Blocks.Data
{
    public class SQLiteAccess : DBDataAccess
    {

        #region Fields

        private string connectionString;
        private SQLiteConnection dbConnection;

        #endregion
        

        #region Constructors

        public SQLiteAccess()
            : this(null)
        {
        }

        public SQLiteAccess(string connectionString)
        {
            this.Initialization(connectionString);
        }

        #endregion


        #region Private Methods

        private void Initialization(string connectionString)
        {
            SQLiteConnectionStringBuilder connStringBuilder = new SQLiteConnectionStringBuilder();

            if (string.IsNullOrEmpty(connectionString))
            {
                //TODO: Build the connsString from data passed here... (how?)
            }

            connStringBuilder.ConnectionString = connectionString;
        }

        private void InitConnection()
        {
            if (dbConnection == null)
                dbConnection = new SQLiteConnection();
        }


        #endregion


        #region Protected Methods

        public SQLiteCommand GetCommand(CommandType cmdType, string cmdText)
        {
            InitConnection();

            SQLiteCommand cmd = this.dbConnection.CreateCommand();
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;

            return cmd;
        }

        #endregion

    }
}
