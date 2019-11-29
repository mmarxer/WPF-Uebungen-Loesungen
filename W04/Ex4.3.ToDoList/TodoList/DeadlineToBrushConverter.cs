using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TodoList
{
    /// <summary>
    /// converts a date value to a red brush if the date 
    /// lies in the past and toa black brush if the date
    /// lies in the future
    /// </summary>
    public class DeadlineToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime))
                throw new NotSupportedException($"{nameof(DeadlineToBrushConverter)} can only be used for DateTime-values");

            int days = 0;
            if (parameter != null)
            {
                if (!int.TryParse(parameter.ToString(), out days))
                    throw new NotSupportedException($"{nameof(DeadlineToBrushConverter)} needs an int value as a parameter for the number of days to be used as the deadline");
            }

            var d = (DateTime)value;

            // if deadline is reached --> red else black
            if (d.AddDays(-days) < DateTime.Now)
                return Brushes.Red;

            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
