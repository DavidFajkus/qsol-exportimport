using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class TaskTab : SqlQueries
    {
        public TaskTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT073";
        public override string NewTableName => "Task";
        protected override int ColCount => 40;
        protected override string ColShortcut => "IT";

        protected override int cCr => 6;
        protected override int cCrId => 7;
        protected override int cMd => 8;
        protected override int cMdId => 9;
        protected override int cNote => 10;
        protected override string columns => @"ITF003,ITF004,ITF005,ITF011,ITF012,ITF013,ITF014,ITF015,ITF016,ITF017,ITF018,ITF019,ITF020,ITF021,ITF022,ITF023,ITF024,ITF025,ITF026,ITF027,
ITF028,ITF029,ITF030,ITF031,ITF032,ITF033,ITF034,ITF035,ITF036,ITF037,ITF038,ITF039,ITF040,ITF044,ITF046";

        private readonly string nc03 = "TaskTypeId";
        private readonly string nc04 = "Since";
        private readonly string nc05 = "Till";
        private readonly string nc11 = "Deleted";
        private readonly string nc12 = "AddOn";
        private readonly string nc13 = "ResponsableId";
        private readonly string nc14 = "Executed";
        private readonly string nc15 = "ExecutedDate";
        private readonly string nc16 = "ExecutedWho";
        private readonly string nc17 = "Recurrent";
        private readonly string nc18 = "TaskSubtypeId";
        private readonly string nc19 = "RecurrentDaily";
        private readonly string nc20 = "DayNr";
        private readonly string nc21 = "WeekNr";
        private readonly string nc22 = "WeeklyMo";
        private readonly string nc23 = "WeeklyTu";
        private readonly string nc24 = "WeeklyWe";
        private readonly string nc25 = "WeeklyTh";
        private readonly string nc26 = "WeeklyFr";
        private readonly string nc27 = "WeeklySa";
        private readonly string nc28 = "WeeklySo";
        private readonly string nc29 = "Monthly";
        private readonly string nc30 = "MonthlyDay";
        private readonly string nc31 = "MonthlyMonth";
        private readonly string nc32 = "MonthlyHowMuchDay";
        private readonly string nc33 = "MonthlyDayNr";
        private readonly string nc34 = "MonthlyEveryNMonth";
        private readonly string nc35 = "Yearly";
        private readonly string nc36 = "YearlyDay";
        private readonly string nc37 = "YearlyMonth";
        private readonly string nc38 = "YearlyHowMuchDay";
        private readonly string nc39 = "YearlyDayNr";
        private readonly string nc40 = "YearlyMonthNr";
        private readonly string nc44 = "MonthlyNDayBeginEnd";
        private readonly string nc46 = "Priority";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc03}] [int] NULL,		
	[{nc04}] [datetime] NULL,
    [{nc05}] [datetime] NULL,
    [{nc11}] [smallint] NOT NULL,
    [{nc12}] [nvarchar](100) NULL,	
	[{nc13}] [int] NULL,
	[{nc14}] [smallint] NOT NULL,
	[{nc15}] [datetime] NULL,
	[{nc16}] [int] NULL,
	[{nc17}] [smallint] NULL,
	[{nc18}] [int] NULL,
    [{nc19}] [smallint] NULL,
    [{nc20}] [smallint] NULL,
    [{nc21}] [smallint] NULL,
    [{nc22}] [smallint] NOT NULL,
    [{nc23}] [smallint] NOT NULL,
    [{nc24}] [smallint] NOT NULL,
    [{nc25}] [smallint] NOT NULL,
    [{nc26}] [smallint] NOT NULL,
    [{nc27}] [smallint] NOT NULL,
    [{nc28}] [smallint] NOT NULL,
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
    [{nc39}] [smallint] NULL,
    [{nc40}] [smallint] NULL,
    [{nc44}] [smallint] NULL,
    [{nc46}] [smallint] NOT NULL
    ");

        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                $@"[{nc03}],[{nc04}],[{nc05}],[{ nc11 }],[{nc12}],[{nc13}],[{nc14}],[{nc15}],[{nc16}],[{nc17}],[{nc18}],[{nc19}],[{nc20}],[{nc21}],[{nc22}],[{nc23}],[{nc24}],[{nc25}],
[{nc26}],[{nc27}],[{nc28}],[{nc29}],[{nc30}],[{nc31}],[{nc32}],[{nc33}],[{nc34}],[{nc35}],[{nc36}],[{nc37}],[{nc38}],[{nc39}],[{nc40}],[{nc44}],[{nc46}]",
                    $@"@{nc03},@{nc04},@{nc05},@{nc11},@{nc12},@{nc13},@{nc14},@{nc15},@{nc16},@{nc17},@{nc18},@{nc19},@{nc20},@{nc21},@{nc22},@{nc23},@{nc24},@{nc25},
@{nc26},@{nc27},@{nc28},@{nc29},@{nc30},@{nc31},@{nc32},@{nc33},@{nc34},@{nc35},@{nc36},@{nc37},@{nc38},@{nc39},@{nc40},@{nc44},@{nc46}"
                    ), sqlCon);

                AddDefaultParameters(cmd);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.NVarChar,100 );
                cmd.Parameters.Add($"@{nc13}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc15}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc18}", SqlDbType.Int);
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
                cmd.Parameters.Add($"@{nc39}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc40}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc44}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc46}", SqlDbType.SmallInt);
                
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

