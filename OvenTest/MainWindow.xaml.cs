using OvenTest.ViewModel;
using System.Windows;

namespace OvenTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new FlightsVM();
        }
    }
}
