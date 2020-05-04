using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using qsol.exportimport.DTO;
using Microsoft.Deployment.Compression.Cab;
using System.IO;
using System.Threading.Tasks;

namespace qsol.exportimport.Queries
{
    public class DocumentTab : SqlQueries
    {
        public DocumentTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT052";
        public override string NewTableName => "Document";
        protected override int ColCount => 30;
        protected override string ColShortcut => "IT";

        protected override int cCr => 9;
        protected override int cCrId => 10;
        protected override int cMd => 11;
        protected override int cMdId => 12;
        protected override int cNote => 13;
        protected override string columns => @"ITF002,ITF003,ITF004,ITF005,ITF006,ITF007,ITF008,ITF014,ITF015,ITF016,ITF017,ITF018,ITF019,ITF020,ITF021,ITF024,ITF025,
ITF026,ITF027,ITF028,ITF029,ITF030,ITF031,ITF032,ITF033";

        private readonly string nc02 = "DocName";
        private readonly string nc03 = "StoredId";
        private readonly string nc04 = "DateIn";
        private readonly string nc05 = "InWhoId";
        private readonly string nc06 = "Out";
        private readonly string nc07 = "OutWhoId";
        private readonly string nc08 = "Reason";        
        private readonly string nc14 = "StorageLocation";
        private readonly string nc15 = "DocumentTypeId";
        private readonly string nc16 = "DocDateModified";
        private readonly string nc17 = "Document";
        private readonly string nc18 = "DocExtension";
        private readonly string nc19 = "Private";
        private readonly string nc20 = "LockModify";
        private readonly string nc21 = "LockDel";        
        private readonly string nc24 = "ObjectId";
        private readonly string nc25 = "RecId";
        private readonly string nc26 = "Invalid";
        private readonly string nc27 = "InvalidDate";
        private readonly string nc28 = "InvalidWho";
        private readonly string nc29 = "OrgDateModified";
        private readonly string nc30 = "Original";
        private readonly string nc31 = "OrgExtension";
        private readonly string nc32 = "DocumentSubtype";
        private readonly string nc33 = "DocRegisterId";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc02}] [nvarchar](75) NULL,	
	[{nc03}] [int] NULL,
    [{nc04}] [smalldatetime],
    [{nc05}] [int] NULL,
    [{nc06}] [smalldatetime] NULL,
    [{nc07}] [int] NULL,
    [{nc08}] [nvarchar](100) NULL,
    [{nc14}] [nvarchar](50) NULL,
    [{nc15}] [int] NULL,
	[{nc16}] [datetime] NULL,	
	[{nc17}] [varbinary](MAX) NULL,	
    [{nc18}] [nvarchar](5) NULL,	
    [{nc19}] [smallint] NOT NULL,
    [{nc20}] [smallint] NOT NULL,
    [{nc21}] [smallint] NOT NULL,    
    [{nc24}] [smallint] NULL,
    [{nc25}] [int] NULL,
    [{nc26}] [smallint] NOT NULL,
    [{nc27}] [smalldatetime] NULL,
    [{nc28}] [int] NULL,
    [{nc29}] [datetime] NULL,
    [{nc30}] [varbinary](MAX) NULL,
    [{nc31}] [nvarchar](5) NULL,
    [{nc32}] [int] NULL,
    [{nc33}] [int] NULL"
    );

        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}],[{nc07}],[{nc08}],[{nc14}],[{nc15}],[{nc16}],[{nc17}],[{nc18}],[{nc19}],[{nc20}],[{nc21}],[{nc24}],[{nc25}],
[{nc26}],[{nc27}],[{nc28}],[{nc29}],[{nc30}],[{nc31}],[{nc32}],[{nc33}]",
                    $@"@{nc02},@{nc03},@{nc04},@{nc05},@{nc06},@{nc07},@{nc08},@{nc14},@{nc15},@{nc16},@{nc17},@{nc18},@{nc19},@{nc20},@{nc21},@{nc24},@{nc25},
@{nc26},@{nc27},@{nc28},@{nc29},@{nc30},@{nc31},@{nc32},@{nc33}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar,75);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc07}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc08}", SqlDbType.NVarChar,100);
                cmd.Parameters.Add($"@{nc14}", SqlDbType.NVarChar,50) ;
                cmd.Parameters.Add($"@{nc15}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc16}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc17}", SqlDbType.VarBinary,-1);
                cmd.Parameters.Add($"@{nc18}", SqlDbType.NVarChar,5);
                cmd.Parameters.Add($"@{nc19}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc20}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc21}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc24}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc25}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc26}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc27}", SqlDbType.SmallDateTime);
                cmd.Parameters.Add($"@{nc28}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc29}", SqlDbType.DateTime);
                cmd.Parameters.Add($"@{nc30}", SqlDbType.VarBinary,-1);
                cmd.Parameters.Add($"@{nc31}", SqlDbType.NVarChar,5);
                cmd.Parameters.Add($"@{nc32}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc33}", SqlDbType.Int);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
        
        protected override object SetParameter(string ParameterName, object value)
        {
            if(DBNull.Value.Equals(value))
                return value;
            /*
            if (ParameterName == $"@{ nc17}" || ParameterName == $"@{ nc30}")
            {
                if(value is byte[] data)
                {
                    
                    var mscfExtractor = new Helpers.MSCFExtractor();
                    var list = mscfExtractor.UnpackFile(data);
                    if (list.Count == 0)
                        return value;
                    else
                        return list.First();
                }
            }*/

            return value;
        }
    }
}

