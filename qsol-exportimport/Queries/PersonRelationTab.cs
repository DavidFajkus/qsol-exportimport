using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class PersonRelationTab : SqlQueries
    {
        public PersonRelationTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT010";
        public override string NewTableName => "PersonRelation";
        protected override int ColCount => 11;
        protected override string ColShortcut => "IT";

        protected override int cCr => 7;
        protected override int cCrId => 8;
        protected override int cMd => 9;
        protected override int cMdId => 10;
        protected override int cNote => 11;

        private readonly string nc01 = "MandateRelation";
        private readonly string nc02 = "PCBId";
        private readonly string nc03 = "PCBIIId";
        private readonly string nc04 = "RelationId";
        private readonly string nc05 = "RelationIIId";
        private readonly string nc06 = "Type";
        
        public override string SqlCreate()
        {
            var sql = GetSqlCreate($@"[{nc01}] [smallint] NOT NULL,
	[{nc02}] [int] NULL,
	[{nc03}] [int] NULL,	
	[{nc04}] [int] NULL,
	[{nc05}] [int] NULL,
	[{nc06}] [smallint] NULL");

        var par1 = "1 - Family relation, 2 - Other relation";
            
        return $@"{sql} {GetExecForColumnDescription(nc06, par1)}";
    
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc05}],[{nc06}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc05},@{nc06}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.NVarChar, 5);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar, 7);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.NVarChar, 50);                
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
