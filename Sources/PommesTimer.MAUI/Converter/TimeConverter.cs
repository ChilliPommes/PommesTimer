using System.Globalization;

namespace PommesTimer.MAUI.Converter
{
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double time)
            {
                var span = TimeSpan.FromSeconds(time);

                return span.ToString(@"hh\:mm\:ss");
            }
            
            throw new NotSupportedException("Other types than double are not supported for converting into time string");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string time)
            {
                var span = TimeSpan.Parse(time);

                return span.TotalSeconds;
            }
            
            throw new NotSupportedException("Other types than a time string are not supported for converting into double");
        }
    }
}