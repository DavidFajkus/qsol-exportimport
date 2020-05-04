using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class PCBActivityRelationTab : SqlQueries
    {
        public PCBActivityRelationTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT373";
        public override string NewTableName => "PCBActivityRelation";
        protected override int ColCount => 7;
        protected override string ColShortcut => "IT";

        protected override int cCr => 4;
        protected override int cCrId => 5;
        protected override int cMd => 6;
        protected override int cMdId => 7;
        
        private readonly string nc01 = "ActivityTypeId";
        private readonly string nc02 = "PCBId";
        private readonly string nc03 = "AddIn";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
[{nc02}] [int] NOT NULL,
[{nc03}] [nvarchar](100) NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}]",
                    $@"@{nc01},@{nc02},@{nc03}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
