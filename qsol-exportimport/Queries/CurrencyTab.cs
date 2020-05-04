using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class CurrencyTab : SqlQueries
    {
        public CurrencyTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT005";
        public override string NewTableName => "Currency";
        protected override int ColCount => 9;
        protected override string ColShortcut => "IT";

        protected override int cCr => 5;
        protected override int cCrId => 6;
        protected override int cMd => 7;
        protected override int cMdId => 8;
        protected override int cNote => 9;

        private readonly string nc01 = "Code";
        private readonly string nc02 = "Designation";
        private readonly string nc03 = "Unit";
        private readonly string nc04 = "Factor";
        
        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [nvarchar](6) NULL,
	[{nc02}] [nvarchar](30) NULL,
	[{nc03}] [int] NULL,	
	[{nc04}] [float] NULL");
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

                cmd.Parameters.Add($"@{nc01}", SqlDbType.NVarChar, 6);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.Float);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
