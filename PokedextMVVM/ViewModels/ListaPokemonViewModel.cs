using PokedextMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokedextMVVM.ViewModels
{
   public class ListaPokemonViewModel
    {
        List<Pokemon> original;
        public Command<string> FiltrarCommand { get; set; }
        public Command<Pokemon> VerPokemonCommand { get; set; }

        public ObservableCollection<Pokemon> Lista { get; set; }

        public string Filtro { get; set; }

        public ListaPokemonViewModel()
        {
            original = App.Pokedex.GetPokemons();
            Lista = new ObservableCollection<Pokemon>();

            original.ForEach(x => Lista.Add(x));

            FiltrarCommand = new Command<string>(Filtrar);
            VerPokemonCommand = new Command<Pokemon>(Ver);
        }

        PokedextMVVM.Views.PokemonView pokemonView;
        private async void Ver(Pokemon obj)
        {
            //verificar si esta su informacion
            if (string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Task.Run(async () => await App.Pokedex.Descargar(obj));
            }
            if (pokemonView == null) pokemonView = new Views.PokemonView();
            pokemonView.BindingContext = obj;
            await App.Current.MainPage.Navigation.PushAsync(pokemonView);
        }

        private void Filtrar(string obj)
        {
            //throw new NotImplementedException();
            Lista.Clear();

            original.Where(x => string.IsNullOrWhiteSpace(obj) || x.Nombre.Contains(obj.ToLower())).ToList().ForEach(x => Lista.Add(x));
        }
    }
}
