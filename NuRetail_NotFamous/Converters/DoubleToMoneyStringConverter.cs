using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NuRetail_NotFamous.Converters
{
    class DoubleToMoneyStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                double b = (double)value;
                return "$" + String.Format("{0:0.00}", value);
            }
            catch
            {
                decimal b = (decimal)value;
                return "$" + String.Format("{0:0.00}", value);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
