using System.Globalization;

namespace PommesTimer.MAUI.Converter
{
    public class NotConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool val)
            {
                return !val;
            }
            
            throw new NotSupportedException("Other values than bool are not supported");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool val)
            {
                return !val;
            }
            
            throw new NotSupportedException("Other values than bool are not supported");
        }
    }
}