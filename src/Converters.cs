using System;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace TripAdvisor
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool free)
            {
                if (free) return Visibility.Hidden;
                return Visibility.Visible;
            }
            throw new ArgumentException("The parameter 'value' should be of type 'bool'.");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class PathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string name)
            {
                var sb = new StringBuilder("Resources/");
                sb.Append(name);
                return sb.ToString();
            }
            throw new ArgumentException("The parameter 'value' should be of type 'string'.");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class OpeningDaysConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DayOfTheWeek openingDays && parameter is string text)
            {
                var converter = new PolishDayOfTheWeekConverter();
                DayOfTheWeek selected = (DayOfTheWeek)converter.Convert(text, null, null, null);
                return (openingDays & selected) == selected;
            }
            throw new ArgumentException("The parameters 'value' and 'parameter' should be of type 'DayOfTheWeek' and 'string'.");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class PolishDayOfTheWeekConverter : IValueConverter
    {
        public object Convert(object value, Type? targetType, object? parameter, CultureInfo? culture)
        {
            if (value is string text)
            {
                return text switch
                {
                    "Wszystkie dni" => DayOfTheWeek.All,
                    "Poniedziałek" => DayOfTheWeek.Monday,
                    "Wtorek" => DayOfTheWeek.Tuesday,
                    "Środa" => DayOfTheWeek.Wednesday,
                    "Czwartek" => DayOfTheWeek.Thursday,
                    "Piątek" => DayOfTheWeek.Friday,
                    "Sobota" => DayOfTheWeek.Saturday,
                    "Niedziela" => DayOfTheWeek.Sunday,
                    _ => throw new ArgumentException("The given text does not match any flag.")
                };
            }
            throw new ArgumentException("The parameter 'value' should be of type 'string'.");
        }
        public object ConvertBack(object value, Type? targetType, object? parameter, CultureInfo? culture)
        {
            if (value is DayOfTheWeek flag)
            {
                return flag switch
                {
                    DayOfTheWeek.All => "Wszystkie dni",
                    DayOfTheWeek.Monday => "Poniedziałek",
                    DayOfTheWeek.Tuesday => "Wtorek",
                    DayOfTheWeek.Wednesday => "Środa",
                    DayOfTheWeek.Thursday => "Czwartek",
                    DayOfTheWeek.Friday => "Piątek",
                    DayOfTheWeek.Saturday => "Sobota",
                    DayOfTheWeek.Sunday => "Niedziela",
                    _ => string.Empty
                };
            }
            throw new ArgumentException("The parameter 'value' should be of type 'DayOfTheWeek'.");
        }
    }
    public class ListOfDaysConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DayOfTheWeek daysOfWeek)
            {
                if (daysOfWeek == DayOfTheWeek.All)
                {
                    return "Wszystkie dni";
                }
                var converter = new PolishDayOfTheWeekConverter();
                DayOfTheWeek[] days = (DayOfTheWeek[])Enum.GetValues(typeof(DayOfTheWeek));
                var sb = new StringBuilder();
                foreach (var day in days)
                    if (daysOfWeek.HasFlag(day))
                    {
                        if (day == DayOfTheWeek.None) continue;
                        sb.Append(converter.ConvertBack(day, null, null, null) + ", ");
                    }
                return sb.ToString().TrimEnd(',', ' ');
            }
            throw new ArgumentException("The parameter 'value' should be of type 'DayOfTheWeek'.");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
