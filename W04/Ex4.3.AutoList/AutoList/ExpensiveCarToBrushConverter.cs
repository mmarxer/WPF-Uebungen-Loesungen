using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using AutoList.ViewModels;

namespace AutoList
{
    public class ExpensiveCarToBrushConverter : IValueConverter
    {
        public object Convert(object price, Type targetType, object parameter, CultureInfo culture)
        {
            var expensiveBrush = Brushes.Red;
            var normalBrush = Brushes.Black;

            return (decimal)price > 1000 ? expensiveBrush : normalBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
