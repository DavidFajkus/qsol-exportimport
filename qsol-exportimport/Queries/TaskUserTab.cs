using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class TaskUserTab : SqlQueries
    {
        public TaskUserTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT074";
        public override string NewTableName => "TaskUser";
        protected override int ColCount => 25;
        protected override string ColShortcut => "IT";

        protected override int cCr => 8;
        protected override int cCrId => 9;
        protected override int cMd => 10;
        protected override int cMdId => 11;
        protected override int cNote => 12;

        private readonly string nc01 = "TaskId";
        private readonly string nc02 = "ParentId";
        private readonly string nc03 = "UserId";
        private readonly string nc04 = "Level";
        private readonly string nc05 = "Since";
        private readonly string nc06 = "Till";
        private readonly string nc07 = "Part";
        private readonly string nc13 = "Deleted";
        private readonly string nc14 = "Executed";
        private readonly string nc15 = "ExecutedDate";
        private readonly string nc16 = "ExecutedWho";
        private readonly string nc17 = "Reminder";
        private readonly string nc18 = "ReminderBeforeDay";
        private readonly string nc19 = "ReminderSeen";
        private readonly string nc20 = "ReminderAgainWhen";
        private readonly string nc21 = "ReminderAgainDay";
        private readonly string nc22 = "ReminderAgainHour";
        private readonly string nc23 = "ReminderMin";
        private readonly string nc24 = "StatusType";
        private readonly string nc25 = "Status";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
	[{nc02}] [int] NULL,
	[{nc03}] [int] NULL,	
	[{nc04}] [int] NULL,
    [{nc05}] [datetime] NULL,
    [{nc06}] [datetime] NULL,
    [{nc07}] [float] NULL,	
	[{nc13}] [smallint] NOT NULL,
	[{nc14}] [smallint] NOT NULL,
	[{nc15}] [smalldatetime] NULL,
	[{nc16}] [int] NULL,
	[{nc17}] [smallint] NOT NULL,
	[{nc18}] [smallint] NULL,
    [{nc19}] [smallint] NOT NULL,
    [{nc20}] [smalldatetime] NULL,
    [{nc21}] [smallint] NULL,
    [{nc22}] [smallint] NULL,
    [{nc23}] [smallint] NULL,
    [{nc24}] [smallint] NOT NULL,
    [{nc25}] [smallint] NOT NULL");

        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc13}],[{nc14}],[{nc15}],[{nc16}],[{nc17}],[{nc18}],[{nc19}],[{nc20}],[{nc21}],[{nc22}],[{nc23}],[{nc24}],[{nc25}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc13},@{nc14},@{nc15},@{nc16},@{nc17},@{nc18},@{nc19},@{nc20},@{nc21},@{nc22},@{nc23},@{nc24},@{nc25}"
                    ), sqlCon);
                    
                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.Float);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc15}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc18}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc22}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc23}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc24}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc25}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

