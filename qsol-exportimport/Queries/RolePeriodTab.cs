using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class RolePeriodTab : SqlQueries
    {
        public RolePeriodTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT340";
        public override string NewTableName => "RolePeriod";
        protected override int ColCount => 14;
        protected override string ColShortcut => "IT";

        protected override int cCr => 8;
        protected override int cCrId => 9;
        protected override int cMd => 10;
        protected override int cMdId => 11;
        protected override int cNote => 12;
        protected override string columns => "ITF001,ITF002,ITF003,ITF004,ITF005,ITF006,ITF013,ITF014,ITF016,ITF017";

        private readonly string nc01 = "PCBId";
        private readonly string nc02 = "MandateId";
        private readonly string nc03 = "RoleId";
        private readonly string nc04 = "Since";
        private readonly string nc05 = "Till";
        private readonly string nc06 = "Participation";
        private readonly string nc13 = "Deleted";
        private readonly string nc14 = "BusinessCase";
        private readonly string nc16 = "AddressId";
        private readonly string nc17 = "Mndate2Id";
        
        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
	[{nc02}] [int] NULL,
	[{nc03}] [int] NULL,	
	[{nc04}] [smalldatetime] NULL,
	[{nc05}] [smalldatetime] NULL,
	[{nc06}] [float] NULL,	
	[{nc13}] [smallint] NOT NULL,
	[{nc14}] [int] NULL,	
	[{nc16}] [int] NULL,
	[{nc17}] [int] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc13}],[{nc14}],[{nc16}],[{nc17}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc13},@{nc14},@{nc16},@{nc17}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.Float);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
