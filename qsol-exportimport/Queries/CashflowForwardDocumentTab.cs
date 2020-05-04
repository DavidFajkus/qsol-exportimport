using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class CashflowForwardDocumentTab : SqlQueries
    {
        public CashflowForwardDocumentTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT186";
        public override string NewTableName => "CashflowForwardDocument";
        protected override int ColCount => 5;
        protected override string ColShortcut => "IT";

        private readonly string nc01 = "DocumentId";
        private readonly string nc02 = "OwnerType";
        private readonly string nc03 = "RowId";
        private readonly string nc04 = "Order";
        private readonly string nc05 = "ForwardId";
        
        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL, 
[{nc02}] [smallint] NULL,
[{nc03}] [int] NULL,
[{nc04}] [smallint] NULL,
[{nc05}] [int] NULL"
);
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
