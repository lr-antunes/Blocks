using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Rovidi.Blocks.Core;

namespace Rovidi.Blocks.Data
{
    public interface IDBAccess
    {
        IResult ExecuteReader(ref IDataReader dataReader, IDbCommand command);
        IResult ExecuteScalar(ref object result, IDbCommand command);
        IResult ExecuteNonQuery(ref int result, IDbCommand command);
    }
}
