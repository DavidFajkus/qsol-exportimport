using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class UserTab : SqlQueries
    {
        public UserTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "SC005";
        public override string NewTableName => "User";
        protected override int ColCount => 26;
        protected override string ColShortcut => "SC";

        protected override int cCr => 21;
        protected override int cCrId => 22;
        protected override int cMd => 23;
        protected override int cMdId => 24;
        protected override int cNote => 25;
        protected override string columns => "SCF001,SCF002,SCF004,SCF005,SCF006,SCF007,SCF008,SCF009,SCF010,SCF011,SCF012,SCF013,SCF014,SCF015,SCF016,SCF017,SCF018,SCF019,SCF020,SCF026";

        private readonly string nc01 = "Name";
        private readonly string nc02 = "Login";
        //private readonly string nc03 = "Password";
        private readonly string nc04 = "FirstName";
        private readonly string nc05 = "Function";
        private readonly string nc06 = "Titel";
        private readonly string nc07 = "Street";
        private readonly string nc08 = "Street2";
        private readonly string nc09 = "PostCode";
        private readonly string nc10 = "Place";
        private readonly string nc11 = "Country";
        private readonly string nc12 = "CommencementDate";
        private readonly string nc13 = "Level";
        private readonly string nc14 = "AuthorizationType";
        private readonly string nc15 = "BirthDate";
        private readonly string nc16 = "MotherTongue";
        private readonly string nc17 = "Leaving";
        private readonly string nc18 = "LeavingReason";
        private readonly string nc19 = "Blocked";
        private readonly string nc20 = "Deputy";
        private readonly string nc26 = "EmploymentLevel";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [nvarchar] (30) NULL,
	[{nc02}] [nvarchar] (11) NULL,	
	[{nc04}] [nvarchar] (30) NULL,
	[{nc05}] [nvarchar] (30) NULL,
	[{nc06}] [nvarchar] (30) NULL,
	[{nc07}] [nvarchar] (30) NULL,
	[{nc08}] [nvarchar] (30) NULL,
	[{nc09}] [nvarchar] (10) NULL,
	[{nc10}] [nvarchar] (20) NULL,
	[{nc11}] [nvarchar] (30) NULL,
	[{nc12}] [smalldatetime] NULL,
	[{nc13}] [int] NULL,
	[{nc14}] [nvarchar] (30) NULL,
	[{nc15}] [smalldatetime] NULL,
	[{nc16}] [nvarchar] (15) NULL,
	[{nc17}] [smalldatetime] NULL,
	[{nc18}] [ntext] NULL,
	[{nc19}] [smallint] NOT NULL DEFAULT((0)),
	[{nc20}] [int] NULL,	
	[{nc26}] [int] NULL");
    }
        
        public override void Insert(SqlDataReader reader, SqlConnection SqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;
            
            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert($@"[{nc01}],[{nc02}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc10}],
[{nc11}],[{nc12}],[{nc13}],[{nc14}],[{nc15}],[{nc16}],[{nc17}],[{nc18}],[{nc19}],[{nc20}],[{nc26}]",
                $@"@{nc01},@{nc02},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc09},@{nc10},
@{nc11},@{nc12},@{nc13},@{nc14},@{nc15},@{nc16},@{nc17},@{nc18},@{nc19},@{nc20},@{nc26}"
                    ), SqlCon);

                AddDefaultParameters(cmd);
                
                cmd.Parameters.Add($"@{nc01}", SqlDbType.NVarChar,30);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 11);
                //cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.NVarChar, 10);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc15}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.NVarChar,15);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc18}", SqlDbType.NText);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc26}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);
                
                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
