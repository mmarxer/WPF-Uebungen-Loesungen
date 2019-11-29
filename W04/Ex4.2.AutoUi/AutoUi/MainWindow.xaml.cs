using System.Diagnostics;
using System.Linq;
using System.Windows;
using AutoUi.Services;
using AutoUi.ViewModels;
using AutoUi.Views;

namespace AutoUi
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

        private void AutoWindow_Click(object sender, RoutedEventArgs e)
        {
            // wir verwenden den ersten Datensatz aus der "Datenbank"
            // der Mock-Daten:
            var vm = MockDataProvider.BeispielAutos.First();

            // hier wird exemplarisch gezeigt, wie man die Details des Aufrufs
            // des Auto-Fensters wie bei Aufgabe 1 in einer Helper-Methode 
            // kapseln könnte. Dabei wird auch der Fall behandelt, dass sich
            // Das Original-ViewModel nicht ändern soll, wenn man auf Abbrechen
            // klickt
            AutoWindow.Display(vm);

            // man beachte wie das ViewModel verschiedene Bearbeitungsvorgänge
            // korrekt überlebt
            // --> klickt man im AutoWindow OK, so werden die Werte übernommen
            // --> klickt man auf Abbrechen, bleibt der Zustand davor erhalten
        }

        private void CustomerWindow_Click(object sender, RoutedEventArgs e)
        {
            var vm = MockDataProvider.BeispielKunden.First();

            // hier wird im Weiteren anhand der Projektvorlage gearbeitet (ohne Helper-Methode .Display):

            // (das Problem, dass wir wegen DataBinding direkt das Original-ViewModel
            // anpassen, auch wenn wir "Abbrechen" klicken, ignorieren wir hier)

            var win = new CustomerWindow(vm);
            if (win.ShowDialog() != true)
            {
                // Abbrechen ...
                Debug.WriteLine("Bearbeitung des Kunden abgebrochen");
                return;
            }

            // Ok geklickt... 
            Debug.WriteLine("Bearbeitung des Kunden beendet");
            return;
        }
    }
}
