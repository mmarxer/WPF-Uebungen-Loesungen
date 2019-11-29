using System.Diagnostics;
using System.Windows;

namespace LoginWindowApp
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
            var win = new LoginWindow();
            var result = win.ShowDialog();
            if (result == true)
            {
                Debug.WriteLine($"Username: {win.UserName} / Passwort: {win.Password}");
                return;
            }

            Debug.WriteLine($"Abgebrochen");
        }

    }
}
