using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class PlaceTab : SqlQueries
    {
        public PlaceTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT022";
        public override string NewTableName => "Place";
        protected override int ColCount => 11;
        protected override string ColShortcut => "IT";

        protected override int cCr => 5;
        protected override int cCrId => 6;
        protected override int cMd => 7;
        protected override int cMdId => 8;
        protected override int cNote => 9;

        private readonly string nc01 = "PostalCode";
        private readonly string nc02 = "Place";
        private readonly string nc03 = "CountryId";
        private readonly string nc04 = "PhonePrefix";
        private readonly string nc10 = "FederalStates";
        private readonly string nc11 = "Blocked";
        
        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [nvarchar](11) NULL,
	[{nc02}] [nvarchar](50) NULL,
	[{nc03}] [int] NULL,
	[{nc04}] [nvarchar](7) NULL,
	[{nc10}] [nvarchar](6) NULL,
	[{nc11}] [smallint] NOT NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{nc03}],[{nc04}],[{nc10}],[{nc11}]",
                    $@"@{nc01},@{nc02},@{nc03},@{nc04},@{nc10},@{nc11}"
                    ), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.NVarChar, 11);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.NVarChar,7);
                cmd.Parameters.Add($"@{nc10}", SqlDbType.NVarChar, 6);
                cmd.Parameters.Add($"@{nc11}", SqlDbType.SmallInt);                
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}
