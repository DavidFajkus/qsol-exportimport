using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class TelephoneActivityTypeTab : SqlQueries
    {
        public TelephoneActivityTypeTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT038";
        public override string NewTableName => "TelephoneActivityType";
        protected override int ColCount => 7;
        protected override string ColShortcut => "IT";

        protected override int cCr => 3;
        protected override int cCrId => 4;
        protected override int cMd => 5;
        protected override int cMdId => 6;
        protected override int cNote => 7;

        private readonly string nc01 = "Type";
        private readonly string nc02 = "Blocked";
        
        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [nvarchar](50) NULL,
	[{nc02}] [smallint] NOT NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}]",
                    $@"@{nc01},@{nc02}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.NVarChar,50);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.SmallInt);               
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
