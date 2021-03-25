using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PokedextMVVM.Helpers
{
    public class TypeToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string typo = (string)value;//transformación UNICODE
            if (typo != null)
            {


                if (typo.ToLower() == "eléctrico")
                {
                    return "Iconos/Fondo/" + "electrico.png";

                }
                if (typo.ToLower() == "psíquico")
                {
                    return "Iconos/Fondo/" + "psiquico.png";

                }
                if (typo.ToLower() == "dragón")
                {
                    return "Iconos/Fondo/" + "dragon.png";

                }
                else
                {

                    return "Iconos/Fondo/" + typo.ToLower() + ".png";
                }
            }
            else
            {
                return "Iconos/Fondo/background.png";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
