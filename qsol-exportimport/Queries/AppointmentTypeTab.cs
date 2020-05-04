using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class AppointmentTypeTab : SqlQueries
    {
        public AppointmentTypeTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT035";
        public override string NewTableName => "AppointmentType";
        protected override int ColCount => 13;
        protected override string ColShortcut => "IT";

        protected override int cCr => 4;
        protected override int cCrId => 5;
        protected override int cMd => 6;
        protected override int cMdId => 7;
        protected override int cNote => 8;

        private readonly string nc01 = "Name";
        private readonly string nc02 = "Recurrent";
        private readonly string nc03 = "Blocked";
        private readonly string nc09 = "Color";
        private readonly string nc10 = "Provisionally";
        private readonly string nc11 = "ProvisionallyAuthority";
        private readonly string nc12 = "ProvisionallyAuthorityUserId";
        private readonly string nc13 = "YearColor";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [nvarchar](50) NULL,
[{nc02}] [smallint] NULL,
[{nc03}] [smallint] NOT NULL,
[{nc09}] [int] NULL,
[{nc10}] [smallint] NOT NULL,
[{nc11}] [smallint] NULL,
[{nc12}] [int] NULL,
[{nc13}] [int] NULL
");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc09}],[{nc10}],[{nc11}],[{nc12}],[{nc13}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc09},@{nc10},@{nc11},@{nc12},@{nc13}"), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);


                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}

