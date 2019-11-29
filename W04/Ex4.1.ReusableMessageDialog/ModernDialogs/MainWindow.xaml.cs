using System.Windows;

namespace ModernDialogs
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

        private void SampleButton_OnClick(object sender, RoutedEventArgs e)
        {
            // wir öffnen nun das Fenster nicht mehr direkt, sondern via
            // bequemer Nutzung der Helper-Methode .Display(...)

            ConfirmBox.Display("Beispiel", 
                "Beispiel-Meldung", 
                "Dies ist eine Beispielmeldung.", 
                "Got it!");
        }
    }
}
