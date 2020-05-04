using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class MandatePurposeTab : SqlQueries
    {
        public MandatePurposeTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT056";
        public override string NewTableName => "MandatePurpose";
        protected override int ColCount => 8;
        protected override string ColShortcut => "IT";

        protected override int cCr => 2;
        protected override int cCrId => 3;
        protected override int cMd => 4;
        protected override int cMdId => 5;
        protected override int cNote => 6;

        private readonly string nc01 = "Purpose";
        private readonly string nc07 = "Blocked";
        private readonly string nc08 = "RiskGroupId";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [nvarchar](50) NULL,
[{nc07}] [smallint] NOT NULL,
[{nc08}] [int] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc07}],[{nc08}]",
                    $@"@{nc01},@{nc07},@{nc08}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
