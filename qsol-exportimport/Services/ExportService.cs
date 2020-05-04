using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Threading;
using qsol.exportimport.DTO;
using qsol.exportimport.Helpers;
using qsol.exportimport.Queries;

namespace qsol.exportimport.Services
{
    class ExportService
    {
        private readonly string _sourceConnectionString;
        private readonly string _destinationConnectionString;
        private readonly ObservableCollection<InfoDto> _infoList;
        private readonly CancellationToken _token;
        private readonly string tableName;
        private SqlConnection SrcSqlCon;
        private SqlConnection DesSqlCon;
        private LogInfo logInfo;
        
        public ExportService(string sourceConnectionString, string destinationConnectionString, ObservableCollection<InfoDto> infoList, CancellationToken token, string tableName, LogInfo logInfo)
        {
            _sourceConnectionString = sourceConnectionString;
            _destinationConnectionString = destinationConnectionString;
            _infoList = infoList;
            _token = token;
            this.tableName = tableName;
            if (_infoList == null)
                _infoList = new AsyncObservableCollection<InfoDto>();
            this.logInfo = logInfo;
        }

        public void Run()
        {
            using (SrcSqlCon = new SqlConnection(_sourceConnectionString))
            {
                using (DesSqlCon = new SqlConnection(_destinationConnectionString))
                {
                    SrcSqlCon.Open();
                    DesSqlCon.Open();                    
                    //SC005
                    CopyTable(new UserTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT017
                        CopyTable(new CountryTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT048
                        CopyTable(new NationalityTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT012
                        CopyTable(new CodeTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT006
                        CopyTable(new PCBTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT015
                        CopyTable(new CustomerTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT018
                        CopyTable(new MandateTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT339
                        CopyTable(new RoleTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT340
                        CopyTable(new RolePeriodTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT375
                        CopyTable(new PotentialCustomerTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT376
                        CopyTable(new PotentialCustomerRoleTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT173
                        CopyTable(new FileNoteMandateTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT174
                        CopyTable(new FileNotePCBTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT061
                        CopyTable(new FileNoteRelationTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT062
                        CopyTable(new FileNoteTypeTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT063
                        CopyTable(new FileNoteTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT037
                        CopyTable(new AttendeeTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT077
                        CopyTable(new AppointmentTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT036
                        CopyTable(new AppointmentSeriesTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT129
                        CopyTable(new AppointmentMandateTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT130
                        CopyTable(new AppointmentPCBTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT035
                        CopyTable(new AppointmentTypeTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT072
                        CopyTable(new TaskTypeTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT080
                        CopyTable(new TaskSubtypeTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT160
                        CopyTable(new TaskMandateTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT161
                        CopyTable(new TaskPCBTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT074
                        CopyTable(new TaskUserTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT073
                        CopyTable(new TaskTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT052
                        CopyTable(new DocumentTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT051
                        CopyTable(new StoredTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT068
                        CopyTable(new DocumentTypeTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT315
                        CopyTable(new DocumentSubtypeTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT145
                        CopyTable(new DocumentMandateTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT146
                        CopyTable(new DocumentPCBTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT097
                        CopyTable(new InboxTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT125
                        CopyTable(new InboxMandateTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT126
                        CopyTable(new InboxPCBTab(_token));                        
                    if (!_token.IsCancellationRequested)
                        //IT099
                        CopyTable(new InboxAttachmentTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT098
                        CopyTable(new OutboxTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT127
                        CopyTable(new OutboxMandateTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT128
                        CopyTable(new OutboxPCBTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT101
                        CopyTable(new OutboxAttachmentTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT003
                        CopyTable(new AccountTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT009
                        CopyTable(new BankRelationTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT005
                        CopyTable(new CurrencyTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT002
                        CopyTable(new CashflowTextsTab(_token)); 
                    if (!_token.IsCancellationRequested)
                        //IT001
                        CopyTable(new CashflowTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT008
                        CopyTable(new IdentificationDocumentTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT007
                        CopyTable(new AddressTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT028
                        CopyTable(new TelephoneTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT022
                        CopyTable(new PlaceTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT082
                        CopyTable(new AlertTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT039
                        CopyTable(new TelephoneActivityTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT038
                        CopyTable(new TelephoneActivityTypeTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT157
                        CopyTable(new TelephoneActivityMandateTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT158
                        CopyTable(new TelephoneActivityPCBTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT023
                        CopyTable(new AuditOrganTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT013
                        CopyTable(new DomicileHolderTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT014
                        CopyTable(new CorrespondentTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT093
                        CopyTable(new CashflowForwardTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT186
                        CopyTable(new CashflowForwardDocumentTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT060
                        CopyTable(new ServicesTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT053
                        CopyTable(new ObjectTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT016
                        CopyTable(new CustomerMandateRelationTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT322
                        CopyTable(new ObjectMandateTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT323
                        CopyTable(new ObjectPCBTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT378
                        CopyTable(new DocumentFolderTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT379
                        CopyTable(new DocumentFolderRelationTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT034
                        CopyTable(new PowerOfAttornyTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT043
                        CopyTable(new MandateRecordingTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT047
                        CopyTable(new MandateBusinessCaseTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT046
                        CopyTable(new CustomerBusinessCaseTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT065
                        CopyTable(new AuditOrganPeriodTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT032
                        CopyTable(new OrganTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT010
                        CopyTable(new PersonRelationTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT336
                        CopyTable(new DomicileHolderPeriodTab(_token));
                    if (!_token.IsCancellationRequested) 
                         //IT372
                         CopyTable(new ActivityTypeTab(_token));
                    if (!_token.IsCancellationRequested) 
                         //IT373
                         CopyTable(new PCBActivityRelationTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT056
                        CopyTable(new MandatePurposeTab(_token));
                    if (!_token.IsCancellationRequested)
                        //IT057
                        CopyTable(new MandatePurposeRelationTab(_token));

                    if (!_token.IsCancellationRequested)
                        //IT106
                        CopyTable(new EmailAddressTab(_token));
                }
            }
        }
        
        private void CopyTable(SqlQueries sqlQueries)
        {
            if (!string.IsNullOrEmpty(tableName) && sqlQueries.TableName != tableName)
                return;

            logInfo.Info = $"Table: {sqlQueries.TableName}";

            //Check User table
            //var userInfo = WorkReader.CreateInfo($"{sqlQueries.TableName} -> {sqlQueries.NewTableName}" ,0,0);
            var userInfo = WorkReader.CreateInfo(sqlQueries.NewTableName, 0, 0);
            _infoList.Add(userInfo);

            logInfo.Info = $"New table {userInfo.TableName}";

            var maxId = CheckAndCreateTable(sqlQueries.NewTableName, sqlQueries.SqlCreate(), userInfo);
            if (maxId < 0)
                return;

            logInfo.Info = $"Create new table {sqlQueries.NewTableName}";

            var reader = ReadRecords(sqlQueries, maxId, sqlQueries.SqlSelect(maxId), userInfo);
            if (reader == null)
                return;

            logInfo.Info = $"Table {sqlQueries.TableName}. Row count: {userInfo.Count}";

            sqlQueries.Insert(reader, DesSqlCon, userInfo, logInfo);
        }

        private int CheckAndCreateTable(string tableName, string sqlCreate, InfoDto info)
        {
            int maxId=0;
            
            SqlCommand cmd =
                new SqlCommand($@"SELECT Count(*) FROM [sysobjects] WHERE xtype = 'U' AND name = '{tableName}'",
                    DesSqlCon);
            try
            {
                var tabCount = (Int32) cmd.ExecuteScalar();
                if (tabCount == 0)
                {
                    cmd.CommandText = sqlCreate;

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd.CommandText = $@"SELECT MAX(OldId) FROM [{tableName}]";
                    var result = cmd.ExecuteScalar().ToString();
                    if (string.IsNullOrEmpty(result))
                        maxId = 0;
                    else
                        Int32.TryParse(result, out maxId);

                    if (maxId > 0)
                        info.Info = $"Last Id: {maxId}";
                }

            }
            catch (Exception ex)
            {
                info.Info = ex.Message;
                return -1;
            }
            
            return maxId;
        }

        private SqlDataReader ReadRecords(SqlQueries queries, int maxId, string sqlSelect, InfoDto info)
        {
            SqlCommand cmd = new SqlCommand($@"SELECT Count(*) FROM [{queries.TableName}] WHERE {queries.ColId} > {maxId}", SrcSqlCon);
            try
            {
                info.Count = (Int32)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                info.Info = ex.Message;
                return null;
            }

            
          cmd.CommandText = sqlSelect;
            try
            {
                cmd.CommandTimeout = 300;
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                info.Info = ex.Message;
                return null;
            }
        }
    }
 }
