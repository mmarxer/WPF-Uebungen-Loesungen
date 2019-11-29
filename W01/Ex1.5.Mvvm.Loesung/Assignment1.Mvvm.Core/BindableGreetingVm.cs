using Assignment1.Mvvm.Util;
namespace Assignment1.Mvvm.Core
{
    /// <summary>
    /// Diese Version der ViewModel Klasse implementiert
    /// das Interface INotifyPropertyChanged (in Basisklasse
    /// BindableBase). Dies ermöglicht es dem User Interface,
    /// zur Laufzeit über Änderungen an Properties von
    /// Objekten dieser Klasse vollatuomatisch informiert zu werden.
    /// </summary>
    public class BindableGreetingVm:BindableBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);

                // Nun auch noch die Greeting Property anpassen:
                Greeting = $"Hello, {_name}!";
            }
        }

        // der Default-Wert kann direkt dem Backing Field zugewiesen werden:
        private string _greeting = "Hello, world!";
        public string Greeting
        {
            get { return _greeting; }
            set { SetProperty(ref _greeting, value); }
        }

        // Alternative wäre, dies via Konstruktor zu erledigen:
        // (Vorteil ist, dass man alle Initialisierungswerte an
        // einem Ort beisammen hat)
        /*
        public BindableGreetingVm()
        {            
            _greeting = "Hello, world!";
        }
        */
    }
}
