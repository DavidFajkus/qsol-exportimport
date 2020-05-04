using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class CashflowForwardTab : SqlQueries
    {
        public CashflowForwardTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT093";
        public override string NewTableName => "CashflowForward";
        protected override int ColCount => 7;
        protected override string ColShortcut => "IT";

        protected override int cCr => 5;
        protected override int cCrId => 6;        
        protected override int cNote => 7;

        private readonly string nc01 = "ForwardId";
        private readonly string nc02 = "CashflowId";
        private readonly string nc03 = "CashflowInternalId";
        private readonly string nc04 = "Deleted";
        
        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL, 
[{nc02}] [int] NULL,
[{nc03}] [int] NULL,
[{nc04}] [smallint] NOT NULL"
);
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
