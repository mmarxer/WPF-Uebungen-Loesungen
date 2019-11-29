using System.Windows;

namespace IconButtons
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
        
        private void SwitchTheme(ThemeTypeEnum themeType)
        {
            // global Referenz auf unsere App holen
            var app = Application.Current as App;
            
            // globalen resource dic leeren
            app.Resources.Clear();
            // auch die rein-gemerged-en dics löschen
            app.Resources.MergedDictionaries.Clear();

            // no style -> no action
            if (themeType == ThemeTypeEnum.None) return;

            var uri = Themes.GetThemeUri(themeType);
            var theme = Application.LoadComponent(uri) as ResourceDictionary;

            // nun unser Theme wieder laden
            app.Resources.MergedDictionaries.Add(theme);
        }

        private void LightTheme_Click(object sender, RoutedEventArgs e)
        {
            SwitchTheme(ThemeTypeEnum.Light);
        }

        private void DarkTheme_Click(object sender, RoutedEventArgs e)
        {
            SwitchTheme(ThemeTypeEnum.Dark);
        }
    }
}
