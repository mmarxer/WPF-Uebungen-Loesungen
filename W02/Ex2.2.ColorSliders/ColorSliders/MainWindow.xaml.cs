using System.Windows;
using System.Windows.Media;

namespace ColorSliders
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

        private void ColorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var r = (byte)ColorR.Value;
            var g = (byte)ColorG.Value;
            var b = (byte)ColorB.Value;

            TextR.Text = r.ToString();
            TextG.Text = g.ToString();
            TextB.Text = b.ToString();
            
            var color = Color.FromRgb(r,g,b);
            ColorArea.Fill = new SolidColorBrush(color);
            //ColorLabel.Background = new SolidColorBrush(color);
            ColorLabel.Content = color.ToHexColor(false);
        }
    }
}
