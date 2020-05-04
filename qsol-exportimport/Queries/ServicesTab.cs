using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class ServicesTab : SqlQueries
    {
        public ServicesTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT060";
        public override string NewTableName => "Services";
        protected override int ColCount => 21;
        protected override string ColShortcut => "IT";

        protected override int cCr => 14;
        protected override int cCrId => 15;
        protected override int cMd => 16;
        protected override int cMdId => 17;
        protected override int cNote => 18;

        private readonly string nc01 = "MandateId";
        private readonly string nc02 = "CodeId";
        private readonly string nc03 = "TypeId";
        private readonly string nc04 = "InternalMandateId";
        private readonly string nc05 = "Beginning";
        private readonly string nc06 = "End";
        private readonly string nc07 = "EndReason";
        private readonly string nc08 = "ResponsableId";
        private readonly string nc09 = "Amount";
        private readonly string nc10 = "CurrencyId";
        private readonly string nc11 = "Contract";
        private readonly string nc12 = "FirstInvoice";
        private readonly string nc13 = "Period";
        private readonly string nc19 = "ExternalCompanyId";
        private readonly string nc20 = "ClientMandateId";
        private readonly string nc21 = "PCBId";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
[{nc02}] [int] NULL,
[{nc03}] [int] NOT NULL,
[{nc04}] [int] NULL,
[{nc05}] [smalldatetime] NULL,
[{nc06}] [smalldatetime] NULL,
[{nc07}] [nvarchar](100) NULL,
[{nc08}] [int] NULL,
[{nc09}] [float] NULL,	
[{nc10}] [int] NULL,
[{nc11}] [smalldatetime] NULL,
[{nc12}] [smalldatetime] NULL,
[{nc13}] [smallint] NULL,
[{nc19}] [int] NULL,
[{nc20}] [int] NULL,
[{nc21}] [int] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc10}],[{nc11}],[{nc12}],[{nc13}],[{nc19}],[{nc20}],[{nc21}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc09},@{nc10},@{nc11},@{nc12},@{nc13},@{nc19},@{nc20},@{nc21}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.NVarChar,100);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.Float);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
