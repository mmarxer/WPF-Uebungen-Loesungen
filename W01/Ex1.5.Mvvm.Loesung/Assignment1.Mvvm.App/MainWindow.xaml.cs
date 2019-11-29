using Assignment1.Mvvm.Core;
using System.Windows;

namespace Assignment1.Mvvm.App
{
    public partial class MainWindow : Window
    {
        // Property Deklaration für einfacheren Zugriff auf das View Model
        private BindableGreetingVm TheModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // neue Instanz des ViewModels erzeugen ...
            TheModel = new BindableGreetingVm();

            // ... und diese dann ans UI "kleben"
            DataContext = TheModel;
        }

        private void SayHelloButton_Click(object sender, RoutedEventArgs e)
        {
            // dies ist jetzt überflüssig, da via Data Binding automatisch
            // aktualisiert:
            //TheModel.Greeting = $"Hello, {TheModel.Name}!";
        }
    }
}
