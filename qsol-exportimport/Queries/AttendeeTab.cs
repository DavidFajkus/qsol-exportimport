using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class AttendeeTab : SqlQueries
    {
        public AttendeeTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT037";
        public override string NewTableName => "Attendee";
        protected override int ColCount => 22;
        protected override string ColShortcut => "IT";

        protected override int cCr => 6;
        protected override int cCrId => 7;
        protected override int cMd => 8;
        protected override int cMdId => 9;
        protected override int cNote => 10;

        private readonly string nc01 = "AppointmentId";
        private readonly string nc02 = "UserId";
        private readonly string nc03 = "Since";
        private readonly string nc04 = "Till";
        private readonly string nc05 = "Part";
        private readonly string nc11 = "Deleted";
        private readonly string nc12 = "Type";
        private readonly string nc13 = "AllDay";
        private readonly string nc14 = "WithoutWeek";
        private readonly string nc15 = "Reminder";
        private readonly string nc16 = "ReminderAgoHour";
        private readonly string nc17 = "ReminderAgoMin";
        private readonly string nc18 = "ReminderSeen";
        private readonly string nc19 = "ReminderDate";
        private readonly string nc20 = "ReminderAgainDay";
        private readonly string nc21 = "ReminderAgainHour";
        private readonly string nc22 = "ReminderMin";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
	[{nc02}] [int] NULL,
	[{nc03}] [datetime] NULL,	
	[{nc04}] [datetime] NULL,
    [{nc05}] [float] NULL,
	[{nc11}] [smallint] NOT NULL,
	[{nc12}] [smallint] NULL,
	[{nc13}] [smallint] NOT NULL,
	[{nc14}] [smallint] NOT NULL,
	[{nc15}] [smallint] NOT NULL,
	[{nc16}] [smallint] NULL,
	[{nc17}] [smallint] NULL,
	[{nc18}] [smallint] NOT NULL,
    [{nc19}] [smalldatetime] NULL,
    [{nc20}] [smallint] NULL,
    [{nc21}] [smallint] NULL,
    [{nc22}] [smallint] NULL");

        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc11}],[{nc12}],[{nc13}],[{nc14}],[{nc15}],[{nc16}],[{nc17}],[{nc18}],[{nc19}],[{nc20}],[{nc21}],[{nc22}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc11},@{nc12},@{nc13},@{nc14},@{nc15},@{nc16},@{nc17},@{nc18},@{nc19},@{nc20},@{nc21},@{nc22}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.Float);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc15}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc18}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc22}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

