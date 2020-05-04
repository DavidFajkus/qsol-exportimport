using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class CountryTab : SqlQueries
    {
        public CountryTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT017";
        public override string NewTableName => "Country";
        protected override int ColCount => 17;
        protected override string ColShortcut => "IT";

        protected override int cCr => 4;
        protected override int cCrId => 5;
        protected override int cMd => 6;
        protected override int cMdId => 7;
        protected override int cNote => 8;

        private readonly string nc01 = "Shortcut";
        private readonly string nc02 = "NameGr";
        private readonly string nc03 = "TelPrefixInt";
        private readonly string nc09 = "States";
        private readonly string nc10 = "RiskGroup";
        private readonly string nc11 = "NameEn";
        private readonly string nc12 = "NameFr";
        private readonly string nc13 = "NamePo";
        private readonly string nc14 = "NameSp";
        private readonly string nc15 = "NameIt";
        private readonly string nc16 = "IsoCode";
        private readonly string nc17 = "IBANSize";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [nvarchar](5) NULL,
	[{nc02}] [nvarchar](50) NULL,
	[{nc03}] [nvarchar](7) NULL,	
	[{nc09}] [smallint] NOT NULL DEFAULT (0),
	[{nc10}] [int] NULL,
	[{nc11}] [nvarchar](50) NULL,
	[{nc12}] [nvarchar](50) NULL,
	[{nc13}] [nvarchar](50) NULL,
	[{nc14}] [nvarchar](50) NULL,
	[{nc15}] [nvarchar](50) NULL,
	[{nc16}] [nvarchar](3) NULL,
	[{nc17}] [smallint] NULL");
        }
        
        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;
            
            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc09}],[{nc10}],[{nc11}],[{nc12}],[{nc13}],[{nc14}],[{nc15}],[{nc16}],[{nc17}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc09},@{nc10},@{nc11},@{nc12},@{nc13},@{nc14},@{nc15},@{nc16},@{nc17}"
                    ), sqlCon);

                AddDefaultParameters(cmd);
                
                cmd.Parameters.Add($"@{nc01}", SqlDbType.NVarChar, 5);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar, 7);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc15}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.NVarChar, 3);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
