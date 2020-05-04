using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class InboxPCBTab : SqlQueries
    {
        public InboxPCBTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT126";
        public override string NewTableName => "InboxPCB";
        protected override int ColCount => 3;
        protected override string ColShortcut => "IT";

        private readonly string nc01 = "InboxId";
        private readonly string nc02 = "PCBId";
        private readonly string nc03 = "Blocked";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,[{nc02}] [int] NULL,[{nc03}] [smallint] NOT NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{ nc03}]", $@"@{ nc01},@{nc02},@{nc03}"
                ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

