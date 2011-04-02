using System;
using System.Text;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Rovidi.Blocks.Core;

namespace Rovidi.Blocks.Data
{
    public class DBDataAccess : IDBAccess
    {

        #region Fields


        #endregion


        #region Properties

        IDbConnection DBConnection { get; set; }
        string ConnectionString { get; set; }

        #endregion


        #region Constructors

        public DBDataAccess()
        {

        }

        #endregion


        #region Protected Methods

        public virtual IResult ExecuteReader(ref IDataReader dataReader, IDbCommand command)
        {
            IResult result = null;
            DBConnection.ConnectionString = ConnectionString;

            try
            {
                using (DBConnection)
                {
                    DBConnection.Open();
                    command.Connection = DBConnection;

                    dataReader = command.ExecuteReader();
                }
            }
            catch (Exception exc)
            {
                result = new Result(exc, "");
            }
            finally { DBConnection.Close(); }

            return result;
        }


        public virtual IResult ExecuteScalar(ref object queryResult, IDbCommand command)
        {
            IResult result = null;
            DBConnection.ConnectionString = ConnectionString;

            try
            {
                using (DBConnection)
                {
                    DBConnection.Open();
                    command.Connection = DBConnection;

                    queryResult = command.ExecuteScalar();
                }
            }
            catch (Exception exc)
            {
                result = new Result(exc, "");
            }
            finally { DBConnection.Close(); }

            return result;
        }

        public virtual IResult ExecuteNonQuery(ref int queryResult, IDbCommand command)
        {
            IResult result = null;
            DBConnection.ConnectionString = ConnectionString;

            try
            {
                using (DBConnection)
                {
                    DBConnection.Open();
                    command.Connection = DBConnection;

                    queryResult = command.ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                result = new Result(exc, "");
            }
            finally { DBConnection.Close(); }

            return result;
        }

        protected DbCommand GetCommand(DbConnection dbConn, CommandType cmdType, string cmdText)
        {
            DbCommand cmd = dbConn.CreateCommand();
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            return cmd;
        }

        #endregion
    }
}
