using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    class PowerOfAttornyTab : SqlQueries
    {
        public PowerOfAttornyTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT034";
        public override string NewTableName => "PowerOfAttorny";
        protected override int ColCount => 23;
        protected override string ColShortcut => "IT";

        protected override int cCr => 12;
        protected override int cCrId => 13;
        protected override int cMd => 14;
        protected override int cMdId => 15;
        protected override int cNote => 16;               

        private readonly string nc01 = "PrincipalType";
        private readonly string nc02 = "PrincipalMandateId";
        private readonly string nc03 = "DelegateType";
        private readonly string nc04 = "DelegateMandateId";
        private readonly string nc05 = "ConcernsMandateId";
        private readonly string nc06 = "PowerOfAttornyTypeId";
        private readonly string nc07 = "Activity";
        private readonly string nc08 = "Issuance";
        private readonly string nc09 = "Expiration";
        private readonly string nc10 = "Blocked";
        private readonly string nc11 = "PrincipalCustomerPCBId";
        private readonly string nc17 = "Deleted";
        private readonly string nc18 = "ConcernsType";
        private readonly string nc19 = "Resubmission";
        private readonly string nc20 = "ConcernsPCBId";
        private readonly string nc21 = "PrincipalPCBId";
        private readonly string nc22 = "DelegatePCBId";
        private readonly string nc23 = "DelegateUserId";       


        public override string SqlCreate()
        {
            var sql = GetSqlCreate($@"[{nc01}] [smallint] NOT NULL,
[{nc02}] [int] NULL,
[{nc03}] [smallint] NOT NULL,
[{nc04}] [int] NULL,
[{nc05}] [int] NULL,
[{nc06}] [int] NULL,
[{nc07}] [nvarchar](100) NULL,
[{nc08}] [smalldatetime] NULL,
[{nc09}] [smalldatetime] NULL,
[{nc10}] [smallint] NOT NULL,
[{nc11}] [int] NULL,
[{nc17}] [smallint] NOT NULL,
[{nc18}] [smallint] NOT NULL,
[{nc19}] [smallint] NOT NULL,
[{nc20}] [int] NULL,
[{nc21}] [int] NULL,
[{nc22}] [int] NULL,
[{nc23}] [int] NULL"
);
            var par1 = "0 - Mandate, 1 - PCB, 2 - Customer";
            var par2 = "0 - Mandate, 1 - PCB, 2 - Customer";
            var par3 = "0 - Mandate, 1 - PCB, 2 - Customer";            
            return $@"{sql} {GetExecForColumnDescription(nc01, par1)}{GetExecForColumnDescription(nc03, par2)}{GetExecForColumnDescription(nc18, par3)}";
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc10}],[{nc11}],
[{nc17}],[{nc18}],[{nc19}],[{nc20}],[{nc21}],[{nc22}],[{nc23}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc09},@{nc10},@{nc11},
@{nc17},@{nc18},@{nc19},@{nc20},@{nc21},@{nc22},@{nc23}"
), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc18}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc22}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc23}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
