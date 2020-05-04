using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class PCBTab : SqlQueries
    {
        public PCBTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT006";
        public override string NewTableName => "PCB";
        protected override int ColCount => 52;
        protected override string ColShortcut => "IT";

        protected override int cCr => 43;
        protected override int cCrId => 44;
        protected override int cMd => 45;
        protected override int cMdId => 46;
        protected override int cNote => 47;
        protected override string columns => @"ITF001,ITF002,ITF003,ITF004,ITF005,ITF007,ITF008,ITF009,ITF010,ITF011,ITF013,ITF015,ITF016,ITF019,ITF020,ITF021,
ITF024,ITF025,ITF026,ITF027,ITF038,ITF039,ITF040,ITF041,ITF042,ITF048,ITF049,ITF050,ITF051,ITF053,ITF054,ITF055,ITF056,ITF057,ITF058,ITF059,ITF060,ITF061,
ITF062,ITF063,ITF064,ITF065,ITF066,ITF067,ITF068,ITF069,ITF070";

        private readonly string nc01 = "IsPerson";
        private readonly string nc02 = "Name";
        private readonly string nc03 = "FirstName";
        private readonly string nc04 = "AddName";
        private readonly string nc05 = "TitleId";
        private readonly string nc07 = "LetterTitle";
        private readonly string nc08 = "Birthdate";
        private readonly string nc09 = "BirthPlace";
        private readonly string nc10 = "BirthCountry";
        private readonly string nc11 = "CRExtract";
        private readonly string nc13 = "IsBank";
        private readonly string nc15 = "FieldId";
        private readonly string nc16 = "CivilStatusId";
        private readonly string nc19 = "LanguageId";
        private readonly string nc20 = "Profession";
        private readonly string nc21 = "Employed";
        private readonly string nc24 = "Independent"; //0 Angestellt,1 Selbständig,2 Sonstig
        private readonly string nc25 = "PEP";
        private readonly string nc26 = "PEPDescr";
        private readonly string nc27 = "Inactive";
        private readonly string nc38 = "MaritalPropertyRegimeId";
        private readonly string nc39 = "ResponsableId";
        private readonly string nc40 = "Responsable2Id";
        private readonly string nc41 = "Responsable3Id";
        private readonly string nc42 = "InternalCompany";
        private readonly string nc48 = "BankHeadquarters";
        private readonly string nc49 = "Swift";
        private readonly string nc50 = "BaseAccountNrLength";
        private readonly string nc51 = "PEPClose";
        private readonly string nc53 = "BIC";
        private readonly string nc54 = "BankCode";
        private readonly string nc55 = "CaseCodesId";
        private readonly string nc56 = "DeathDate";
        private readonly string nc57 = "HeadOffice";
        private readonly string nc58 = "RetroLock";
        private readonly string nc59 = "FatcaManId";
        private readonly string nc60 = "FatcaPFBId";
        private readonly string nc61 = "FatcaSince";
        private readonly string nc62 = "FatcaDate";
        private readonly string nc63 = "FatcaWhoId";
        private readonly string nc64 = "FatcaIIText";
        private readonly string nc65 = "FatcaIISince";
        private readonly string nc66 = "FatcaIIDate";
        private readonly string nc67 = "FatcaIIWhoId";
        private readonly string nc68 = "FatcaDescr";
        private readonly string nc69 = "FatcaGOV";
        private readonly string nc70 = "OrgUnitId";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [smallint] NOT NULL,
	[{nc02}] [nvarchar](50) NULL,
	[{nc03}] [nvarchar](50) NULL,	
	[{nc04}] [nvarchar] (50) NULL,
    [{nc05}] [int] NULL,
    [{nc07}] [nvarchar] (30) NULL,
    [{nc08}] [smalldatetime] NULL,
    [{nc09}] [nvarchar] (35) NULL,
	[{nc10}] [int] NULL,
	[{nc11}] [nvarchar](50) NULL,
    [{nc13}] [smallint] NOT NULL,
    [{nc15}] [int] NULL,
    [{nc16}] [int] NULL,
    [{nc19}] [int] NULL,
    [{nc20}] [nvarchar] (50) NULL,
    [{nc21}] [nvarchar] (50) NULL,
    [{nc24}] [smallint] NOT NULL,
    [{nc25}] [smallint] NOT NULL,
    [{nc26}] [ntext] NULL,
    [{nc27}] [smallint] NOT NULL,
    [{nc38}] [int] NULL,
    [{nc39}] [int] NULL,
    [{nc40}] [int] NULL,
    [{nc41}] [int] NULL,
    [{nc42}] [smallint] NOT NULL,
    [{nc48}] [int] NULL,
    [{nc49}] [nvarchar] (15) NULL,
    [{nc50}] [int] NULL,
    [{nc51}] [smallint] NOT NULL,
    [{nc53}] [nvarchar] (12) NULL,
    [{nc54}] [nvarchar] (9) NULL,
    [{nc55}] [int] NULL,
    [{nc56}] [smalldatetime] NULL,
    [{nc57}] [smallint] NOT NULL,
    [{nc58}] [smallint] NOT NULL,
    [{nc59}] [int] NULL,
    [{nc60}] [int] NULL,
    [{nc61}] [smalldatetime] NULL,
    [{nc62}] [smalldatetime] NULL,
    [{nc63}] [int] NULL,
    [{nc64}] [nvarchar] (30) NULL,
    [{nc65}] [smalldatetime] NULL,
    [{nc66}] [smalldatetime] NULL,
    [{nc67}] [int] NULL,
    [{nc68}] [ntext] NULL,
    [{nc69}] [nvarchar] (30) NULL,
    [{nc70}] [int] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc07}],[{nc08}],[{nc09}],[{nc10}],[{nc11}],[{nc13}],[{nc15}],
