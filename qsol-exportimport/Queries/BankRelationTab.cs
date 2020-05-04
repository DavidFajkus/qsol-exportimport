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
    class BankRelationTab : SqlQueries
    {
        public BankRelationTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT009";
        public override string NewTableName => "BankRelation";
        protected override int ColCount => 19;
        protected override string ColShortcut => "IT";

        protected override int cCr => 16;
        protected override int cCrId => 17;
        protected override int cMd => 18;
        protected override int cMdId => 19;
        protected override int cNote => 20;

        protected override string columns => @"ITF001,ITF002,ITF003,ITF004,ITF005,ITF006,ITF007,ITF008,ITF015,ITF021,ITF022,ITF023,ITF024,ITF025";

        private readonly string nc01 = "MandateId";
        private readonly string nc02 = "PCBId";
        private readonly string nc03 = "BankId";
        private readonly string nc04 = "Responsable";
        private readonly string nc05 = "Deputy";
        private readonly string nc06 = "ResponsablePhone";
        private readonly string nc07 = "DeputyPhone";        
        private readonly string nc08 = "Fax";
        private readonly string nc15 = "BaseNumber";        
        private readonly string nc21 = "ClientNumber";
        private readonly string nc22 = "AddressId";        
        private readonly string nc23 = "ResponsablePhoneId";
        private readonly string nc24 = "DeputyPhoneId";
        private readonly string nc25 = "FaxId";
        

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NOT NULL,
[{nc02}] [int] NULL,
[{nc03}] [int] NULL,
[{nc04}] [nvarchar](30) NULL,
[{nc05}] [nvarchar](30) NULL,
[{nc06}] [nvarchar](20) NULL,
[{nc07}] [nvarchar](20) NULL,
[{nc08}] [nvarchar](20) NULL,
[{nc15}] [nvarchar](30) NULL,
[{nc21}] [nvarchar](7) NULL,
[{nc22}] [int] NULL,
[{nc23}] [int] NULL,
[{nc24}] [int] NULL,
[{nc25}] [int] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc15}],[{nc21}],[{nc22}],[{nc23}],[{nc24}],[{nc25}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc15},@{nc21},@{nc22},@{nc23},@{nc24},@{nc25}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.NVarChar,30);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.NVarChar,30);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.NVarChar,20);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.NVarChar,20);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.NVarChar,20);
                cmd.Parameters.Add($"@{nc15}", SqlDbType.NVarChar,30);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.NVarChar, 7);
                cmd.Parameters.Add($"@{nc22}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc23}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc24}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc25}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
