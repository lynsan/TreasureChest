using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;


namespace Treasure.Chest.ViewModels
{
    public class CorrectTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((CorrectType)value)
            {
                case CorrectType.CorrectNumberAndPlace:
                    return new SolidColorBrush(Colors.Green);
                case CorrectType.CorrectNumber:
                    return new SolidColorBrush(Colors.Yellow);
                case CorrectType.Incorrect:
                    return new SolidColorBrush(Colors.Transparent);

            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
