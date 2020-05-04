using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class CustomerBusinessCaseTab : SqlQueries
    {
        public CustomerBusinessCaseTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT046";
        public override string NewTableName => "CustomerBusinessCase";
        protected override int ColCount => 10;
        protected override string ColShortcut => "IT";

        protected override int cCr => 6;
        protected override int cCrId => 7;
        protected override int cMd => 8;
        protected override int cMdId => 9;
        protected override int cNote => 10;

        private readonly string nc01 = "MandateRecordingId";
        private readonly string nc02 = "PCBId";
        private readonly string nc03 = "IntroducedPCBId";
        private readonly string nc04 = "Introduced";
        private readonly string nc05 = "AddIn";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
[{nc02}] [int] NULL,
[{nc03}] [int] NULL,
[{nc04}] [smalldatetime] NULL,
[{nc05}] [nvarchar](MAX) NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.NVarChar,-1 );
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

