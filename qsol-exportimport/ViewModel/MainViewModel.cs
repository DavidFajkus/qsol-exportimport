using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using qsol.exportimport.DTO;
using qsol.exportimport.Helpers;
using qsol.exportimport.Properties;
using qsol.exportimport.Services;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace qsol.exportimport.ViewModel
{
    public class MainViewModel : ViewModelBase, Interface.IMainViewModel
    {
        public MainViewModel()
        {
            SourceServer = Settings.Default.SourceServer;
            SourceDatabase = Settings.Default.SourceDatabase;
            SourceUserName = Settings.Default.SourceUserName;
            DestinationServer = Settings.Default.DestinationServer;
            DestinationDatabase = Settings.Default.DestinationDatabase;
            DestinationUserName = Settings.Default.DestinationUserName;
            TableName = Settings.Default.TableName;
            ReplayCommand();

            ListOfExported = new AsyncObservableCollection<InfoDto>();
            LogInfo = new LogInfo();
        }

        public string TableName { get; set; }

        private ObservableCollection<InfoDto> _listOfExported = new ObservableCollection<InfoDto>();
        public ObservableCollection<InfoDto> ListOfExported
        {
            get { return _listOfExported;}
            set
            {
                _listOfExported = value;
            }
        }

        private CancellationTokenSource _tokenSource;
        private Task _task;
        
        public event EventHandler<PasswordEventArgs> SourcePasswordEvent;
        public event EventHandler<PasswordEventArgs> DestinationPasswordEvent;

        public ICommand EscapeRunningCommand { get; set; }
        void OnEscapeRunning()
        {
            _tokenSource.Cancel();
        }

        public ICommand SourceConnectionCommand { get; set; }
        void OnSourceConnection()
        {
            var cs = CheckSqlServerConnection("Source", _sourceServer, _sourceDatabase, _sourceUserName,GetPassword(true));

            if (!string.IsNullOrEmpty(cs))
            {
                Settings.Default.SourceServer = _sourceServer;
                Settings.Default.SourceDatabase = _sourceDatabase;
                Settings.Default.SourceUserName = _sourceUserName;
                Settings.Default.Save();
            }
        }

        public ICommand DestinationConnectionCommand { get; set; }
        void OnDestinationConnection()
        {
            var cs = CheckSqlServerConnection("Destination", _destinationServer, _destinationDatabase,_destinationUserName, GetPassword(false));
            if (!string.IsNullOrEmpty(cs))
            {
                Settings.Default.DestinationServer = _destinationServer;
                Settings.Default.DestinationDatabase = _destinationDatabase;
                Settings.Default.DestinationUserName = _destinationUserName;
                Settings.Default.Save();
            }
        }

        public ICommand StartExportCommand { get; set; }
        void OnStartExport()
        {
            var scs = CheckSqlServerConnection("Source", _sourceServer, _sourceDatabase, _sourceUserName, GetPassword(true), false);
            if (string.IsNullOrEmpty(scs))
                return;
            
            var dcs = CheckSqlServerConnection("Destination", _destinationServer, _destinationDatabase,_destinationUserName, GetPassword(false), false);
            if (string.IsNullOrEmpty(dcs))
                return;

            if (_task != null && (_task.Status == TaskStatus.Running || _task.Status == TaskStatus.WaitingToRun || _task.Status == TaskStatus.WaitingForActivation))
               return;

            if (_tokenSource != null)
            {
                _tokenSource.Dispose();
            }
            
            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;

            _task = Task.Run(() =>
            {
                ExportService es = new ExportService(scs, dcs, ListOfExported, token, TableName, LogInfo);
                es.Run();
            }, token);
            /*
            try
            {
                t.Wait();
            }
            catch (AggregateException e)
            {
                var em = $"{e.Message} ";
                foreach (var ie in e.InnerExceptions)
                    em = $" {em}{ie.GetType().Name},{ie.Message}";

                ListOfExported.Add(WorkReader.CreateInfo("", 0, 0, em));
            }
            finally
            {
                _tokenSource.Dispose();
            }*/
            

           //_tokenSource.Dispose();
        }

        private void ReplayCommand()
        {
            SourceConnectionCommand = new RelayCommand(OnSourceConnection);
            DestinationConnectionCommand = new RelayCommand(OnDestinationConnection);
            StartExportCommand = new RelayCommand(OnStartExport);
            EscapeRunningCommand = new RelayCommand(OnEscapeRunning);
        }

        private string _selectedImported;
        public string SelectedImported
        {
            get => _selectedImported;
            set => Set(ref _selectedImported, value);
        }

        private string _sourceServer;
        public string SourceServer
        {
            get => _sourceServer;
            set => Set(ref _sourceServer, value);
        }

        private string _sourceDatabase;
        public string SourceDatabase
        {
            get => _sourceDatabase;
            set => Set(ref _sourceDatabase, value);
        }

        private string _sourceUserName;
        public string SourceUserName
        {
            get => _sourceUserName;
            set => Set(ref _sourceUserName, value);
        }
        
        private string _destinationServer;
        public string DestinationServer
        {
            get => _destinationServer;
            set => Set(ref _destinationServer, value);
        }

        private string _destinationDatabase;
        public string DestinationDatabase
        {
            get => _destinationDatabase;
            set => Set(ref _destinationDatabase, value);
        }

        private string _destinationUserName;
        public string DestinationUserName
        {
            get => _destinationUserName;
            set => Set(ref _destinationUserName, value);
        }

        public LogInfo LogInfo { get; set; }

        private string CheckSqlServerConnection(string title, string server, string database, string userName, string password, bool isShowSucceededMessage=true)
        {
            CheckConnection helper = new CheckConnection(title, isShowSucceededMessage);
            if (helper.CheckSqlServerConnection(server, database, userName, password))
                return helper.ConnectionString;

            return "";
        }

        private string GetPassword(bool isSource)
        {
            var pwargs = new Helpers.PasswordEventArgs();

            if (isSource)
                SourcePasswordEvent(this, pwargs);
            else
                DestinationPasswordEvent(this, pwargs);

            return pwargs.Password;
        }
    }
}