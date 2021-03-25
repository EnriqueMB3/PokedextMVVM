using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PokedextMVVM.Helpers
{
    public class TypeToIconType : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string typo = (string)value;//transformación UNICODE
            if (typo != null)
            {


                if (typo.ToLower() == "eléctrico")
                {
                    return "Iconos/" + "electrico_icon.png";

                }
                if (typo.ToLower() == "psíquico")
                {
                    return "Iconos/" + "psiquico_icon.png";

                }
                if (typo.ToLower()=="dragón")
                {
                    return "Iconos/" + "dragon_icon.png";

                }
                else
                {

                    return "Iconos/" + typo.ToLower() + "_icon.png";
                }
            }
            else
            {
                return "";
            }
            

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
