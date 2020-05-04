﻿using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class TaskPCBTab : SqlQueries
    {
        public TaskPCBTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT161";
        public override string NewTableName => "TaskPCB";
        protected override int ColCount => 2;
        protected override string ColShortcut => "IT";

        private readonly string nc01 = "TaskId";
        private readonly string nc02 = "PCBId";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,[{nc02}] [int] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert($@"[{nc01}],[{nc02}]", $@"@{ nc01},@{nc02}"), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

