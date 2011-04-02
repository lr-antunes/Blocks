using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rovidi.Blocks.Configuration.ConfigSources;
using Rovidi.Blocks.Core;
using System.Data.SQLite;
using System.Data;
using Rovidi.Blocks.Configuration;

#warning LA: THIS ALL CLASS BELONG TO THE APPLICATION MOOSIC!!!!! MOVE THIS!!! (CHANGE THE NAMESPACE)

namespace Rovidi.Blocks.Data
{
    public class MoosicConfigSource : DBConfigSource
    {

        #region Fields

        private SQLiteAccess dbAccess;

        #endregion



        #region Properties



        #endregion



        #region Constructors

        public MoosicConfigSource()
            : base()
        {

        }

        #endregion


        #region Public Methods

        public override IResult Initialization()
        {
            this.dbAccess = new SQLiteAccess();

            return new Result(1);
        }

        /**
         *   Here we know the structure of the database...this is application code, not Blocks !!!
         **/
        //TODO: we can find a way to automatically create the queries for this app, knowing the DB Schema... (for later :P)

        public override IResult LoadConfig(ref Config config, string configPath, string configName)
        {
            IResult result = null;

            SQLiteCommand cmd = dbAccess.GetCommand(CommandType.Text, "SELECT * FROM Config WHERE Path = @path AND Name = @name");
            cmd.Parameters.Add(new SQLiteParameter("@path", configPath));
            cmd.Parameters.Add(new SQLiteParameter("@name", configName));

            IDataReader reader = null;

            result = dbAccess.ExecuteReader(ref reader, cmd);

            if (result.Succeeded)
            {
                config = new Config();

                while (reader.Read())
                {
                    config.Name = reader.GetString(1);
                    config.Path = reader.GetString(2);
                    config.DtChanged = reader.GetDateTime(3);
                    //TODO: FInish work here...
                }
            }
            return result;
        }

        public override IResult LoadConfigs(string configPath)
        {
            IResult result = null;

            SQLiteCommand cmd = dbAccess.GetCommand(CommandType.Text, "SELECT * FROM Config WHERE Path = @path");
            cmd.Parameters.Add(new SQLiteParameter("@path", configPath));

            IDataReader reader = null;
            result = dbAccess.ExecuteReader(ref reader, cmd);

            return result;
        }

        public override IResult SaveConfig(List<Config> configs)
        {
            return base.SaveConfig(configs);
        }

        public override IResult SaveConfig(Config config)
        {
            IResult result = null;

            SQLiteCommand cmd = dbAccess.GetCommand(CommandType.Text, "UPDATE Config SET Value = @value WHERE Path = @path AND Name = @name;");
            cmd.Parameters.Add(new SQLiteParameter("@path", config.Path));
            cmd.Parameters.Add(new SQLiteParameter("@name", config.Name));
            cmd.Parameters.Add(new SQLiteParameter("@value", config.Value));

            IDataReader reader = null;
            result = dbAccess.ExecuteReader(ref reader, cmd);

            return result;
        }

        #endregion


        #region Private Methods


        #endregion
    }
}
