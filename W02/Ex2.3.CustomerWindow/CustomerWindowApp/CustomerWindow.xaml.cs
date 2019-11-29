using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CustomerWindowApp
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }


        public CustomerWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            LastName = LastNameBox.Text;
            FirstName = FirstNameBox.Text;

            try
            {
                BirthDate = DateTime.ParseExact(BirthDateBox.Text, "dd.MM.yyyy", CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Das Datumsformat stimmt nicht", 
                    "Fehler", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // schliesst unmittelbar das Fenster und kehrt zum Aufrufer zurück
            DialogResult = false;
        }

    }
}
