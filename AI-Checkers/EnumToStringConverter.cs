using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace AI_Checkers
{
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType().IsEnum)
            {
                var actual = (FieldStatus)Enum.Parse(typeof(FieldStatus), value.ToString());
                return actual.ToString();
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType() == typeof(string))
            {
                return (FieldStatus)Enum.Parse(typeof(FieldStatus), value.ToString());
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }
    }
}
