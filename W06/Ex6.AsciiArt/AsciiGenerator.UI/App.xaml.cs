using System.Windows;
using AsciiArtGenerator.ViewModels;
using AsciiGenerator.UI.Services;
using AsciiGenerator.UI.Views;

namespace AsciiGenerator.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        // unsere Service Implementation
        public WpfDialogService DialogService { get; private set; }

        // hier wurde eine Klassen-Property angelegt, man hätte auch einfach eine
        // lokale Variable in der OnStartup-Methode verwenden können (hätte dann
        // aber zu einem späteren Zeitpunkt im App-Lifecycle keinen direkten
        // Zugriff mehr darauf)
        public AsciiGeneratorVm AppVm { get; set; }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Um etwas bessere Übersicht zu haben, initialisieren
            // wir die Services in einer Helper-Methode:
            ConfigureServices();

            // dem AppVm müssen wir nun die erzeugte Service-Instanz
            // injiziieren:
            AppVm = new AsciiGeneratorVm(DialogService);
            

            MainWindow = new MainWindow();
            MainWindow.DataContext = AppVm;
            MainWindow.Show();

        }

        /// <summary>
        /// Helper Methode, um die (Plattform-)Services einzurichten
        /// </summary>
        private void ConfigureServices()
        {
            DialogService = new WpfDialogService();

            // Hier einfach weitere Initialisierungen aufführen
            // ...
            // (manchmal wird diese Methode in eine Partial Class
            // ausgelagert, damit der Code schön übersichtlich
            // bleibt)
        }
    }
}
