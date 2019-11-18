using System;
using System.Globalization;
using System.Windows.Data;

namespace PresentationLayer.helper
{
    //class used to pack more than one argumenent used in ICommand interface mathods: CanExecute, Execute
    public class MyConverter : IMultiValueConverter 
    {      
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    } 
}