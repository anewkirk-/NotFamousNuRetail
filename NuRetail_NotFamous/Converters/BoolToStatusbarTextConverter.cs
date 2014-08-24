using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NuRetail_NotFamous.Converters
{
    class BoolToStatusbarTextConverter : IValueConverter
    {

        private static string connectedText = "Connected to database server.";
        private static string notConnectedText = "Not connected.";

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool v = (bool)value;
            return v ? connectedText : notConnectedText;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string v = (string) value;
            return v.Equals(connectedText) ? true : false;
        }
    }
}
