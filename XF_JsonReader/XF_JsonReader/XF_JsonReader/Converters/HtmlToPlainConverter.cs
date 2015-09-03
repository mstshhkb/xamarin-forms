using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using HtmlAgilityPack;
using Xamarin.Forms;


namespace XF_JsonReader.Converters
{
    class HtmlToPlainConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;

            // HtmlAgilityPack を使用してタグ付きの string からタグを除去します。
            var hap = new HtmlAgilityPack.HtmlDocument();
            hap.LoadHtml(value.ToString());
            var doc = hap.DocumentNode.InnerText.Replace("&hellip;", "…");
            return doc;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
