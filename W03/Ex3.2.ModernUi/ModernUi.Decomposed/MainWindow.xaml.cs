using System.Windows;

namespace ModernUi.Decomposed
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            DataContext = this;

            InitializeComponent();            
        }


        private void QuitButton_OnClick(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }
    }
}
