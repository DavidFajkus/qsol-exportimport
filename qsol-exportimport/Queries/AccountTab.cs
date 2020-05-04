using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    class AccountTab : SqlQueries
    {
        public AccountTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT003";
        public override string NewTableName => "Account";
        protected override int ColCount => 26;
        protected override string ColShortcut => "IT";

        protected override int cCr => 11;
        protected override int cCrId => 12;
        protected override int cMd => 13;
        protected override int cMdId => 14;
        protected override int cNote => 15;
        protected override string columns => @"ITF001,ITF002,ITF003,ITF005,ITF006,ITF007,ITF008,ITF009,ITF010,ITF016,ITF017,ITF018,ITF019,ITF020,ITF021,ITF026,
ITF027,ITF028,ITF029,ITF030,ITF034";

        private readonly string nc01 = "BankId";
        private readonly string nc02 = "Account";
        private readonly string nc03 = "CurrrencyId";
        private readonly string nc05 = "AccountTypeId";
        private readonly string nc06 = "PCBId";
        private readonly string nc07 = "MandateId";
        private readonly string nc08 = "Blocked";
        private readonly string nc09 = "BlockedDate";
        private readonly string nc10 = "BlockedWhoId";
        private readonly string nc16 = "FIBU";
        private readonly string nc17 = "BIC";
        private readonly string nc18 = "EBanking";
        private readonly string nc19 = "EBankingDate";
        private readonly string nc20 = "EBankingWhoId";
        private readonly string nc21 = "IBAN";
        private readonly string nc26 = "EBankingBlocked";
        private readonly string nc27 = "EBankingBlockedDate";
        private readonly string nc28 = "EBankingBlockedWhoId";
        private readonly string nc29 = "ValidFrom";
        private readonly string nc30 = "PredecessorAccountId";
        private readonly string nc34 = "ValidTo";
        

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NOT NULL,
[{nc02}] [nvarchar](50) NULL,
[{nc03}] [int] NULL,
[{nc05}] [int] NULL,
[{nc06}] [int] NOT NULL,
[{nc07}] [int] NOT NULL,
[{nc08}] [smallint] NOT NULL,
[{nc09}] [smalldatetime] NULL,
[{nc10}] [int] NULL,
[{nc16}] [nvarchar](11) NULL,
[{nc17}] [nvarchar](25) NULL,
[{nc18}] [smallint] NOT NULL,
[{nc19}] [smalldatetime] NULL,
[{nc20}] [int] NULL,
[{nc21}] [nvarchar](35) NULL,
[{nc26}] [smallint] NOT NULL,
[{nc27}] [smalldatetime] NULL,
[{nc28}] [int] NULL,
[{nc29}] [smalldatetime] NULL,
[{nc30}] [int] NULL,
[{nc34}] [smalldatetime] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc10}],[{nc16}],[{nc17}],[{nc18}],[{nc19}],[{nc20}],
[{nc21}],[{nc26}],[{nc27}],[{nc28}],[{nc29}],[{nc30}],[{nc34}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc05},@{nc06},@{nc07},@{nc08},@{nc09},@{nc10},@{nc16},@{nc17},@{nc18},@{nc19},@{nc20},
@{nc21},@{nc26},@{nc27},@{nc28},@{nc29},@{nc30},@{nc34}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar,50);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.NVarChar,11);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.NVarChar, 25);
                cmd.Parameters.Add($"@{nc18}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.NVarChar, 35);
                cmd.Parameters.Add($"@{nc26}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc27}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc28}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc29}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc30}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc34}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
