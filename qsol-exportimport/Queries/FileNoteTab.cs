using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class FileNoteTab : SqlQueries
    {
        public FileNoteTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT063";
        public override string NewTableName => "FileNote";
        protected override int ColCount => 12;
        protected override string ColShortcut => "IT";

        protected override int cCr => 6;
        protected override int cCrId => 7;
        protected override int cMd => 8;
        protected override int cMdId => 9;
        protected override int cNote => 10;
        protected override string columns => "ITF001,ITF002,ITF003,ITF011,ITF012,ITF013,ITF014";

        private readonly string nc01 = "FileNoteTypeId";
        private readonly string nc02 = "FileNote";
        private readonly string nc03 = "GeneralNr";
        private readonly string nc11 = "SecondFileNoteId";
        private readonly string nc12 = "Deleted";
        private readonly string nc13 = "SecondId";
        private readonly string nc14 = "Date";
        
        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
	[{nc02}] [nvarchar](MAX) NULL,
	[{nc03}] [int] NULL,		
	[{nc11}] [int] NULL,
	[{nc12}] [smallint] NOT NULL,
	[{nc13}] [int] NULL,
	[{nc14}] [smalldatetime] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc11}],[{nc12}],[{nc13}],[{nc14}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc11},@{nc12},@{nc13},@{nc14}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, -1);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

