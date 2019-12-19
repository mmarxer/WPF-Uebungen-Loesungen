using System;
using System.Globalization;
using Xamarin.Forms;

namespace AutoUi.Mobile.Converters
{
    public class NegatingBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return !(bool)value;
            }
            throw new NotSupportedException("Only supports boolean values");
        }
 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool)
            {
                return !(bool)value;
            }
            throw new NotSupportedException("Only supports boolean values");
        }

    }
}