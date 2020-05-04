using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class ObjectTab : SqlQueries
    {
        public ObjectTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT053";
        public override string NewTableName => "Object";
        protected override int ColCount => 15;
        protected override string ColShortcut => "IT";

        protected override int cCr => 9;
        protected override int cCrId => 10;
        protected override int cMd => 11;
        protected override int cMdId => 12;
        protected override int cNote => 13;

        private readonly string nc01 = "PCBId";
        private readonly string nc02 = "Object";
        private readonly string nc03 = "StoredId";
        private readonly string nc04 = "DateIn";
        private readonly string nc05 = "InWhoId";
        private readonly string nc06 = "DateOut";
        private readonly string nc07 = "OutWhoId";
        private readonly string nc08 = "OutReason";        
        private readonly string nc14 = "StorageLocation";
        private readonly string nc15 = "MandateId";        

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
	[{nc02}] [nvarchar](50) NULL,
	[{nc03}] [int] NULL,
    [{nc04}] [smalldatetime] NULL,
    [{nc05}] [int] NULL,
    [{nc06}] [smalldatetime] NULL,
    [{nc07}] [int] NULL,
    [{nc08}] [nvarchar](100) NULL,
	[{nc14}] [nvarchar](50) NULL,	
	[{nc15}] [int] NULL"
    );
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc14}],[{nc15}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc14},@{nc15}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc15}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
