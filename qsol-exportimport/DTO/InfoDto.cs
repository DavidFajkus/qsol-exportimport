using GalaSoft.MvvmLight;

namespace qsol.exportimport.DTO
{
    public class InfoDto : ViewModelBase 
    {
        public string TableName { get; set; }
        
        private int _count;
        public int Count
        {
            get => _count;
            set => Set(ref _count, value);
        }

        private int _imported;
        public int Imported
        {
            get => _imported;
            set => Set(ref _imported, value);
        }

        private string _info;
        public string Info
        {
            get => _info;
            set => Set(ref _info, value);
        }
    }
}
