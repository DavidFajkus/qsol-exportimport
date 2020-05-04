using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class MandateTab : SqlQueries
    {
        public MandateTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT018";
        public override string NewTableName => "Mandate";
        protected override int ColCount => 52;
        protected override string ColShortcut => "IT";

        protected override int cCr => 61;
        protected override int cCrId => 62;
        protected override int cMd => 63;
        protected override int cMdId => 64;
        protected override int cNote => 65;
        
        protected override string columns => @"ITF001,CASE WHEN ITF047=0 THEN ITF002 ELSE null END,ITF003,ITF004,ITF006,ITF010,ITF011,ITF012,ITF013,ITF038,ITF039,ITF040,ITF041,ITF042,ITF043,ITF045,
ITF046,ITF047,ITF048,ITF049,ITF050,CASE WHEN ITF006=0 THEN ITF051 ELSE null END,ITF066,ITF067,ITF068,ITF069,ITF070,ITF071,ITF072,ITF073,ITF074,ITF075,ITF076,ITF077,ITF078,ITF079,ITF080,ITF081,
ITF082,ITF083,ITF085,ITF086,ITF087,ITF088,ITF089,ITF090,ITF091,ITF092,ITF093,ITF094,ITF095,ITF096,ITF097,ITF098,CASE WHEN ITF047=1 THEN ITF002 ELSE null END,CASE WHEN ITF006=1 THEN ITF051 ELSE null END";
        
        private readonly string nc01 = "Name";
        private readonly string nc02 = "DomicileHolderId";
        private readonly string nc03 = "CorrespondentId";
        private readonly string nc04 = "AuditOrganId";
        private readonly string nc06 = "ManType";
        private readonly string nc10 = "Dispatch";
        private readonly string nc11 = "StatusId"; //CodeTab
        private readonly string nc12 = "Beginning";
        private readonly string nc13 = "HREntry";
        private readonly string nc38 = "Deleted";
        private readonly string nc39 = "DeletedDate";
        private readonly string nc40 = "DeletedText";
        private readonly string nc41 = "Liquidate";
        private readonly string nc42 = "LiquidateDate";
        private readonly string nc43 = "LiquidateText";
        private readonly string nc45 = "OrgUnitId";
        private readonly string nc46 = "Level";
        private readonly string nc47 = "DomicileType";
        private readonly string nc48 = "ResponsableId";
        private readonly string nc49 = "Responsable2Id";
        private readonly string nc50 = "Responsable3Id";
        private readonly string nc51 = "CompanyTypeId";//IT055
        private readonly string nc66 = "Blocked";
        private readonly string nc67 = "General";
        private readonly string nc68 = "Internal";
        private readonly string nc69 = "External";
        private readonly string nc70 = "Archive";
        private readonly string nc71 = "ArchiveDate";
        private readonly string nc72 = "ArchiveWhoId";
        private readonly string nc73 = "RiskGroupId";
        private readonly string nc74 = "SwellAmountUntil";
        private readonly string nc75 = "SwellCurrency";
        private readonly string nc76 = "AML";
        private readonly string nc77 = "CustomerAcceptanceId"; //PCBTab
        private readonly string nc78 = "BlockedDate";
        private readonly string nc79 = "BlockedWhoId";
        private readonly string nc80 = "ClientRelation";
        private readonly string nc81 = "EntrancesImportSince";
        private readonly string nc82 = "Transferring";
        private readonly string nc83 = "TransferringAtId";//PCBTab
        private readonly string nc85 = "RetroLock";
        private readonly string nc86 = "RetroLockDate";
        private readonly string nc87 = "RetroLockWhoId";
        private readonly string nc88 = "FatcaMandateId";
        private readonly string nc89 = "FatcaCompanyId";
        private readonly string nc90 = "FatcaSince";
        private readonly string nc91 = "FatcaDate";
        private readonly string nc92 = "FatcaWhoId";
        private readonly string nc93 = "FatcaIIText";
        private readonly string nc94 = "FatcaIISince";
        private readonly string nc95 = "FatcaIIDate";
        private readonly string nc96 = "FatcaIIWhoId";
        private readonly string nc97 = "FatcaDescr";
        private readonly string nc98 = "FatcaGOV";
        private readonly string nc991 = "DomicileId";//PFBTab
        private readonly string nc992 = "ServiceTypeId";//IT069


        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [nvarchar](50) NULL,
[{nc02}] [int] NULL,
[{nc03}] [int] NULL,	
[{nc04}] [int] NULL,
[{nc06}] [smallint] NOT NULL,
[{nc10}] [smallint] NOT NULL,
[{nc11}] [int] NULL,
[{nc12}] [smalldatetime] NULL,
[{nc13}] [smalldatetime] NULL,
[{nc38}] [smallint] NOT NULL,
[{nc39}] [smalldatetime] NULL,
[{nc40}] [nvarchar](50) NULL,
[{nc41}] [smallint] NOT NULL,
[{nc42}] [smalldatetime] NULL,
[{nc43}] [nvarchar] (110) NULL,
[{nc45}] [int] NULL,
[{nc46}] [smallint] NOT NULL,
[{nc47}] [smallint] NOT NULL,
[{nc48}] [int] NULL,
[{nc49}] [int] NULL,
[{nc50}] [int] NULL,
[{nc51}] [int] NULL,
[{nc66}] [smallint] NOT NULL,
[{nc67}] [smallint] NOT NULL,
[{nc68}] [smallint] NOT NULL,
[{nc69}] [smallint] NOT NULL,
[{nc70}] [smallint] NOT NULL,
[{nc71}] [smalldatetime] NULL,
[{nc72}] [int] NULL,
[{nc73}] [int] NULL,
[{nc74}] [float] NULL,
[{nc75}] [int] NULL,
[{nc76}] [smallint] NULL,
[{nc77}] [int] NULL,
[{nc78}] [smalldatetime] NULL,
[{nc79}] [int] NULL,
[{nc80}] [nvarchar] (50) NULL,
[{nc81}] [smalldatetime] NULL,
[{nc82}] [smalldatetime] NULL,
[{nc83}] [int] NULL,
[{nc85}] [smallint] NOT NULL,
[{nc86}] [smalldatetime] NULL,
[{nc87}] [int] NULL,
[{nc88}] [int] NULL,
[{nc89}] [int] NULL,
[{nc90}] [smalldatetime] NULL,
[{nc91}] [smalldatetime] NULL,
[{nc92}] [int] NULL,
[{nc93}] [nvarchar] (30) NULL,
[{nc94}] [smalldatetime] NULL,
[{nc95}] [smalldatetime] NULL,
[{nc96}] [int] NULL,
[{nc97}] [ntext] NULL,
[{nc98}] [nvarchar](30) NULL,
[{nc991}] [int] NULL,
[{nc992}] [int] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                 SqlCommand cmd = new SqlCommand(GetSqlInsert(
                     $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc06}],[{nc10}],[{nc11}],[{nc12}],[{nc13}],[{nc38}],[{nc39}],[{nc40}],
 [{nc41}],[{nc42}],[{nc43}],[{nc45}],[{nc46}],[{nc47}],[{nc48}],[{nc49}],[{nc50}],[{nc51}],[{nc66}],[{nc67}],[{nc68}],[{nc69}],
 [{nc70}],[{nc71}],[{nc72}],[{nc73}],[{nc74}],[{nc75}],[{nc76}],[{nc77}],[{nc78}],[{nc79}],[{nc80}],[{nc81}],[{nc82}],[{nc83}],
 [{nc85}],[{nc86}],[{nc87}],[{nc88}],[{nc89}],[{nc90}],[{nc91}],[{nc92}],[{nc93}],[{nc94}],[{nc95}],[{nc96}],[{nc97}],[{nc98}],[{nc991}],[{nc992}]",
                     $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc06},@{nc10},@{nc11},@{nc12},@{nc13},@{nc38},@{nc39},@{nc40},
 @{nc41},@{nc42},@{nc43},@{nc45},@{nc46},@{nc47},@{nc48},@{nc49},@{nc50},@{nc51},@{nc66},@{nc67},@{nc68},@{nc69},
 @{nc70},@{nc71},@{nc72},@{nc73},@{nc74},@{nc75},@{nc76},@{nc77},@{nc78},@{nc79},@{nc80},@{nc81},@{nc82},@{nc83},
 @{nc85},@{nc86},@{nc87},@{nc88},@{nc89},@{nc90},@{nc91},@{nc92},@{nc93},@{nc94},@{nc95},@{nc96},@{nc97},@{nc98},@{nc991},@{nc992}"), sqlCon);
                
                AddDefaultParameters(cmd);
                
                cmd.Parameters.Add($"@{nc01}", SqlDbType.NVarChar,50);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc12}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc38}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc39}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc40}", SqlDbType.NVarChar,50);
                cmd.Parameters.Add($"@{nc41}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc42}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc43}", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add($"@{nc45}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc46}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc47}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc48}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc49}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc50}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc51}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc66}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc67}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc68}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc69}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc70}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc71}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc72}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc73}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc74}", SqlDbType.Float);
                cmd.Parameters.Add($"@{nc75}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc76}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc77}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc78}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc79}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc80}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc81}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc82}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc83}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc85}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc86}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc87}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc88}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc89}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc90}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc91}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc92}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc93}", SqlDbType.NVarChar,30);
                cmd.Parameters.Add($"@{nc94}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc95}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc96}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc97}", SqlDbType.NText);
                cmd.Parameters.Add($"@{nc98}", SqlDbType.NVarChar,30);
                cmd.Parameters.Add($"@{nc991}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc992}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
