using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class CorrespondentTab : SqlQueries
    {
        public CorrespondentTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT014";
        public override string NewTableName => "Correspondent";
        protected override int ColCount => 15;
        protected override string ColShortcut => "IT";

        protected override int cCr => 11;
        protected override int cCrId => 12;
        protected override int cMd => 13;
        protected override int cMdId => 14;
        protected override int cNote => 15;

        private readonly string nc01 = "PCBId";
        private readonly string nc02 = "PlaceId";
        private readonly string nc03 = "Since";
        private readonly string nc04 = "ReferencePCBId";
        private readonly string nc05 = "Activity";
        private readonly string nc06 = "PowerOfAttorney";
        private readonly string nc07 = "Dispatch";
        private readonly string nc08 = "ResponsableId";
        private readonly string nc09 = "ResponsableIIId";
        private readonly string nc10 = "ResponsableIIIId";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
[{nc02}] [int] NULL,
[{nc03}] [smalldatetime] NULL,
[{nc04}] [int] NULL,
[{nc05}] [nvarchar](30) NULL,
[{nc06}] [nvarchar](MAX) NULL,
[{nc07}] [smallint] NOT NULL,
[{nc08}] [int] NULL,
[{nc09}] [int] NULL,
[{nc10}] [int] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc10}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc09},@{nc10}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.NVarChar,30);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.NVarChar,-1);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
