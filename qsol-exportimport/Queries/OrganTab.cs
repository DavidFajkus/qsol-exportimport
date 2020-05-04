using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class OrganTab : SqlQueries
    {
        public OrganTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT032";
        public override string NewTableName => "Organ";
        protected override int ColCount => 21;
        protected override string ColShortcut => "IT";

        protected override int cCr => 15;
        protected override int cCrId => 16;
        protected override int cMd => 17;
        protected override int cMdId => 18;
        protected override int cNote => 19;

        private readonly string nc01 = "MandateId";
        private readonly string nc02 = "FuntionHolderPCBId";
        private readonly string nc03 = "OrganeId";
        private readonly string nc04 = "CorrespondentId";
        private readonly string nc05 = "FunctionId";
        private readonly string nc06 = "FunctionFrom";
        private readonly string nc07 = "FunctionTo";
        private readonly string nc08 = "SignatureMode";
        private readonly string nc09 = "Insurance";
        private readonly string nc10 = "FrameworkContract";
        private readonly string nc11 = "MandateContract";
        private readonly string nc12 = "Amount";
        private readonly string nc13 = "CurrencyId";
        private readonly string nc14 = "Dispatch";
        private readonly string nc20 = "PCBId";
        private readonly string nc21 = "FuntionHolderMandateId";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
[{nc02}] [int] NULL,
[{nc03}] [int] NULL,
[{nc04}] [int] NULL,
[{nc05}] [int] NULL,
[{nc06}] [smalldatetime] NULL,
[{nc07}] [smalldatetime] NULL,
[{nc08}] [int] NULL,
[{nc09}] [smallint] NOT NULL,
[{nc10}] [smallint] NOT NULL,
[{nc11}] [smallint] NOT NULL,
[{nc12}] [float] NULL,
[{nc13}] [int] NULL,
[{nc14}] [smallint] NOT NULL,
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
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc10}],[{nc11}],[{nc12}],[{nc13}],[{nc14}],[{nc20}],[{nc21}]", 
                    $@"@{ nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc09},@{nc10},@{nc11},@{nc12},@{nc13},@{nc14},@{nc20},@{nc21}"
                ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.Float);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

