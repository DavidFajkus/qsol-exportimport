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
    class IdentificationDocumentTab : SqlQueries
    {
        public IdentificationDocumentTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT008";
        public override string NewTableName => "IdentificationDocument";
        protected override int ColCount => 22;
        protected override string ColShortcut => "IT";

        protected override int cCr => 13;
        protected override int cCrId => 14;
        protected override int cMd => 15;
        protected override int cMdId => 16;
        protected override int cNote => 17;
        protected override string columns => @"ITF001,ITF002,ITF003,ITF004,ITF005,ITF006,ITF007,ITF008,ITF009,ITF010,ITF011,ITF012,ITF018,ITF019,ITF020,ITF021,ITF022";

        private readonly string nc01 = "IdentificationTypeId";
        private readonly string nc02 = "Number";
        private readonly string nc03 = "PlaceOfIssueId";
        private readonly string nc04 = "Address";
        private readonly string nc05 = "Issuance";
        private readonly string nc06 = "Prolongation";
        private readonly string nc07 = "DateOfExpiry";
        private readonly string nc08 = "PCBId";
        private readonly string nc09 = "PlaceOfCitizenshipCH";
        private readonly string nc10 = "Birthday";
        private readonly string nc11 = "PlaceOfResidence";
        private readonly string nc12 = "PlaceOfBirth";        
        private readonly string nc18 = "Deleted";
        private readonly string nc19 = "IssuingCountryId";
        private readonly string nc20 = "Invalid";
        private readonly string nc21 = "Identification";
        private readonly string nc22 = "ActiveInDueDiligence";
        
        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
[{nc02}] [nvarchar](20) NULL,
[{nc03}] [int] NULL,
[{nc04}] [nvarchar](30) NULL,
[{nc05}] [datetime] NULL,
[{nc06}] [datetime] NULL,
[{nc07}] [datetime] NULL,
[{nc08}] [int] NULL,
[{nc09}] [nvarchar](30) NULL,
[{nc10}] [smalldatetime] NULL,
[{nc11}] [nvarchar](30) NULL,
[{nc12}] [nvarchar](30) NULL,
[{nc18}] [smallint] NOT NULL,
[{nc19}] [int] NULL,
[{nc20}] [smallint] NOT NULL,
[{nc21}] [smallint] NOT NULL,
[{nc22}] [smallint] NOT NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc09}],[{nc10}],[{nc11}],[{nc12}],[{nc18}],
[{nc19}],[{nc20}],[{nc21}],[{nc22}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc09},@{nc10},@{nc11},@{nc12},@{nc18},
@{nc19},@{nc20},@{nc21},@{nc22}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc18}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc22}", SqlDbType.SmallInt);                
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
