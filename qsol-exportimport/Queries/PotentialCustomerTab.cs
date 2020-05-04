using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
     public class PotentialCustomerTab : SqlQueries
    {
        public PotentialCustomerTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT375";
        public override string NewTableName => "PotentialCustomer";
        protected override int ColCount => 12;
        protected override string ColShortcut => "IT";

        protected override int cCr => 3;
        protected override int cCrId => 4;
        protected override int cMd => 5;
        protected override int cMdId => 6;
        protected override int cNote => 7;

        private readonly string nc01 = "RoleId";
        private readonly string nc02 = "NameGr";
        private readonly string nc08 = "NameEn";
        private readonly string nc09 = "NameFr";
        private readonly string nc10 = "NamePo";
        private readonly string nc11 = "CodeSp";
        private readonly string nc12 = "CodeFr";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
	[{nc02}] [nvarchar](15) NULL,
	[{nc08}] [nvarchar](50) NULL,	
	[{nc09}] [nvarchar](50) NULL,
	[{nc10}] [nvarchar] (50) NULL,
	[{nc11}] [nvarchar](50) NULL,
	[{nc12}] [nvarchar](50) NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc08}],[{nc09}],[{nc10}],[{nc11}],[{nc12}]",
                    $@"@{nc01},@{nc02},@{nc08},@{nc09},@{nc10},@{nc11},@{nc12}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
