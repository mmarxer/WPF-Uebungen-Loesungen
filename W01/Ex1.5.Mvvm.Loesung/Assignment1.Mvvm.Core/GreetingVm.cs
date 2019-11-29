namespace Assignment1.Mvvm.Core
{
    /// <summary>
    /// Dies ist eine normale POCO (plain old C# object) Klasse.
    /// Wenn wir zur Laufzeit Properties ändern, merkt das UI
    /// nichts davon
    /// </summary>
    public class GreetingVm
    {
        // da wir beim Setzen der Name-Property etwas zusätzliches
        // erledigen möchten (Update des Greeting-Strings), müssen
        // wir getter und setter ausschreiben und selbst ein Backing
        // Field anlegen:
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Greeting = $"Hello, {_name}!";
            }
        }

        // bei Auto-implemented Properties kann der Default-Wert
        // ganz einfach zugewiesen werden:
        public string Greeting { get; set; } = "Hello, world!";

        // Alternative wäre, den Default-Wert via Konstruktor zu setzen:
        /*
        public GreetingVm()
        {
            Greeting = "Hello, world!";
        }
        */
    }
}
