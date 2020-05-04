using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class OutboxTab : SqlQueries
    {
        public OutboxTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT098";
        public override string NewTableName => "Outbox";
        protected override int ColCount => 35;
        protected override string ColShortcut => "IT";

        protected override int cCr => 11;
        protected override int cCrId => 12;
        protected override int cMd => 13;
        protected override int cMdId => 14;
        protected override int cNote => 15;

        protected override string columns => @"ITF001,ITF002,ITF003,ITF004,ITF005,ITF006,ITF007,ITF008,ITF009,ITF010,ITF017,ITF018,ITF019,ITF020,
ITF021,ITF022,ITF023,ITF024,ITF025,ITF026,ITF028,ITF034,ITF035,ITF036,ITF037,ITF038,ITF039,ITF041,ITF042,ITF044";

        private readonly string nc01 = "To";
        private readonly string nc02 = "Cc";
        private readonly string nc03 = "Bcc";
        private readonly string nc04 = "Subject";
        private readonly string nc05 = "Text";        
        private readonly string nc06 = "Importance";
        private readonly string nc07 = "RequireConfirmation";
        private readonly string nc08 = "Seen";
        private readonly string nc09 = "SendWhoId";
        private readonly string nc10 = "SendWho";        
        private readonly string nc17 = "ServerSend";
        private readonly string nc18 = "SmtpId";
        private readonly string nc19 = "ServerId";
        private readonly string nc20 = "Html";
        private readonly string nc21 = "ParentId";
        private readonly string nc22 = "SubmitFromParent";
        private readonly string nc23 = "LastSendType";
        private readonly string nc24 = "Mark";
        private readonly string nc25 = "MarkStatus";
        private readonly string nc26 = "MessageId";        
        private readonly string nc28 = "RebuhId";        
        private readonly string nc34 = "ToRelease";
        private readonly string nc35 = "ToReleaseWhoId";
        private readonly string nc36 = "Executed";
        private readonly string nc37 = "ExecutedDate";
        private readonly string nc38 = "ExecutedWhoId";        
        private readonly string nc39 = "MarkColor";
        private readonly string nc41 = "Uid";
        private readonly string nc42 = "Deleted";
        private readonly string nc44 = "OnlyAccountAuthority";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [nvarchar](4000) NULL,	
    [{nc02}] [nvarchar](4000) NULL,
    [{nc03}] [nvarchar](4000) NULL,
	[{nc04}] [nvarchar](254) NULL,
    [{nc05}] [ntext] NULL,
    [{nc06}] [smallint] NOT NULL,
    [{nc07}] [smallint] NOT NULL,
    [{nc08}] [datetime] NULL,
    [{nc09}] [int] NULL,
    [{nc10}] [nvarchar](250) NULL,
	[{nc17}] [datetime] NULL,	
    [{nc18}] [int] NULL,	    
    [{nc19}] [int] NULL,
    [{nc20}] [ntext] NULL,
    [{nc21}] [int] NULL,
    [{nc22}] [smallint] NULL,
    [{nc23}] [smallint] NULL,
    [{nc24}] [nvarchar](50) NULL,
    [{nc25}] [datetime] NULL,
    [{nc26}] [nvarchar](250) NULL,
    [{nc28}] [int] NULL,    
    [{nc34}] [datetime] NULL,
    [{nc35}] [int] NULL,
    [{nc36}] [smallint] NOT NULL,
    [{nc37}] [smalldatetime] NULL,
    [{nc38}] [int] NULL,
    [{nc39}] [nvarchar](10) NULL,
    [{nc41}] [nvarchar](254) NULL,
    [{nc42}] [smallint] NOT NULL,
    [{nc44}] [smallint] NULL");

        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc10}],[{nc17}],[{nc18}],[{nc19}],[{nc20}],
[{nc21}],[{nc22}],[{nc23}],[{nc24}],[{nc25}],[{nc26}],[{nc28}],[{nc34}],[{nc35}],[{nc36}],[{nc37}],[{nc38}],[{nc39}],[{nc41}],[{nc42}],[{nc44}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc09},@{nc10},@{nc17},@{nc18},@{nc19},@{nc20},
@{nc21},@{nc22},@{nc23},@{nc24},@{nc25},@{nc26},@{nc28},@{nc34},@{nc35},@{nc36},@{nc37},@{nc38},@{nc39},@{nc41},@{nc42},@{nc44}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.NVarChar, 4000);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 4000);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar, 4000);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.NVarChar, 254);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.NText);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.NVarChar, 250); 
                cmd.Parameters.Add($"@{nc17}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc18}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.NText);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc22}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc23}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc24}", SqlDbType.NVarChar,50);
                cmd.Parameters.Add($"@{nc25}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc26}", SqlDbType.NVarChar,250);
                cmd.Parameters.Add($"@{nc28}", SqlDbType.Int);                
                cmd.Parameters.Add($"@{nc34}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc35}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc36}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc37}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc38}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc39}", SqlDbType.NVarChar,10);
                cmd.Parameters.Add($"@{nc41}", SqlDbType.NVarChar, 254);
                cmd.Parameters.Add($"@{nc42}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc44}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

