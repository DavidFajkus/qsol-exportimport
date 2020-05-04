using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class TelephoneTab : SqlQueries
    {
        public TelephoneTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT028";
        public override string NewTableName => "Telephone";
        protected override int ColCount => 16;
        protected override string ColShortcut => "IT";
        protected override string columns => "ITF001,ITF002,ITF003,ITF004,ITF005,ITF006,ITF007,ITF014,ITF015,ITF016,ITF017";

        protected override int cCr => 8;
        protected override int cCrId => 9;
        protected override int cMd => 10;
        protected override int cMdId => 11;
        protected override int cNote => 12;

        private readonly string nc01 = "AddressId";
        private readonly string nc02 = "PrefixCountry";
        private readonly string nc03 = "PrefixRegion";
        private readonly string nc04 = "Number";
        private readonly string nc05 = "Extension";
        private readonly string nc06 = "TelephoneType";
        private readonly string nc07 = "AddOn";
        private readonly string nc14 = "WholeNumber";
        private readonly string nc15 = "Blocked";
        private readonly string nc16 = "PCBId";
        private readonly string nc17 = "EmployeeId";        
        
        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
	[{nc02}] [nvarchar](7) NULL,
	[{nc03}] [nvarchar](7) NULL,
    [{nc04}] [nvarchar](36) NULL,
    [{nc05}] [nvarchar](50) NULL,
    [{nc06}] [int] NULL,
    [{nc07}] [nvarchar](50) NULL,
	[{nc14}] [nvarchar](50) NULL,
	[{nc15}] [smallint] NOT NULL,
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
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc14}],[{nc15}],[{nc16}],[{nc17}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc14},@{nc15},@{nc16},@{nc17}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 7);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar, 7);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.NVarChar, 36);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc15}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
