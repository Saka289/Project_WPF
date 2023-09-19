using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WPF_Project.Converter
{
    [ValueConversion(typeof(string), typeof(bool))]
    class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is String str)
            {
                if (str.ToLower().Equals("male")) return true;
                else return false;
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool bl)
            {
                if (bl == true) return "Male";
                else return "Female";
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
