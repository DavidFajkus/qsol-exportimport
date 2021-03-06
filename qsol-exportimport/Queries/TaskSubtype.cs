﻿using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class TaskSubtypeTab : SqlQueries
    {
        public TaskSubtypeTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT080";
        public override string NewTableName => "TaskSubtype";
        protected override int ColCount => 9;
        protected override string ColShortcut => "IT";

        protected override int cCr => 4;
        protected override int cCrId => 5;
        protected override int cMd => 6;
        protected override int cMdId => 7;
        protected override int cNote => 8;

        private readonly string nc01 = "TaskTypeId";
        private readonly string nc02 = "Name";
        private readonly string nc03 = "Blocked";
        private readonly string nc09 = "Recurring";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int],[{nc02}] [nvarchar](50) NULL,[{nc03}] [smallint] NOT NULL,[{nc09}] [smallint] NULL");

        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc09}]", $@"@{nc01},@{nc02},@{nc03},@{nc09}"), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);


                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

