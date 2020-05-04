using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class CashflowTab : SqlQueries
    {
        public CashflowTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT001";
        public override string NewTableName => "Cashflow";
        protected override int ColCount => 53;
        protected override string ColShortcut => "IT";        

        protected override int cCr => 9;
        protected override int cCrId => 10;
        protected override int cMd => 11;
        protected override int cMdId => 12;
        protected override int cNote => 13;

        private readonly string nc01 = "AccountId";
        private readonly string nc02 = "SenderRecipientId";
        private readonly string nc03 = "OrderAddOnNote";
        private readonly string nc04 = "Worth";
        private readonly string nc05 = "AmountIn";
        private readonly string nc06 = "AmountOut";
        private readonly string nc07 = "BankOrderNumber";
        private readonly string nc08 = "OrderDate";        
        private readonly string nc14 = "CheckerId";
        private readonly string nc15 = "CheckedDate";
        private readonly string nc16 = "Approval";
        private readonly string nc17 = "SiblingId";
        private readonly string nc18 = "SenderRecipientBankId";
        private readonly string nc19 = "CorrespondentBankId";
        private readonly string nc20 = "Reference";
        private readonly string nc21 = "CurrrencyId";
        private readonly string nc22 = "MandateId";
        private readonly string nc23 = "PCBId";
        private readonly string nc24 = "AccountSenderRecipient";
        private readonly string nc25 = "AccountCorrespondent";
        private readonly string nc26 = "BankWorth";
        private readonly string nc27 = "Amount";
        private readonly string nc28 = "IsNote";
        private readonly string nc29 = "UT";
        private readonly string nc30 = "Checked";
        private readonly string nc31 = "Deleted";
        private readonly string nc32 = "SecondCheckerId";
        private readonly string nc33 = "SecondCheckedDate";
        private readonly string nc34 = "Fibu";
        private readonly string nc35 = "RiskGroupId";
        private readonly string nc36 = "DocumentEditied";
        private readonly string nc37 = "Document";
        private readonly string nc38 = "DocumentExtension";
        private readonly string nc39 = "Signed";
        private readonly string nc40 = "Transfer";
        private readonly string nc41 = "IBANSenderRecipient";
        private readonly string nc42 = "IBANCorrespondent";
        private readonly string nc43 = "AutoCreated";
        private readonly string nc44 = "ContraAccount";
        private readonly string nc45 = "BookingText";
        private readonly string nc46 = "BookingTextII";
        private readonly string nc47 = "Forwarding";
        private readonly string nc48 = "SenderRecipientPCBId";
        private readonly string nc49 = "SenderRecipientBankPCBId";
        private readonly string nc50 = "CorrespondentBankPCBId";
        private readonly string nc51 = "DocumentLanguageId";
        private readonly string nc52 = "SenderRecipientAddressId";
        private readonly string nc53 = "CorrespondentAddressId";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NOT NULL,
[{nc02}] [int] NOT NULL,
[{nc03}] [nvarchar](MAX) NULL,
[{nc04}] [smalldatetime] NULL,
[{nc05}] [float] NOT NULL,
[{nc06}] [float] NOT NULL,
[{nc07}] [nvarchar](50) NULL,
[{nc08}] [smalldatetime] NULL,
[{nc14}] [int] NOT NULL,
[{nc15}] [smalldatetime] NULL,
[{nc16}] [smallint] NOT NULL,
[{nc17}] [int] NOT NULL,
[{nc18}] [int] NOT NULL,
[{nc19}] [int] NOT NULL,
[{nc20}] [nvarchar](100) NULL,
[{nc21}] [int] NOT NULL,
[{nc22}] [int] NOT NULL,
[{nc23}] [int] NOT NULL,
[{nc24}] [nvarchar](30) NULL,
[{nc25}] [nvarchar](30) NULL,
[{nc26}] [smalldatetime] NULL,
[{nc27}] [float] NULL,
[{nc28}] [smallint] NOT NULL,
[{nc29}] [smallint] NOT NULL,
[{nc30}] [smallint] NOT NULL,
[{nc31}] [smallint] NOT NULL,
[{nc32}] [int] NOT NULL,
[{nc33}] [smalldatetime] NULL,
[{nc34}] [nvarchar](MAX) NULL,
[{nc35}] [int] NULL,
[{nc36}] [datetime] NULL,
[{nc37}] [image] NULL,
[{nc38}] [nvarchar](5) NULL,
[{nc39}] [smallint] NOT NULL,
[{nc40}] [smallint] NOT NULL,
[{nc41}] [nvarchar](35) NULL,
[{nc42}] [nvarchar](35) NULL,
[{nc43}] [smallint] NOT NULL,
[{nc44}] [nvarchar](15) NULL,
[{nc45}] [nvarchar](100) NULL,
[{nc46}] [nvarchar](100) NULL,
[{nc47}] [smallint] NOT NULL,
[{nc48}] [int] NULL,
[{nc49}] [int] NULL,
[{nc50}] [int] NULL,
[{nc51}] [int] NULL,
[{nc52}] [int] NULL,
[{nc53}] [int] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc14}],[{nc15}],[{nc16}],[{nc17}],[{nc18}],[{nc19}],[{nc20}],
[{nc21}],[{nc22}],[{nc23}],[{nc24}],[{nc25}],[{nc26}],[{nc27}],[{nc28}],[{nc29}],[{nc30}],
[{nc31}],[{nc32}],[{nc33}],[{nc34}],[{nc35}],[{nc36}],[{nc37}],[{nc38}],[{nc39}],[{nc40}],
[{nc41}],[{nc42}],[{nc43}],[{nc44}],[{nc45}],[{nc46}],[{nc47}],[{nc48}],[{nc49}],[{nc50}],[{nc51}],[{nc52}],[{nc53}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc14},@{nc15},@{nc16},@{nc17},@{nc18},@{nc19},@{nc20},
@{nc21},@{nc22},@{nc23},@{nc24},@{nc25},@{nc26},@{nc27},@{nc28},@{nc29},@{nc30},
@{nc31},@{nc32},@{nc33},@{nc34},@{nc35},@{nc36},@{nc37},@{nc38},@{nc39},@{nc40},
@{nc41},@{nc42},@{nc43},@{nc44},@{nc45},@{nc46},@{nc47},@{nc48},@{nc49},@{nc50},@{nc51},@{nc52},@{nc53}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar, -1);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.Float);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.Float);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.NVarChar,50);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.SmallDateTime); 
                cmd.Parameters.Add($"@{nc14}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc15}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc18}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc22}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc23}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc24}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc25}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc26}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc27}", SqlDbType.Float);
                cmd.Parameters.Add($"@{nc28}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc29}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc30}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc31}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc32}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc33}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc34}", SqlDbType.NVarChar, -1 );
                cmd.Parameters.Add($"@{nc35}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc36}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc37}", SqlDbType.Image);
                cmd.Parameters.Add($"@{nc38}", SqlDbType.NVarChar, 5);
                cmd.Parameters.Add($"@{nc39}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc40}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc41}", SqlDbType.NVarChar, 35);
                cmd.Parameters.Add($"@{nc42}", SqlDbType.NVarChar, 35);
                cmd.Parameters.Add($"@{nc43}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc44}", SqlDbType.NVarChar, 15);
                cmd.Parameters.Add($"@{nc45}", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add($"@{nc46}", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add($"@{nc47}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc48}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc49}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc50}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc51}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc52}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc53}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
