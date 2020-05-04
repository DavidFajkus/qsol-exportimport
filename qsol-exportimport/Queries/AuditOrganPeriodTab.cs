using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class AuditOrganPeriodTab : SqlQueries
    {
        public AuditOrganPeriodTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT065";
        public override string NewTableName => "AuditOrganPeriod";
        protected override int ColCount => 20;
        protected override string ColShortcut => "IT";

        protected override int cCr => 15;
        protected override int cCrId => 16;
        protected override int cMd => 17;
        protected override int cMdId => 18;
        protected override int cNote => 19;

        private readonly string nc01 = "MandateId";
        private readonly string nc02 = "AuditOrganId";
        private readonly string nc03 = "Since";
        private readonly string nc04 = "Designation";
        private readonly string nc05 = "AuditActivityId";
        private readonly string nc06 = "PowerOfAttorney";
        private readonly string nc07 = "Dispatch";
        private readonly string nc08 = "ResponsibleId";
        private readonly string nc09 = "ResponsibleIIId";
        private readonly string nc10 = "ResponsibleIIIId";
        private readonly string nc11 = "Handover";
        private readonly string nc12 = "AuditOrganEnd";
        private readonly string nc13 = "Amount";
        private readonly string nc14 = "CurrrencyId";
        private readonly string nc20 = "PCBId";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
[{nc02}] [int] NULL,
[{nc03}] [smalldatetime] NULL,
[{nc04}] [nvarchar](50) NULL,
[{nc05}] [int] NULL,
[{nc06}] [nvarchar](MAX) NULL,
[{nc07}] [smallint] NOT NULL,
[{nc08}] [int] NULL,
[{nc09}] [int] NULL,
[{nc10}] [int] NULL,
[{nc11}] [smalldatetime] NULL,
[{nc12}] [smalldatetime] NULL,
[{nc13}] [float] NULL,
[{nc14}] [int] NULL,
[{nc20}] [int] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc10}],[{nc11}],[{nc12}],[{nc13}],[{nc14}],[{nc20}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc09},@{nc10},@{nc11},@{nc12},@{nc13},@{nc14},@{nc20}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.NVarChar,50);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.NVarChar,-1);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.Float);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
