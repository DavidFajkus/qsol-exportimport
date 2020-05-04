using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class AppointmentSeriesTab : SqlQueries
    {
        public AppointmentSeriesTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT036";
        public override string NewTableName => "AppointmentSeries";
        protected override int ColCount => 43;
        protected override string ColShortcut => "IT";

        protected override int cCr => 11;
        protected override int cCrId => 12;
        protected override int cMd => 13;
        protected override int cMdId => 14;
        protected override int cNote => 15;
        protected override string columns => @"ITF003,ITF004,ITF005,ITF006,ITF007,ITF008,ITF009,ITF010,ITF016,ITF017,ITF018,ITF019,ITF020,ITF021,ITF022,ITF023,ITF024,ITF025,ITF026,ITF027,
ITF028,ITF029,ITF030,ITF031,ITF032,ITF033,ITF034,ITF035,ITF036,ITF037,ITF038,ITF040,ITF041,ITF042,ITF043,ITF044,ITF046,ITF047";
                
        private readonly string nc03 = "TypeId";
        private readonly string nc04 = "AddOn";
        private readonly string nc05 = "Since";
        private readonly string nc06 = "Till";
        private readonly string nc07 = "ResponsableId";
        private readonly string nc08 = "Begin";
        private readonly string nc09 = "End";
        private readonly string nc10 = "Recurrent";
        private readonly string nc16 = "Deleted";
        private readonly string nc17 = "RecurrentDaily";
        private readonly string nc18 = "DayNr";        
        private readonly string nc19 = "WeekNr";
        private readonly string nc20 = "WeeklyMo";
        private readonly string nc21 = "WeeklyTu";
        private readonly string nc22 = "WeeklyWe";
        private readonly string nc23 = "WeeklyTh";
        private readonly string nc24 = "WeeklyFr";
        private readonly string nc25 = "WeeklySa";
        private readonly string nc26 = "WeeklySo";
        private readonly string nc27 = "Monthly";
        private readonly string nc28 = "MonthlyDay";
        private readonly string nc29 = "MonthlyMonth";
        private readonly string nc30 = "MonthlyHowMuchDay";
        private readonly string nc31 = "MonthlyDayNr";
        private readonly string nc32 = "MonthlyEveryNMonth";
        private readonly string nc33 = "Yearly";
        private readonly string nc34 = "YearlyDay";
        private readonly string nc35 = "YearlyMonth";
        private readonly string nc36 = "YearlyHowMuchDay";
        private readonly string nc37 = "YearlyDayNr";
        private readonly string nc38 = "YearlyMonthNr";
        private readonly string nc40 = "Private";
        private readonly string nc41 = "AllDay";
        private readonly string nc42 = "Provisionally";
        private readonly string nc43 = "WithoutWeek";
        private readonly string nc44 = "MonthlyNDayBeginEnd";
        private readonly string nc46 = "LocalityId";
        private readonly string nc47 = "Locality";



        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc03}] [int] NULL,	
	[{nc04}] [nvarchar](100) NULL,
    [{nc05}] [datetime] NULL,
    [{nc06}] [datetime] NULL,
    [{nc07}] [int] NULL,
    [{nc08}] [smalldatetime] NULL,
    [{nc09}] [smalldatetime] NULL,
    [{nc10}] [smallint] NULL,
	[{nc16}] [smallint] NOT NULL,	
	[{nc17}] [smallint] NULL,	
    [{nc18}] [smallint] NULL,
    [{nc19}] [smallint] NULL,
    [{nc20}] [smallint] NOT NULL,
    [{nc21}] [smallint] NOT NULL,
    [{nc22}] [smallint] NOT NULL,
    [{nc23}] [smallint] NOT NULL,
    [{nc24}] [smallint] NOT NULL,
    [{nc25}] [smallint] NOT NULL,
    [{nc26}] [smallint] NOT NULL,
    [{nc27}] [smallint] NULL,
    [{nc28}] [smallint] NULL,
    [{nc29}] [smallint] NULL,
    [{nc30}] [smallint] NULL,
    [{nc31}] [smallint] NULL,
    [{nc32}] [smallint] NULL,
    [{nc33}] [smallint] NULL,
    [{nc34}] [smallint] NULL,
    [{nc35}] [smallint] NULL,
    [{nc36}] [smallint] NULL,
    [{nc37}] [smallint] NULL,
    [{nc38}] [smallint] NULL,
    [{nc40}] [smallint] NOT NULL,
    [{nc41}] [smallint] NOT NULL,
    [{nc42}] [smallint] NOT NULL,
    [{nc43}] [smallint] NOT NULL,
    [{nc44}] [smallint] NOT NULL,
    [{nc46}] [int] NULL,
    [{nc47}] [nvarchar] (100) NULL"
    );

        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc10}],[{nc16}],[{nc17}],[{nc18}],[{nc19}],[{nc20}],[{nc21}],[{nc22}],[{nc23}],[{nc24}],[{nc25}],[{nc26}],[{nc27}],
[{nc28}],[{nc29}],[{nc30}],[{nc31}],[{nc32}],[{nc33}],[{nc34}],[{nc35}],[{nc36}],[{nc37}],[{nc38}],[{nc40}],[{nc41}],[{nc42}],[{nc43}],[{nc44}],[{nc46}],[{nc47}]",
                    $@"@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc09},@{nc10},@{nc16},@{nc17},@{nc18},@{nc19},@{nc20},@{nc21},@{nc22},@{nc23},@{nc24},@{nc25},@{nc26},@{nc27},
@{nc28},@{nc29},@{nc30},@{nc31},@{nc32},@{nc33},@{nc34},@{nc35},@{nc36},@{nc37},@{nc38},@{nc40},@{nc41},@{nc42},@{nc43},@{nc44},@{nc46},@{nc47}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc18}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc22}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc23}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc24}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc25}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc26}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc27}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc28}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc29}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc30}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc31}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc32}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc33}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc34}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc35}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc36}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc37}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc38}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc40}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc41}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc42}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc43}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc44}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc46}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc47}", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

