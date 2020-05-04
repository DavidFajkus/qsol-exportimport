using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using qsol.exportimport.DTO;
using qsol.exportimport.Helpers;

namespace qsol.exportimport.Queries
{
    public class SqlQueries
    {
        private const int mod = 100;

        private readonly CancellationToken _token;

        public virtual string TableName => "";
        public string ColId => $"{ColShortcut}FK01";
        public virtual string NewTableName => "";
        protected virtual int ColCount => 0;
        protected virtual string ColShortcut => "";

        protected readonly string ncId = "Id";
        protected readonly string ncOldId = "OldId";
        protected readonly string ncCrd = "Created";
        protected readonly string ncCrdId = "CreatedId";
        protected readonly string ncMod = "Modified";
        protected readonly string ncModId = "ModifiedId";
        protected readonly string ncNote = "Note";

        protected virtual int cCr => 0;
        protected virtual int cCrId => 0;
        protected virtual int cMd => 0;
        protected virtual int cMdId => 0;
        protected virtual int cNote => 0;
        protected virtual string columns => "";

        protected SqlQueries(CancellationToken token)
        {
            _token = token;
        }

        protected string GetSqlCreate(string columns)
        {
            var cr = cCr>0?$@",[{ncCrd}] [smalldatetime] NULL":"";
            var crId = cCrId>0 ? $@",[{ncCrdId}] [int] NULL" : "";
            var md = cMd>0 ? $@",[{ncMod}] [smalldatetime] NULL":"";
            var mdId = cMdId>0 ? $@",[{ncModId}] [int] NULL" : "";
            var nt = cNote > 0? $@",[{ncNote}] [nvarchar](MAX) NULL":"";

            return $@"CREATE TABLE[dbo].[{NewTableName}]
            ([{ncId}] [uniqueidentifier] NOT NULL,
            [{ncOldId}][int] NOT NULL{cr}{crId}{md}{mdId}{nt},{columns});";
        }

        protected string GetSqlInsert(string columns, string parameters)
        {
            var cr = cCr>0?$@",[{ncCrd}]" : "";
            var crId = cCrId > 0 ? $@",[{ncCrdId}]" : "";
            var md = cMd>0 ? $@",[{ncMod}]" : "";
            var mdId = cMdId > 0 ? $@",[{ncModId}]" : "";
            var nt = cNote>0 ? $@",[{ncNote}]" : "";

            var crP = cCr>0? $@",@{ncCrd}" : "";
            var crIdP = cCrId > 0 ? $@",@{ncCrdId}" : "";
            var mdP = cMd>0 ? $@",@{ncMod}" : "";
            var mdIdP = cMdId>0 ? $@",@{ncModId}" : "";
            var ntP = cNote>0? $@",@{ncNote}" : "";

            return $@"INSERT INTO [{NewTableName}] ([{ncId}],[{ncOldId}]{cr}{crId}{md}{mdId}{nt},{columns}) VALUES (
@{ncId},@{ncOldId}{crP}{crIdP}{mdP}{mdIdP}{ntP},{parameters})";
        }

        protected void CopyRows(SqlDataReader reader, SqlCommand cmd, InfoDto info, LogInfo logInfo)
        {
            if (reader == null || cmd == null || info == null)
            {
                logInfo.Info = "Reader is null";
                return;
            }
            
            int count = 1;
            object key = null;

            while (reader.Read())
            {
                try
                {
                    /*
                    Object[] values = new Object[reader.FieldCount];
                    int fieldCount = reader.GetValues(values);
                    key = values[0];

                    for (int ix = 0; ix < fieldCount; ix++)
                        cmd.Parameters[ix].Value = values[ix];*/
                    
                    
                    for (int ix = 0; ix != cmd.Parameters.Count - 1; ix++)
                    {                        
                        WorkReader.SetParameter(cmd.Parameters, reader, ix);
                        
                        //cmd.Parameters[ix].Value =
                        //WorkReader.NullToDBNull(SetParameter(cmd.Parameters[ix].ParameterName, WorkReader.DBNullToNull(cmd.Parameters[ix].Value)));

                        if (ix == 0)
                            key = cmd.Parameters[ix].Value;
                    }

                    cmd.Parameters[$"@{ncId}"].Value = Guid.NewGuid();
                }
                catch(Exception ex)
                {
                    logInfo.Info = "copy rows - SetParameter";
                    info.Info = $"Id: {key} {ex.Message}";
                    return;
                }

                //Console.WriteLine(reader.GetValue(0));                  

                try
                {
                    cmd.ExecuteNonQuery();
                    if (count % mod == 0)
                        info.Imported = count;

                    if (count % 10 == 0)
                        logInfo.Info = $"Saved: {count}";

                    count++;

                    if (_token.IsCancellationRequested)
                    {
                        if(String.IsNullOrEmpty(info.Info))
                            info.Info = "Esc stop";
                        else 
                            info.Info = $"{info.Info} Esc stop";
                        //_token.ThrowIfCancellationRequested();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    logInfo.Info = "copy rows - ExecuteNonQuery";
                    info.Info = ex.Message;
                    break;
                }
                                
                // Thread.Sleep(250);
            }

            info.Imported = count-1;
        }

        virtual protected object SetParameter(string ParameterName, object value)
        {
            return value;
        }
        
        protected void AddDefaultParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add($"@{ncOldId}", SqlDbType.Int);
            if (cCr>0)
                cmd.Parameters.Add($"@{ncCrd}", SqlDbType.SmallDateTime);
            if (cCrId > 0)
                cmd.Parameters.Add($"@{ncCrdId}", SqlDbType.Int);
            if (cMd>0)
                cmd.Parameters.Add($"@{ncMod}", SqlDbType.SmallDateTime);
            if (cMdId > 0)
                cmd.Parameters.Add($"@{ncModId}", SqlDbType.Int);
            if(cNote>0)
                cmd.Parameters.Add($"@{ncNote}", SqlDbType.NText);            
        }

        public virtual string SqlCreate()
        {
            return GetSqlCreate("");
        }

        public string SqlSelect(int maxId)
        {
            string sql = $"SELECT {ColId}";

            if (cCr > 0)
                sql = AddColumn(sql, cCr);
            if (cCrId > 0)
                sql = AddColumn(sql, cCrId);
            if (cMd > 0)
                sql = AddColumn(sql, cMd);
            if (cMdId > 0)
                sql = AddColumn(sql, cMdId);
            if (cNote > 0)
                sql = AddColumn(sql, cNote);

            if (!String.IsNullOrEmpty(columns))
            {
                sql = $"{sql},{columns}";
            }
            else
            {
                for (int ix = 1; ix <= ColCount; ix++)
                {
                    if (ix == cCr || ix == cCrId || ix == cMd || ix == cMdId || ix == cNote)
                        continue;

                    sql = AddColumn(sql, ix);
                }
            }

            return $"{sql} FROM [{TableName}] Where {ColId} > {maxId} ";
        }
        
        public virtual void Insert(SqlDataReader reader, SqlConnection desSqlCon, InfoDto userInfo, LogInfo logInfo)
        {
        }

        private string AddColumn(string sql, int ix)
        {
            return $"{sql},{ColShortcut}F{ix.ToString().PadLeft(3, '0')}";
        }

        protected string GetExecForColumnDescription(string columnName, string description)
        {
            return $@"EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'{description}',
@level0type = N'SCHEMA',@level0name = N'dbo',@level1type = N'TABLE',
@level1name = N'{NewTableName}', @level2type = N'COLUMN',@level2name = N'{columnName}';";
        }
    }
}
