using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    class EmailAddressTab : SqlQueries
    {
        public EmailAddressTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT106";
        public override string NewTableName => "EmailAddress";
        protected override int ColCount => 15;
        protected override string ColShortcut => "IT";

        protected override int cCr => 9;
        protected override int cCrId => 10;
        protected override int cMd => 11;
        protected override int cMdId => 12;
        protected override int cNote => 13;
        
        private readonly string nc01 = "PCBId";
        private readonly string nc02 = "MandateId";
        private readonly string nc03 = "ContactId";
        private readonly string nc04 = "EAddress";
        private readonly string nc05 = "EmailAddressTypeId";
        private readonly string nc06 = "Web";
        private readonly string nc07 = "AddOn";
        private readonly string nc08 = "Deleted";        
        private readonly string nc14 = "AssignmentFrom";
        private readonly string nc15 = "BlockedForSend";


        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
[{nc02}] [int] NULL,
[{nc03}] [int] NULL,
[{nc04}] [nvarchar](100) NULL,
[{nc05}] [int] NULL,
[{nc06}] [nvarchar](50) NULL,
[{nc07}] [nvarchar](50) NULL,
[{nc08}] [smallint] NOT NULL,
[{nc14}] [smalldatetime] NULL,
[{nc15}] [smallint] NOT NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc14}],[{nc15}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc14},@{nc15}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc15}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
