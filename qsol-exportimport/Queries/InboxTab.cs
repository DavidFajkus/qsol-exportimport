using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class InboxTab : SqlQueries
    {
        public InboxTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT097";
        public override string NewTableName => "Inbox";
        protected override int ColCount => 35;
        protected override string ColShortcut => "IT";

        protected override int cMd => 45;
        protected override int cMdId => 46;

        protected override string columns => @"ITF001,ITF002,ITF003,ITF004,ITF005,ITF006,ITF007,ITF008,ITF009,ITF010,ITF011,ITF012,ITF013,ITF015,ITF017,ITF018,ITF019,ITF020,
ITF021,ITF022,ITF023,ITF024,ITF025,ITF027,ITF028,ITF033,ITF034,ITF035,ITF036,ITF037,ITF038,ITF039,ITF040";

        private readonly string nc01 = "To";
        private readonly string nc02 = "Cc";
        private readonly string nc03 = "Bcc";
        private readonly string nc04 = "Subject";
        private readonly string nc05 = "Header";
        private readonly string nc06 = "Text";        
        private readonly string nc07 = "Importance";        
        private readonly string nc08 = "MessageId";
        private readonly string nc09 = "Seen";
        private readonly string nc10 = "SeenWhoId";
        private readonly string nc11 = "Receive";
        private readonly string nc12 = "ReceiveWho";
        private readonly string nc13 = "PostServerId";
        private readonly string nc15 = "UserId";
        private readonly string nc17 = "Uid";
        private readonly string nc18 = "Html";        
        private readonly string nc19 = "Deleted";
        private readonly string nc20 = "LastSendType";
        private readonly string nc21 = "Mark";
        private readonly string nc22 = "SeenConfirm";
        private readonly string nc23 = "MarkStatus";
        private readonly string nc24 = "Confirm";
        private readonly string nc25 = "IsConfirm";        
        private readonly string nc27 = "Spam";
        private readonly string nc28 = "AnswerId";
        private readonly string nc33 = "Executed";
        private readonly string nc34 = "ExecutedDate";
        private readonly string nc35 = "ExecutedWhoId";
        private readonly string nc36 = "OnlyAccountAuthority";
        private readonly string nc37 = "xSpamStatus";
        private readonly string nc38 = "xSpamScore";
        private readonly string nc39 = "xSpamLevel";
        private readonly string nc40 = "MarkColor";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [nvarchar](4000) NULL,	
    [{nc02}] [nvarchar](4000) NULL,
    [{nc03}] [nvarchar](4000) NULL,
	[{nc04}] [nvarchar](254) NULL,
    [{nc05}] [ntext] NULL,
    [{nc06}] [ntext] NULL,
    [{nc07}] [smallint] NOT NULL,
    [{nc08}] [nvarchar](250) NULL,
    [{nc09}] [smalldatetime] NULL,
    [{nc10}] [int] NULL,
	[{nc11}] [datetime] NULL,	
    [{nc12}] [nvarchar](254) NULL,	
    [{nc13}] [int] NULL,	
    [{nc15}] [int] NULL,	    
	[{nc17}] [nvarchar](254) NULL,	
    [{nc18}] [ntext] NULL,	    
    [{nc19}] [smallint] NOT NULL,
    [{nc20}] [smallint] NULL,
    [{nc21}] [nvarchar](50) NULL,
    [{nc22}] [nvarchar](250) NULL,
    [{nc23}] [datetime] NULL,
    [{nc24}] [smallint] NOT NULL,
    [{nc25}] [smallint] NOT NULL,
    [{nc27}] [smallint] NOT NULL,
    [{nc28}] [int] NULL,
    [{nc33}] [smallint] NOT NULL,
    [{nc34}] [smalldatetime] NULL,
    [{nc35}] [int] NULL,
    [{nc36}] [smallint] NOT NULL,
    [{nc37}] [smallint] NULL,
    [{nc38}] [real] NULL,
    [{nc39}] [smallint] NULL,
    [{nc40}] [nvarchar](10) NULL");

        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc10}],[{nc11}],[{nc12}],[{nc13}],[{nc15}],[{nc17}],[{nc18}],[{nc19}],[{nc20}],
[{nc21}],[{nc22}],[{nc23}],[{nc24}],[{nc25}],[{nc27}],[{nc28}],[{nc33}],[{nc34}],[{nc35}],[{nc36}],[{nc37}],[{nc38}],[{nc39}],[{nc40}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc09},@{nc10},@{nc11},@{nc12},@{nc13},@{nc15},@{nc17},@{nc18},@{nc19},@{nc20},
@{nc21},@{nc22},@{nc23},@{nc24},@{nc25},@{nc27},@{nc28},@{nc33},@{nc34},@{nc35},@{nc36},@{nc37},@{nc38},@{nc39},@{nc40}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.NVarChar,4000);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar,4000);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar, 4000);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.NVarChar, 254);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.NText);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.NText);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.NVarChar,250);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.NVarChar,254);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc15}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.NVarChar,254);
                cmd.Parameters.Add($"@{nc18}", SqlDbType.NText);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.NVarChar,50);
                cmd.Parameters.Add($"@{nc22}", SqlDbType.NVarChar,250);
                cmd.Parameters.Add($"@{nc23}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc24}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc25}", SqlDbType.SmallInt);                
                cmd.Parameters.Add($"@{nc27}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc28}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc33}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc34}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc35}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc36}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc37}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc38}", SqlDbType.Real);
                cmd.Parameters.Add($"@{nc39}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc40}", SqlDbType.NVarChar, 10);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

