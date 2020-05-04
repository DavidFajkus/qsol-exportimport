using System.Data;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;

namespace qsol.exportimport.Queries
{
    public class OutboxAttachmentTab : SqlQueries
    {
        public OutboxAttachmentTab(CancellationToken token) : base(token)
        {
        }

        public override string TableName => "IT101";
        public override string NewTableName => "OutboxAttachment";
        protected override int ColCount => 6;
        protected override string ColShortcut => "IT";

        private readonly string nc01 = "OutboxId";
        private readonly string nc02 = "Attachment";
        private readonly string nc03 = "Name";
        private readonly string nc04 = "Sequence";
        private readonly string nc05 = "Type";
        private readonly string nc06 = "Size";

        public override string SqlCreate()
        {
            return GetSqlCreate($@"[{nc01}] [int] NULL,
[{nc02}] [image] NULL,
[{nc03}] [nvarchar](255) NULL,
[{nc04}] [smallint] NULL,
[{nc05}] [nvarchar](50) NULL,
[{nc06}] [float] NULL");
        }

        public override void Insert(SqlDataReader reader, SqlConnection sqlCon, InfoDto info, LogInfo logInfo)
        {
            if (reader == null)
                return;

            if (reader.HasRows)
            {
                SqlCommand cmd = new SqlCommand(GetSqlInsert(
                    $@"[{nc01}],[{nc02}],[{ nc03}],[{ nc04}],[{ nc05}],[{nc06}]", $@"@{ nc01},@{nc02},@{ nc03},@{nc04},@{nc05},@{nc06}"), sqlCon);

                AddDefaultParameters(cmd);

                cmd.Parameters.Add($"@{nc01}", SqlDbType.Int);
                cmd.Parameters.Add($"@{nc02}", SqlDbType.Image);
                cmd.Parameters.Add($"@{nc03}", SqlDbType.NVarChar, 255);
                cmd.Parameters.Add($"@{nc04}", SqlDbType.SmallInt);
                cmd.Parameters.Add($"@{nc05}", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add($"@{nc06}", SqlDbType.Float);
                cmd.Parameters.Add($"@{ncId}", SqlDbType.UniqueIdentifier);

                CopyRows(reader, cmd, info, logInfo);
            }
        }
    }
}


