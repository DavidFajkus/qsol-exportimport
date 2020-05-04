using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class CustomerTab : SqlQueries
    {
        public CustomerTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT015";
        public override string NewTableName => "Customer";
        protected override int ColCount => 25;
        protected override string ColShortcut => "IT";

        protected override int cCr => 11;
        protected override int cCrId => 12;
        protected override int cMd => 13;
        protected override int cMdId => 14;
        protected override int cNote => 15;

        private readonly string nc01 = "PCBId";
        private readonly string nc02 = "IntermediaryId";
        private readonly string nc03 = "Activity";
        private readonly string nc04 = "LocalityId";
        private readonly string nc05 = "ManCount";
        private readonly string nc06 = "CusSince";
        private readonly string nc07 = "Dispatch";
        private readonly string nc08 = "ResponsableId";
        private readonly string nc09 = "Responsable2Id";
        private readonly string nc10 = "Responsable3Id";
        private readonly string nc16 = "OrgUnitId";
        private readonly string nc17 = "ImportedWhoId";
        private readonly string nc18 = "ImportedDate";
        private readonly string nc19 = "ImportedNote";
        private readonly string nc20 = "RiskGroupId";
        private readonly string nc21 = "Inactive";
        private readonly string nc22 = "ThresholdAmountUpTo";
        private readonly string nc23 = "ThresholdCurrencyId";
        private readonly string nc24 = "AML";
        private readonly string nc27 = "CusNumber";

        protected override string columns => @"ITF001,ITF002,ITF003,ITF004,ITF005,ITF006,ITF007,ITF008,ITF009,ITF010,
ITF016,ITF017,ITF018,ITF019,ITF020,ITF021,ITF022,ITF023,ITF024,ITF027";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
	[{nc02}] [int] NULL,
	[{nc03}] [nvarchar](30) NULL,	
	[{nc04}] [int] NULL,
    [{nc05}] [int] NULL,
    [{nc06}] [smalldatetime] NULL,
    [{nc07}] [smallint] NOT NULL,
    [{nc08}] [int] NULL,
    [{nc09}] [int] NULL,
	[{nc10}] [int] NULL,	
    [{nc16}] [int] NULL,
    [{nc17}] [int] NULL,
    [{nc18}] [smalldatetime] NULL,
    [{nc19}] [ntext] NULL,
    [{nc20}] [int] NULL,
    [{nc21}] [smallint] NOT NULL,
    [{nc22}] [float] NULL,
    [{nc23}] [int] NULL,
    [{nc24}] [smallint] NOT NULL,    
    [{nc27}] [nvarchar](15) NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc10}],
[{nc16}],[{nc17}],[{nc18}],[{nc19}],[{nc20}],[{nc21}],[{nc22}],[{nc23}],[{nc24}],[{nc27}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc09},@{nc10},
@{nc16},@{nc17},@{nc18},@{nc19},@{nc20},@{nc21},@{nc22},@{nc23},@{nc24},@{nc27}"

                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc18}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.NText);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc22}", SqlDbType.Float);
                cmd.Parameters.Add($"@{nc23}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc24}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc27}", SqlDbType.NVarChar,15);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
