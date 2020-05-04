using System.Windows;

namespace qsol.exportimport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new ViewModel.MainViewModel();
            DataContext = vm;

            vm.SourcePasswordEvent += (sender, args) => args.Password = SourcePasswordBox.Password;
            vm.DestinationPasswordEvent += (sender, args) => args.Password = DestinationPasswordBox.Password;

            SourcePasswordBox.Password = "";
            DestinationPasswordBox.Password = "";
        }
    }
}
