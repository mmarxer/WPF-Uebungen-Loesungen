using System;
using System.Windows;
using System.Windows.Input;
using AsciiArtGenerator.ViewModels;

namespace AsciiGenerator.UI.Views
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

        private void UIElement_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            // für Event Handling müssen wir manchmal die MVVM-Idee
            // verletzen und doch auch aus dem Code Behind auf ein
            // ViewModel zugreifen (enge Kopplung). Wenn das die 
            // Ausnahme bleibt, ist das ok...

            // Um Zugriff auf das ViewModel zu erhalten, benutzen wir
            // einfach den DataContext und casten in entsprechend in
            // unseren ViewModel-Datentyp
            var vm = DataContext as AsciiGeneratorVm;

            if (e.Delta < 0)
            {
                if (vm.FontSize > 6) // Lower Bounds Check
                    vm.FontSize -= 1;
            }
            else
            {
                if (vm.FontSize < 120) // Upper Bounds Check
                    vm.FontSize += 1;
            }

            // Um zu verhindern, dass die Standard-Aktion der Textbox
            // ausgeführt wird (= Scrollen in der TextBox bei übergrossem
            // Inhalt), brechen wir das weitere Event-Handling ab:
            e.Handled = true;
        }
    }
}
