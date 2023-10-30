using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SimpleTextEditorWPF.Converter
{
    public class StringToFontWeightConverter : IValueConverter
    {
        public object Convert(object value, Type targerType, object parameter, CultureInfo culture)
        {
            if (value is string)
            {
                return (FontWeight)(new FontWeightConverter()).ConvertFrom(value);
            }
            return FontWeights.Normal;
        }

        public object ConvertBack(object value, Type targerType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}