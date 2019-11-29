using System.Diagnostics;
using System.Windows;

namespace HelloWorld
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

        private void SayHelloButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Der Button {SayHelloButton.Name} wurde geklickt!");

            Greeting.Text = $"Hello, {NameInput.Text}!";
        }

    }
}
