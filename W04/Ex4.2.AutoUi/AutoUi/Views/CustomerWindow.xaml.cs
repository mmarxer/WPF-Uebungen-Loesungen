using System.Windows;
using AutoUi.ViewModels;

namespace AutoUi.Views
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public CustomerVm Model { get; set; }

        public CustomerWindow(CustomerVm model)
        {
            InitializeComponent();

            // falls kein Model übergeben wurde, erstellen wir einfach eines:
            Model = model ?? new CustomerVm();

            DataContext = Model;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Achtung: folgende Zeile wirft eine Exception, falls man
            // das Fenster nicht mit der .ShowDialog()-Methode, sondern
            // nur mit der normalen .Show()-Methode anzeigt
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Achtung: folgende Zeile wirft eine Exception, falls man
            // das Fenster nicht mit der .ShowDialog()-Methode, sondern
            // nur mit der normalen .Show()-Methode anzeigt
            DialogResult = false;
        }
    }
}
