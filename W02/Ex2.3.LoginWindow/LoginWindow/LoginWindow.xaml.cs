using System.Windows;

namespace LoginWindowApp
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string UserName { get; set; }
        public string Password { get; set; }


        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            UserName = MyLoginNameBox.Text;
            Password = MyPasswordBox.Password;

            // Hier noch ein paar Validierungen…
            if (string.IsNullOrWhiteSpace(UserName))
            {
                MessageBox.Show("Please enter a user name");
                return; // Dialogfenster NICHT schliessen
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Please enter a password");
                return; // Dialogfenster NICHT schliessen
            }
            // das Setzen der Property .DialogResult schliesst das
            // Fenster (als Nebeneffekt des Property Setters??? -> wtf?)
            // und der Aufrufer erhält den gesetzten Property
            // Wert (hier "true") als Rückgabewert der
            // .ShowDialog(...)-Methode zurück
            DialogResult = true;
        }

        private void CancelButton_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            // das Setzen der Property .DialogResult schliesst das
            // Fenster (als Nebeneffekt des Property Setters??? -> wtf?)
            // und der Aufrufer erhält den gesetzten Property
            // Wert (hier "false") als Rückgabewert der
            // .ShowDialog(...)-Methode zurück
            DialogResult = false;
        }

    }
}
