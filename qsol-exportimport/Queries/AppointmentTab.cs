using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class AppointmentTab : SqlQueries
    {
        public AppointmentTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT077";
        public override string NewTableName => "Appointment";
        protected override int ColCount => 23;
        protected override string ColShortcut => "IT";

        protected override int cCr => 12;
        protected override int cCrId => 13;
        protected override int cMd => 14;
        protected override int cMdId => 15;
        protected override int cNote => 16;
        protected override string columns => @"ITF001,ITF004,ITF005,ITF006,ITF007,ITF008,ITF009,ITF010,ITF011,ITF017,ITF019,ITF020,ITF021,ITF022,ITF023,ITF024,ITF026,ITF027";

        private readonly string nc01 = "AppointmentSeriesId";        
        private readonly string nc04 = "TypeId";
        private readonly string nc05 = "AddOn";
        private readonly string nc06 = "Since";
        private readonly string nc07 = "Till";
        private readonly string nc08 = "ResponsableId";
        private readonly string nc09 = "Executed";
        private readonly string nc10 = "ExecutedDate";
        private readonly string nc11 = "ExecutedWhoId";        
        private readonly string nc17 = "Deleted";        
        private readonly string nc19 = "Private";
        private readonly string nc20 = "AllDay";
        private readonly string nc21 = "Provisionally";
        private readonly string nc22 = "ProvisionallyDate";
        private readonly string nc23 = "provisionallyWhoId";
        private readonly string nc24 = "WithoutWeek";        
        private readonly string nc26 = "LocalityId";
        private readonly string nc27 = "Locality";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,	
	[{nc04}] [int] NULL,
    [{nc05}] [nvarchar](100),
    [{nc06}] [datetime] NULL,
    [{nc07}] [datetime] NULL,
    [{nc08}] [int] NULL,
    [{nc09}] [smallint] NOT NULL,
    [{nc10}] [datetime] NULL,
	[{nc11}] [int] NULL,	
	[{nc17}] [smallint] NOT NULL,	
    [{nc19}] [smallint] NOT NULL,
    [{nc20}] [smallint] NOT NULL,
    [{nc21}] [smallint] NOT NULL,
    [{nc22}] [smalldatetime] NULL,
    [{nc23}] [int] NULL,
    [{nc24}] [smallint] NOT NULL,
    [{nc26}] [int] NULL,
    [{nc27}] [nvarchar](100) NULL"
    );

        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc10}],[{nc11}],[{nc17}],[{nc19}],[{nc20}],[{nc21}],[{nc22}],[{nc23}],[{nc24}],[{nc26}],[{nc27}]",
                    $@"@{nc01},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc09},@{nc10},@{nc11},@{nc17},@{nc19},@{nc20},@{nc21},@{nc22},@{nc23},@{nc24},@{nc26},@{nc27}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);                
                cmd.Parameters.Add($"@{nc04}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.NChar,100);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.Int);                
                cmd.Parameters.Add($"@{nc17}", SqlDbType.SmallInt);                
                cmd.Parameters.Add($"@{nc19}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc22}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc23}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc24}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc26}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc27}", SqlDbType.NVarChar,100);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

