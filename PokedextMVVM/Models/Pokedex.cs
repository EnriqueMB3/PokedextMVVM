using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQLite;
using Xamarin.Essentials;
namespace PokedextMVVM.Models
{
    public class Pokedex
    {
        SQLiteConnection connection;
        readonly string ruta = $"{System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)}/pokedex";

        public Pokedex()
        {
            //Si existe la abre, si no, la crea.
            connection = new SQLiteConnection(ruta);

            //Generamos la tabla en el caso de que no exista.
            connection.CreateTable<Pokemon>();
        }

        public async Task DescargarInfoGeneral()
        {
            if (connection.Table<Pokemon>().Count() == 0) //No existen datos en la tabla
            {
                if (Connectivity.NetworkAccess == NetworkAccess.Internet) //Si tenemos acceso a internet.
                {
                    HttpClient httpClient = new HttpClient();

                    var json = await httpClient.GetAsync("http://itesrc.net/api/pokemon");

                    json.EnsureSuccessStatusCode(); //Lanza excepcion si no se completo la descarga.

                    //Cargamos la info del json al viewmodel temporal
                    List<PokemonNombreViewModel> lista = JsonConvert.DeserializeObject<List<PokemonNombreViewModel>>(await json.Content.ReadAsStringAsync());


                    //Pasar a la base de datos
                    foreach (var item in lista)
                    {
                        Pokemon pokemon = new Pokemon()
                        {
                            Numero = item.Numero,
                            Nombre = item.Nombre
                        };

                        //Como es sqlite, solo guarda al escribir en la base de datos, no es necesario hacer savechanges
                        connection.Insert(pokemon);
                    }

                    //Lanzar un hilo con Task.Run, todo en un solo metodo
                    await Task.Run(() =>
                    {
                        DescargarIconos(lista);
                    });
                }
            }
        }

        public async Task Descargar(Pokemon obj)
        {


            HttpClient httpClient = new HttpClient();

            var json = await httpClient.GetAsync($"http://itesrc.net/api/pokemon/{obj.Numero}");

            json.EnsureSuccessStatusCode(); //Lanza excepcion si no se completo la descarga.

            PokemonViewModel pokemonVM = JsonConvert.DeserializeObject<PokemonViewModel>(await json.Content.ReadAsStringAsync());

            obj.Descripcion = pokemonVM.descripcion;
            obj.Altura = pokemonVM.altura;
            obj.Peso = pokemonVM.peso;
            obj.Categoria = pokemonVM.categoria;

            if (pokemonVM.evolucion != null)
            {
                obj.Evolucion = pokemonVM.evolucion.numero;
            }
            if (pokemonVM.preevolucion != null)
            {
                obj.Preevolucion = pokemonVM.preevolucion.numero;
            }

            obj.Tipo1 = pokemonVM.tipo1;
            obj.Tipo2 = pokemonVM.tipo2;

            connection.Update(obj);

        }

        //Doble int, <int, int> porque es para lo que lleva y lo que es en total
        public event Action<int, int> ActualizarProgreso;

        public void DescargarIconos(List<PokemonNombreViewModel> lista)
        {
            //var path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "iconos");
            var path = $"{System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)}iconos/";

            //Crea el directorio si no existe.
            Directory.CreateDirectory(path);

            foreach (var item in lista)
            {
             WebClient webClient = new WebClient();
                webClient.DownloadFile(new Uri(item.Icono), $"{path}{item.Numero}.png");
                ActualizarProgreso?.Invoke(item.Numero, lista.Count);
            }
        }

        public List<Pokemon> GetPokemons()
        {
            //Selecciona todos los datos de la tabla, como si fuera un getall
            return new List<Pokemon>(connection.Table<Pokemon>());
        }
    }
}
