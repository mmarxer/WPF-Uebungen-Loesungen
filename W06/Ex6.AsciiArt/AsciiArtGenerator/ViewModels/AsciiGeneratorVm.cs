using System;
using System.Drawing;
using System.Threading.Tasks;
using AsciiArtGenerator.Commands;

namespace AsciiArtGenerator.ViewModels
{
    public class AsciiGeneratorVm : BindableBase
    {
        // Kommando, das ein ASCII Art erzeugt
        public RelayCommand CalcCommand { get; set; }

        // Kommando, das den Datei-Öffnen Dialog anzeigt
        public RelayCommand ChooseFileCommand { get; set; }

        private int _fontSize;

        public int FontSize
        {
            get { return _fontSize; }
            set { SetProperty(ref _fontSize, value, nameof(FontSize)); }
        }


        private int _lineWidth;

        public int LineWidth
        {
            get { return _lineWidth; }
            set { SetProperty(ref _lineWidth, value, nameof(LineWidth)); }
        }

        private string _result;

        public string Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value, nameof(Result)); }
        }


        private string _imagePath;

        public string ImagePath
        {
            get { return _imagePath; }
            set { SetProperty(ref _imagePath, value, nameof(ImagePath)); }
        }

        private bool _canCreate;

        public bool CanCreate
        {
            get { return _canCreate; }
            set { SetProperty(ref _canCreate, value, nameof(CanCreate)); }
        }

        /// <summary>
        /// kann von aussen gesetzt werden, um die Logik für das
        /// Abfragen eines Dateipfads aufzurufen (vgl. WpfPlatformSupport im Plattform-Projekt)
        /// </summary>
        public Func<string> OnChooseFile { get; set; }

        /// <summary>
        /// kann von aussen gesetzt werden, um die Logik für die
        /// Anzeige eines Fehlers zu implementieren (vgl. WpfPlatformSupport im Plattform-Projekt)
        /// </summary>
        public Action<string, string> OnShowError { get; set; }

        public AsciiGeneratorVm()
        {
            CanCreate = true;
            LineWidth = 80;
            FontSize = 12;

            CalcCommand = new RelayCommand(CreateAsciiArtInBgThread);
            ChooseFileCommand = new RelayCommand(ChooseFile);
        }

        /// <summary>
        /// Erzeugt ein ASCII Art aus dem Bild, das der Property ImagePath
        /// zugewiesen wurde. Legt das Resultat in der Property Result ab.
        /// </summary>
        public void CreateAsciiArt()
        {
            // Die bisherigen Prüfungen, ob ein File ausgewählt
            // wurde und die Bilddatei existiert, haben wir in die
            // Methode CreateAsciiArtInBgThread verschoben

            // Durch Data Binding an das Flag CanCreate kann sich die View
            // selbst darüber informieren, ob eine neue  Berechnung
            // gestartet werden kann (CanCreate = true) oder wie hier
            // gerade eine Berechnung läuft (CanCreate = false) 
            CanCreate = false;

            try
            {
                // Achtung: Non-WPF Image!
                var bm = (Bitmap) System.Drawing.Image.FromFile(ImagePath);
                var generator = new Generator();
                var result = generator.GenerateFrom(bm, LineWidth);

                // should notify the UI automa(g)ically
                Result = result;
            }
            catch (Exception e)
            {
                ShowError("Es ist ein Fehler aufgetreten", $"Berechnung fehlgeschlagen. Ursache: {e.Message}");
            }

            // Am Ende unseres Background-Threads signalisieren wir mit
            // dem Flag nun, dass wir fertig sind und ein neuer
            // Berechnungsvorgang möglich wäre (in der Aufgabenstellung
            // bereits gegeben)
            CanCreate = true;
        }

        /// <summary>
        /// Wrapper um CreateAsciiArt, der diese Methode in einem Background
        /// Thread startet
        /// 
        /// Mit Data Binding auf das Flag CanCreate kann sichergestellt werden,
        /// dass keine Benachrichtigung nötig ist (Dispatcher ist im X-Plattform-
        /// Projekt nicht verfügbar)
        /// </summary>
        public void CreateAsciiArtInBgThread()
        {
            if (string.IsNullOrEmpty(ImagePath))
            {
                ShowError("Quelldatei fehlt", "Kann leider nichts berechnen: Keine Quelldatei angegeben");
                return;
            }

            if (!System.IO.File.Exists(ImagePath))
            {
                ShowError("Quelldatei nicht verfügbar", "Kann leider nichts berechnen: Quelldatei nicht gefunden");
                return;
            }

            Task.Run(() =>
            {
                CreateAsciiArt(); // Berechnung läuft nun in einem Background Thread
            });
        }

        /// <summary>
        /// Datei auswählen und den Pfad der ausgewählten Datei
        /// in der Property ImagePath speichern (wirft hier in
        /// der Basisklasse eine Exception, falls entsprechende
        /// Action nicht gesetzt ist. Im Plattform-Projekt
        /// [z.B. WPF] kann man die Action von aussen setzen
        /// und z.B. einen OpenFileDialog anzeigen)
        ///
        /// Die Änderung von ImagePath wird dann via PropertyChanged
        /// Event an alle interessierten Parteien weitergegeben.
        /// </summary>
        private void ChooseFile()
        {
            if (OnChooseFile == null)
                throw new NotImplementedException();

            var filename = OnChooseFile();
            if (!string.IsNullOrEmpty(filename))
            {
                ImagePath = filename;
            }
        }

        /// <summary>
        /// Fehler anzeigen (wirft hier in der Basisklasse eine
        /// Exception, falls entsprechende Action nicht gesetzt
        /// ist. Im Plattform-Projekt [z.B. WPF] kann man
        /// die Action von aussen setzen und z.B. eine
        /// MessageBox anzeigen)
        /// </summary>
        /// <param name="title">Der Titel</param>
        /// <param name="msg">Die Fehlermeldung</param>
        private void ShowError(string title, string msg)
        {
            if (OnShowError == null)
                throw new NotImplementedException();

            OnShowError(title, msg);
        }
    }
}
