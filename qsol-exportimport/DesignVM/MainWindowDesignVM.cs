using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using qsol.exportimport.DTO;
using qsol.exportimport.Properties;

namespace qsol.exportimport.DesignVM
{
    internal class MainWindowDesignVM : ViewModelBase
    {
        public MainWindowDesignVM()
        {
            SourceServer = Settings.Default.SourceServer;
            SourceDatabase = Settings.Default.SourceDatabase;
            SourceUserName = Settings.Default.SourceUserName;
            SourcePassword = "";
            DestinationServer = Settings.Default.DestinationServer;
            DestinationDatabase = Settings.Default.DestinationDatabase;
            DestinationUserName = Settings.Default.DestinationUserName;
            DestinationPassword = "";
            ListOfExported = new List<InfoDto>()
            {
                new InfoDto()
                {
                    TableName="Table",
                    Imported=0,
                    Count =0,
                    Info = "Test"
                }
            };

            LogInfo = new LogInfo();
    }
        
        public List<string> ListOfConnect { get; set; }
        public List<InfoDto> ListOfImpored { get; set; }
        public ICommand SourceConnectionCommand { get; set; }
        public ICommand DestinationConnectionCommand { get; set; }
        public ICommand StartExportCommand { get; set; }
        public ICommand EscapeRunningCommand { get; set; }
        public List<InfoDto> ListOfExported { get; set; }

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

        public LogInfo LogInfo { get; set; }

        private string _sourceUserName;
        public string SourceUserName
        {
            get => _sourceUserName;
            set => Set(ref _sourceUserName, value);
        }

        private string _sourcePassword;
        public string SourcePassword
        {
            get => _sourcePassword;
            set => Set(ref _sourcePassword, value);
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

        private string _destinationPassword;
        public string DestinationPassword
        {
            get => _destinationPassword;
            set => Set(ref _destinationPassword, value);
        }
    }
}
