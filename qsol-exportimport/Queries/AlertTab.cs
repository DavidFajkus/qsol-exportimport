using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class AlertTab : SqlQueries
    {
        public AlertTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT082";
        public override string NewTableName => "Alert";
        protected override int ColCount => 10;
        protected override string ColShortcut => "IT";

        protected override int cCr => 4;
        protected override int cCrId => 5;
        
        private readonly string nc01 = "RecordId";
        private readonly string nc02 = "Points";
        private readonly string nc03 = "Alert";        
        private readonly string nc06 = "AlertBush";
        private readonly string nc07 = "RecordIIId";
        private readonly string nc08 = "Header";
        private readonly string nc09 = "ModuleId";
        private readonly string nc10 = "FormId";
        

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
	[{nc02}] [int] NULL,
	[{nc03}] [nvarchar](MAX) NULL,    
    [{nc06}] [nvarchar](MAX) NULL,
    [{nc07}] [int] NULL,
    [{nc08}] [nvarchar](MAX) NULL,
	[{nc09}] [smallint] NULL,
	[{nc10}] [smallint] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc10}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc06},@{nc07},@{nc08},@{nc09},@{nc10}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar, -1);                
                cmd.Parameters.Add($"@{nc06}", SqlDbType.NVarChar, -1);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.NVarChar, -1);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
