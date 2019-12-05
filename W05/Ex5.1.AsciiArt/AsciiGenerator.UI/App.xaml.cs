using System.Windows;
using AsciiArtGenerator.ViewModels;
using AsciiGenerator.UI.Util;
using AsciiGenerator.UI.Views;

namespace AsciiGenerator.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public WpfPlatformSupport PlatformSupport { get; set; } = new WpfPlatformSupport();

        // hier wurde eine Klassen-Property angelegt, man hätte auch einfach eine
        // lokale Variable in der OnStartup-Methode verwenden können (hätte dann
        // aber zu einem späteren Zeitpunkt im App-Lifecycle keinen direkten
        // Zugriff mehr darauf)
        public AsciiGeneratorVm AppVm { get; set; }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AppVm = new AsciiGeneratorVm();
            // hier fügen wir per Dependency Injection die konkreten Implementierungen
            // des ChooseFile-Dialogs (bereits vorimplementiert in Projektvorlage)
            // und einer Message Box zur Anzeige eines Fehler ein
            AppVm.OnChooseFile = PlatformSupport.ChooseFile;
            AppVm.OnShowError = PlatformSupport.ShowError;
            // Das ViewModel bietet hier als Erweiterungspunkt aus Bequemlichkeit einzelne Methoden an
            // In der Praxis werden es eher ganze Interfaces sein und wir würden pro Plattform eine
            // Klasse mit einer konkreten Implementierung des Interfaces erstellen, hier instanziieren
            // und dann zuweisen

            MainWindow = new MainWindow();
            MainWindow.DataContext = AppVm;
            MainWindow.Show();

        }
    }
}
