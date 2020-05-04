using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class DocumentSubtypeTab : SqlQueries
    {
        public DocumentSubtypeTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT315";
        public override string NewTableName => "DocumentSubtype";
        protected override int ColCount => 9;
        protected override string ColShortcut => "IT";

        protected override int cCr => 3;
        protected override int cCrId => 4;
        protected override int cMd => 5;
        protected override int cMdId => 6;
        protected override int cNote => 7;
                
        private readonly string nc01 = "DocumentTypeId";
        private readonly string nc02 = "Name";        
        private readonly string nc08 = "DocRegisterId";
        private readonly string nc09 = "OnlyAuthority";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
[{nc02}] [nvarchar](50) NULL,
[{nc08}] [int] NULL,
[{nc09}] [smallint] NOT NULL");

        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc08}],[{nc09}]", $@"@{nc01},@{nc02},@{nc08},@{nc09}"), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 50);                
                cmd.Parameters.Add($"@{nc08}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);


                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

