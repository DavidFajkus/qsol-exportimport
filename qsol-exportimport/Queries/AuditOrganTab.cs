using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class AuditOrganTab : SqlQueries
    {
        public AuditOrganTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT023";
        public override string NewTableName => "AuditOrgan";
        protected override int ColCount => 13;
        protected override string ColShortcut => "IT";

        protected override int cCr => 9;
        protected override int cCrId => 10;
        protected override int cMd => 11;
        protected override int cMdId => 12;
        protected override int cNote => 13;

        private readonly string nc01 = "PCBId";
        private readonly string nc02 = "Since";
        private readonly string nc03 = "Responsible";
        private readonly string nc04 = "AuditOrganActivityId";
        private readonly string nc05 = "Dispatch";
        private readonly string nc06 = "ResponsableIId";
        private readonly string nc07 = "ResponsableIIId";
        private readonly string nc08 = "ResponsableIIIId";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
[{nc02}] [smalldatetime] NULL,
[{nc03}] [nvarchar](50) NULL,
[{nc04}] [int] NULL,
[{nc05}] [smallint] NOT NULL,
[{nc06}] [int] NULL,
[{nc07}] [int] NULL,
[{nc08}] [int] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
