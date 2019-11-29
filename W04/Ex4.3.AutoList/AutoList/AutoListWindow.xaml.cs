using System;
using System.Collections.Generic;
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
using AutoList.Services;
using AutoList.ViewModels;

namespace AutoList
{
    /// <summary>
    /// Interaction logic for AutoListWindow.xaml
    /// </summary>
    public partial class AutoListWindow : Window
    {
        public AutoListWindow()
        {
            InitializeComponent();

            var vm = new AutoListVm()
            {
                Autos = MockDataProvider.BeispielAutos
            };

            DataContext = vm;
        }
    }
}
