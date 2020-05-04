using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class TelephoneActivityTab : SqlQueries
    {
        public TelephoneActivityTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT039";
        public override string NewTableName => "TelephoneActivity";
        protected override int ColCount => 18;
        protected override string ColShortcut => "IT";

        protected override int cCr => 10;
        protected override int cCrId => 11;
        protected override int cMd => 12;
        protected override int cMdId => 13;
        protected override int cNote => 14;
        protected override string columns => "ITF003,ITF004,ITF005,ITF006,ITF007,ITF008,ITF009,ITF015,ITF016,ITF017,ITF018,ITF020,ITF021";

        private readonly string nc03 = "TelephoneActivityTypeId";
        private readonly string nc04 = "AddOn";
        private readonly string nc05 = "ForWhomId";
        private readonly string nc06 = "Urgent";
        private readonly string nc07 = "Executed";
        private readonly string nc08 = "ExecutedDate";
        private readonly string nc09 = "ExecutedWhoId";
        private readonly string nc15 = "Deleted";
        private readonly string nc16 = "CallDated";
        private readonly string nc17 = "ReturnCallOn";
        private readonly string nc18 = "Telephone";
        private readonly string nc20 = "Private";
        private readonly string nc21 = "WholeTelephone";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc03}] [int] NULL,
[{nc04}] [nvarchar](100) NULL,
[{nc05}] [int] NULL,    
[{nc06}] [smallint] NOT NULL,
[{nc07}] [smallint] NOT NULL,
[{nc08}] [datetime] NULL,
[{nc09}] [int] NULL,
[{nc15}] [smallint] NOT NULL,
[{nc16}] [datetime] NULL,
[{nc17}] [datetime] NULL,
[{nc18}] [nvarchar](30) NULL,
[{nc20}] [smallint] NOT NULL,
[{nc21}] [nvarchar](50) NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc15}],[{nc16}],[{nc17}],[{nc18}],[{nc20}],[{nc21}]",
                    $@"@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc09},@{nc15},@{nc16},@{nc17},@{nc18},@{nc20},@{nc21}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.NVarChar,100);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc15}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc18}", SqlDbType.NVarChar,30);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.NVarChar,50);                
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
