namespace LinqFish.Windows.Infrastructure
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;

    /// <summary>
    /// Converter to convert an array to concatenated multi-line string.
    /// </summary>
    public class ArrayToMultiLineStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            string concatStr = string.Empty;
            foreach (object item in value as IEnumerable)
            {
                if (!string.IsNullOrWhiteSpace(item.ToString()))
                {
                    concatStr += $"{item.ToString().Trim()},\r\n";
                }
            }

            return concatStr.Trim()
                .TrimEnd("\r\n".ToCharArray())
                .Trim(',')
                .Trim();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
