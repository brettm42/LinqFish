namespace LinqFish.Windows.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;

    /// <summary>
    /// Converter to convert an array to concatenated multi-line string.
    /// </summary>
    public class ArrayToMultiLineStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            (value as string[])?
                .Aggregate(string.Empty, (s, b) => s += $"{b},\r\n")
                .Trim()
                .TrimEnd("\r\n".ToCharArray())
                .Trim(',')
                .Trim()
            ?? string.Empty;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            (value as string)?
                .Split(',')
                .Aggregate(new List<string>(),
                    (l, s) =>
                    {
                        if (!string.IsNullOrEmpty(s))
                        {
                            l.Add(s.Trim());
                        }

                        return l;
                    })
            .ToArray()
            ?? new string[0];
    }
}