[{nc16}],[{nc19}],[{nc20}],[{nc21}],[{nc24}],[{nc25}],[{nc26}],[{nc27}],[{nc38}],[{nc39}],[{nc40}],[{nc41}],[{nc42}],[{nc48}],
[{nc49}],[{nc50}],[{nc51}],[{nc53}],[{nc54}],[{nc55}],[{nc56}],[{nc57}],[{nc58}],[{nc59}],[{nc60}],[{nc61}],[{nc62}],[{nc63}],
[{nc64}],[{nc65}],[{nc66}],[{nc67}],[{nc68}],[{nc69}],[{nc70}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc07},@{nc08},@{nc09},@{nc10},@{nc11},@{nc13},@{nc15},
@{nc16},@{nc19},@{nc20},@{nc21},@{nc24},@{nc25},@{nc26},@{nc27},@{nc38},@{nc39},@{nc40},@{nc41},@{nc42},@{nc48},
@{nc49},@{nc50},@{nc51},@{nc53},@{nc54},@{nc55},@{nc56},@{nc57},@{nc58},@{nc59},@{nc60},@{nc61},@{nc62},@{nc63},
@{nc64},@{nc65},@{nc66},@{nc67},@{nc68},@{nc69},@{nc70}"

                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar,50);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar,50);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.NVarChar,50);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.NVarChar,30);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc09}", SqlDbType.NVarChar,35);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc13}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc15}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.NVarChar,50);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc24}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc25}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc26}", SqlDbType.NText);
                cmd.Parameters.Add($"@{nc27}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc38}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc39}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc40}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc41}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc42}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc48}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc49}", SqlDbType.NVarChar,15);
                cmd.Parameters.Add($"@{nc50}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc51}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc53}", SqlDbType.NVarChar, 12);
                cmd.Parameters.Add($"@{nc54}", SqlDbType.NVarChar, 9);
                cmd.Parameters.Add($"@{nc55}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc56}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc57}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc58}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc59}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc60}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc61}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc62}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc63}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc64}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc65}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc66}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc67}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc68}", SqlDbType.NText);
                cmd.Parameters.Add($"@{nc69}", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add($"@{nc70}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
