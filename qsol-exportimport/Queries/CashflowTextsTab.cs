using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class CashflowTextsTab : SqlQueries
    {
        public CashflowTextsTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT002";
        public override string NewTableName => "CashflowTexts";
        protected override int ColCount => 18;
        protected override string ColShortcut => "IT";
        protected override string columns => @"ITF001,ITF002,ITF004,ITF005,ITF007,ITF008,ITF010,ITF011,ITF013,ITF014,ITF016,ITF017,ITF019";

        protected override int cCr => 20;
        protected override int cCrId => 21;
        protected override int cMd => 22;
        protected override int cMdId => 23;
        protected override int cNote => 24;

        private readonly string nc01 = "CashflowId";
        private readonly string nc02 = "Print1";        
        private readonly string nc04 = "Text1";
        private readonly string nc05 = "Print2";
        private readonly string nc07 = "Text2";
        private readonly string nc08 = "Print3";
        private readonly string nc10 = "Text3";
        private readonly string nc11 = "Print4";
        private readonly string nc13 = "Text4";
        private readonly string nc14 = "Print5";
        private readonly string nc16 = "Text5";
        private readonly string nc17 = "Print6";
        private readonly string nc19 = "Text6";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
[{nc02}] [smallint] NOT NULL,
[{nc04}] [nvarchar](MAX) NULL,
[{nc05}] [smallint] NOT NULL,
[{nc07}] [nvarchar](MAX) NULL,
[{nc08}] [smallint] NOT NULL,
[{nc10}] [nvarchar](MAX) NULL,
[{nc11}] [smallint] NOT NULL,
[{nc13}] [nvarchar](MAX) NULL,
[{nc14}] [smallint] NOT NULL,
[{nc16}] [nvarchar](MAX) NULL,
[{nc17}] [smallint] NOT NULL,
[{nc19}] [nvarchar](MAX) NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc04}],[{nc05}],[{nc07}],[{nc08}],[{nc10}],[{nc11}],[{nc13}],[{nc14}],[{nc16}],[{nc17}],[{nc19}]",
                    $@"@{nc01},@{nc02},@{nc04},@{nc05},@{nc07},@{nc08},@{nc10},@{nc11},@{nc13},@{nc14},@{nc16},@{nc17},@{nc19}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.NVarChar, -1);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.NVarChar, -1);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.NVarChar, -1);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.NVarChar, -1);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.NVarChar, -1);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.NVarChar, -1);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
