using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class DomicileHolderPeriodTab : SqlQueries
    {
        public DomicileHolderPeriodTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT336";
        public override string NewTableName => "DomicileHolderPeriod";
        protected override int ColCount => 9;
        protected override string ColShortcut => "IT";

        protected override int cCr => 5;
        protected override int cCrId => 6;
        protected override int cMd => 7;
        protected override int cMdId => 8;
        protected override int cNote => 9;

        private readonly string nc01 = "MandateId";
        private readonly string nc02 = "DomicileHolderId";
        private readonly string nc03 = "From";
        private readonly string nc04 = "To";
        
        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
[{nc02}] [int] NULL,
[{nc03}] [smalldatetime] NULL,
[{nc04}] [smalldatetime] NULL");
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
                cmd.Parameters.Add($"@{nc03}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.SmallDateTime);                
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
