using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class MandateRecordingTab : SqlQueries
    {
        public MandateRecordingTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT043";
        public override string NewTableName => "MandateRecording";
        protected override int ColCount => 13;
        protected override string ColShortcut => "IT";

        protected override int cCr => 5;
        protected override int cCrId => 6;
        protected override int cMd => 7;
        protected override int cMdId => 8;
        protected override int cNote => 9;

        private readonly string nc01 = "Operation";
        private readonly string nc02 = "operationType";
        private readonly string nc03 = "Status";
        private readonly string nc04 = "ResponsableId";
        private readonly string nc10 = "Acceptance";
        private readonly string nc11 = "AcceptanceWhoId";
        private readonly string nc12 = "NotImplemented";
        private readonly string nc13 = "NotImplementedWhoId";

        public override string SqlCreate()
        {
            var sql = GetSqlCreate($@"[{nc01}] [nvarchar](50) NULL,
[{nc02}] [smallint] NOT NULL,
[{nc03}] [int] NOT NULL,
[{nc04}] [int] NULL,
[{nc10}] [smalldatetime] NULL,
[{nc11}] [int] NULL,
[{nc12}] [smalldatetime] NULL,
[{nc13}] [int] NULL");

            var par1 = "1 - aktiv, 2 - passiv";            
            return $@"{sql} {GetExecForColumnDescription(nc03, par1)}";
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc10}],[{nc11}],[{nc12}],[{nc13}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc10},@{nc11},@{nc12},@{nc13}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
