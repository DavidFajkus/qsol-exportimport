using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class RoleTab : SqlQueries
    {
        public RoleTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT339";
        public override string NewTableName => "Role";
        protected override int ColCount => 12;
        protected override string ColShortcut => "IT";

        protected override int cCr => 7;
        protected override int cCrId => 8;
        protected override int cMd => 9;
        protected override int cMdId => 10;
        protected override int cNote => 11;

        private readonly string nc01 = "NameGr";
        private readonly string nc02 = "NameEn";
        private readonly string nc03 = "NameFr";
        private readonly string nc04 = "NamePo";
        private readonly string nc05 = "NameSp";
        private readonly string nc06 = "NameIt";
        private readonly string nc12 = "Participation";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [nvarchar](50) NULL,
	[{nc02}] [nvarchar](50) NULL,
	[{nc03}] [nvarchar](50) NULL,	
	[{nc04}] [nvarchar](50) NULL,
	[{nc05}] [nvarchar](50) NULL,
	[{nc06}] [nvarchar](50) NULL,
	[{nc12}] [smallint] NOT NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc12}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc12}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.NVarChar,50);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.NVarChar,50);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
