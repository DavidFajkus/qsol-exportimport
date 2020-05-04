using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class DocumentTypeTab : SqlQueries
    {
        public DocumentTypeTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT068";
        public override string NewTableName => "DocumentType";
        protected override int ColCount => 10;
        protected override string ColShortcut => "IT";

        protected override int cCr => 3;
        protected override int cCrId => 4;
        protected override int cMd => 5;
        protected override int cMdId => 6;
        protected override int cNote => 7;

        private readonly string nc01 = "Name";
        private readonly string nc02 = "Blocked";
        private readonly string nc08 = "MandateAuthority";
        private readonly string nc09 = "ModuleId";
        private readonly string nc10 = "DocRegisterId";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [nvarchar](50) NULL,
[{nc02}] [smallint] NOT NULL,
[{nc08}] [smallint] NOT NULL,
[{nc09}] [int] NULL,
[{nc10}] [int] NULL");

        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc08}],[{nc09}],[{nc10}]", $@"@{nc01},@{nc02},@{nc08},@{nc09},@{nc10}"), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);


                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

