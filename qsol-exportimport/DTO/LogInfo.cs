using GalaSoft.MvvmLight;

namespace qsol.exportimport.DTO
{
    public class LogInfo : ViewModelBase
    {
        private string _info;
        public string Info
        {
            get => _info;
            set => Set(ref _info, value);
        }
    }
}
