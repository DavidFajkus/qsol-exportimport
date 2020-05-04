using System;
using System.Data.SqlClient;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Helpers
{
    public static class WorkReader
    {
        internal static void SetParameter(SqlParameterCollection parameters, SqlDataReader reader, int index)
        {
            parameters[index].Value = reader.IsDBNull(index) ? DBNull.Value : reader.GetValue(index);
        }

        internal static InfoDto CreateInfo(string tableName, int imported, int count, string info = "")
        {
            return new InfoDto()
            {
                Info = info,
                TableName = tableName,
                Imported = imported,
                Count = count
            };
        }

        internal static object NullToDBNull(object o)
        {
            return o == null ? DBNull.Value : o;
        }

        internal static object DBNullToNull(object o)
        {
            return o == DBNull.Value ? null : o;
        }
    }
}
