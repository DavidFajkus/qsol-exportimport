using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class DocumentFolderRelationTab : SqlQueries
    {
        public DocumentFolderRelationTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT379";
        public override string NewTableName => "DocumentFolderRelation";
        protected override int ColCount => 4;
        protected override string ColShortcut => "IT";
                
        protected override int cMd => 3;
        protected override int cMdId => 4;
        
        private readonly string nc01 = "FolderId";
        private readonly string nc02 = "DocumentId";
        
        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
[{nc02}] [int] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}]",
                    $@"@{ nc01},@{nc02}"
                ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);                
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

