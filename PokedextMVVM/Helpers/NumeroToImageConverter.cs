using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PokedextMVVM.Helpers
{
    class NumeroToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;

            int num = (int)value;
            string param = parameter as string;
            if (param == "icono")
            {
                //return ImageSource.FromFile($"{Environment.GetFolderPath(Environment.SpecialFolder.Personal)}/iconos/{num}.png");
                return ImageSource.FromUri(new Uri($"https://raw.githubusercontent.com/ZeChrales/PogoAssets/master/pokemon_icons/pokemon_icon_{num.ToString("000")}_00.png"));

                //return ImageSource.FromUri(new Uri($"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{num}.png"));
            }
            else
            {
                //if (num>640)
                //{

                //return ImageSource.FromUri(new Uri($"https://assets.pokemon.com/assets/cms2/img/pokedex/full/{num.ToString("000")}.png"));
                return ImageSource.FromUri(new Uri($"https://raw.githubusercontent.com/ZeChrales/PogoAssets/master/pokemon_icons/pokemon_icon_{num.ToString("000")}_00.png"));
                //}
                //else
                //{
                //    return ImageSource.FromUri(new Uri($"https://raw.githubusercontent.com/ZeChrales/PogoAssets/master/pokemon_icons/pokemon_icon_{num.ToString("000")}_00.png"));
                //}
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
