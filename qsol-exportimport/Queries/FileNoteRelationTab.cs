using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class FileNoteRelationTab : SqlQueries
    {
        public FileNoteRelationTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT061";
        public override string NewTableName => "FileNoteRelation";
        protected override int ColCount => 14;
        protected override string ColShortcut => "IT";

        protected override int cCr => 4;
        protected override int cCrId => 5;
        protected override int cMd => 6;
        protected override int cMdId => 7;
        protected override int cNote => 8;
        protected override string columns => "ITF002,ITF003,ITF009,ITF010,ITF011,ITF012,ITF013,ITF014,ITF015";

        private readonly string nc02 = "ModuleId";        
        private readonly string nc03 = "FormId";
        private readonly string nc09 = "NameGr";
        private readonly string nc10 = "NameEn";
        private readonly string nc11 = "WithoutPCB";
        private readonly string nc12 = "NameFr";
        private readonly string nc13 = "NamePo";
        private readonly string nc14 = "NameSp";
        private readonly string nc15 = "NameIt";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc02}] [int] NULL,
	[{nc03}] [int] NULL,
    [{nc09}] [nvarchar](50) NULL,
    [{nc10}] [nvarchar](50) NULL,
	[{nc11}] [smallint] NOT NULL,
	[{nc12}] [nvarchar](50) NULL,
	[{nc13}] [nvarchar](50) NULL,
    [{nc14}] [nvarchar](50) NULL,
	[{nc15}] [nvarchar](50) NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc02}],[{nc03}],[{nc09}],[{nc10}],[{nc11}],[{nc12}],[{nc13}],[{nc14}],[{nc15}]",
                    $@"@{nc02},@{nc03},@{nc09},@{nc10},@{nc11},@{nc12},@{nc13},@{nc14},@{nc15}"
                    ), sqlCon);

                AddDefaultParameters(cmd);
                
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc15}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

