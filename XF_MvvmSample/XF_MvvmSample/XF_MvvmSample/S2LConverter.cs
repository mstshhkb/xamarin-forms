using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Xamarin.Forms;

namespace XF_MvvmSample
{
    class S2LConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int count = value.ToString().Length;
            return count;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            return null;
        }
    }
}
