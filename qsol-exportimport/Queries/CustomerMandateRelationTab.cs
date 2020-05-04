using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class CustomerMandateRelationTab : SqlQueries
    {
        public CustomerMandateRelationTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT016";
        public override string NewTableName => "CustomerMandateRelation";
        protected override int ColCount => 8;
        protected override string ColShortcut => "IT";

        protected override int cCr => 3;
        protected override int cCrId => 4;
        protected override int cMd => 5;
        protected override int cMdId => 6;
        protected override int cNote => 7;

        private readonly string nc01 = "CustomerId";
        private readonly string nc02 = "MandateId";
        private readonly string nc11 = "Deleted";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL, [{nc02}] [int] NULL, [{nc11}] [smallint] NOT NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc11}]",
                    $@"@{nc01},@{nc02},@{nc11}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
