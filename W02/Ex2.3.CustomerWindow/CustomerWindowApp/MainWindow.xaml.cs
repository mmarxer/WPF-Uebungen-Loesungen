using System.Diagnostics;
using System.Windows;

namespace CustomerWindowApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new CustomerWindow();
            var result = win.ShowDialog();
            if (result == true)
            {
                Debug.WriteLine($"Erfasst: {win.LastName} {win.FirstName} ({win.BirthDate:dd.MM.yyyy})");
                return;
            }

            Debug.WriteLine($"Abgebrochen");
        }

    }
}
