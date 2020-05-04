using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class AddressTab : SqlQueries
    {
        public AddressTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT007";
        public override string NewTableName => "Address";
        protected override int ColCount => 19;
        protected override string ColShortcut => "IT";

        protected override int cCr => 10;
        protected override int cCrId => 11;
        protected override int cMd => 12;
        protected override int cMdId => 13;
        protected override int cNote => 14;

        private readonly string nc01 = "PCBId";
        private readonly string nc02 = "Street";
        private readonly string nc03 = "AddressAddOn";
        private readonly string nc04 = "Place";
        private readonly string nc05 = "AddressTypeId";
        private readonly string nc06 = "SendingBirthday";
        private readonly string nc07 = "SendingChristmas";
        private readonly string nc08 = "SendingGeneral";
        private readonly string nc09 = "MainAdress";        
        private readonly string nc15 = "PostalCode";
        private readonly string nc16 = "MandateId";
        private readonly string nc17 = "Blocked";
        private readonly string nc18 = "ContactId";
        private readonly string nc19 = "Order";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
	[{nc02}] [nvarchar](254) NULL,
	[{nc03}] [nvarchar](254) NULL,
    [{nc04}] [int] NULL,
    [{nc05}] [int] NULL,
    [{nc06}] [smallint] NOT NULL,
    [{nc07}] [smallint] NOT NULL,
    [{nc08}] [smallint] NOT NULL,
	[{nc09}] [smallint] NOT NULL,	
	[{nc15}] [nvarchar](15) NULL,
	[{nc16}] [int] NULL,
	[{nc17}] [smallint] NOT NULL,
    [{nc18}] [int] NULL,
    [{nc19}] [smallint] NOT NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc15}],[{nc16}],[{nc17}],[{nc18}],[{nc19}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc09},@{nc15},@{nc16},@{nc17},@{nc18},@{nc19}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 254);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar, 254);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.SmallInt);                
                cmd.Parameters.Add($"@{nc15}", SqlDbType.NVarChar, 15);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc18}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
