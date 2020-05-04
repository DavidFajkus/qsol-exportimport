using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class CodeTab : SqlQueries
    {
        public CodeTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT012";
        public override string NewTableName => "Code";
        protected override int ColCount => 14;
        protected override string ColShortcut => "IT";

        protected override int cCr => 5;
        protected override int cCrId => 6;
        protected override int cMd => 7;
        protected override int cMdId => 8;
        protected override int cNote => 9;
        protected override string columns => "ITF001,ITF002,ITF003,ITF004,ITF010,ITF011,ITF012,ITF013,ITF014";

        private readonly string nc01 = "CodeGroupId";
        private readonly string nc02 = "CodeAdd";
        private readonly string nc03 = "CodeGr";
        private readonly string nc04 = "CodeEn";
        private readonly string nc10 = "Blocked";
        private readonly string nc11 = "CodeFr";
        private readonly string nc12 = "CodePo";
        private readonly string nc13 = "CodeSp";
        private readonly string nc14 = "CodeIt";
        
        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
	[{nc02}] [nvarchar](15) NULL,
	[{nc03}] [nvarchar](50) NULL,	
	[{nc04}] [nvarchar](50) NULL,
	[{nc10}] [smallint] NOT NULL,
	[{nc11}] [nvarchar](50) NULL,
	[{nc12}] [nvarchar](50) NULL,
	[{nc13}] [nvarchar](50) NULL,
	[{nc14}] [nvarchar](50) NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc10}],[{nc11}],[{nc12}],[{nc13}],[{nc14}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc10},@{nc11},@{nc12},@{nc13},@{nc14}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 15);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
