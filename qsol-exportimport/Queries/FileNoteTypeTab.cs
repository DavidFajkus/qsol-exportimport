using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class FileNoteTypeTab : SqlQueries
    {
        public FileNoteTypeTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT062";
        public override string NewTableName => "FileNoteType";
        protected override int ColCount => 14;
        protected override string ColShortcut => "IT";

        protected override int cCr => 5;
        protected override int cCrId => 6;
        protected override int cMd => 7;
        protected override int cMdId => 8;
        protected override int cNote => 9;
        
        private readonly string nc01 = "FileNoteRelationId";
        private readonly string nc02 = "NameGr";
        private readonly string nc03 = "Locked";
        private readonly string nc04 = "LockedWhoId";
        private readonly string nc10 = "NameEn";
        private readonly string nc11 = "NameFr";
        private readonly string nc12 = "NamePo";
        private readonly string nc13 = "NameSp";
        private readonly string nc14 = "NameIt";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
	[{nc02}] [nvarchar](50) NULL,
	[{nc03}] [smallint] NOT NULL,		
    [{nc04}] [int] NOT NULL,
    [{nc10}] [nvarchar](50) NULL,
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
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.NVarChar, 50);
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

