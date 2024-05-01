using System.Windows;
using WpfTreeview.Directory.ViewModels;

namespace WpfTreeview
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new DirectoryStructureViewModel();
        }
    }
}
