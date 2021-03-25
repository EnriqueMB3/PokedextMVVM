using System;
using System.Collections.Generic;
using System.Text;

namespace PokedextMVVM.Models
{

    public class Preevolucion
    {
        public int numero { get; set; }
        public string nombre { get; set; }
        //public string icono { get; set; }
    }

    public class Evolucion
    {
        public int numero { get; set; }
        public string nombre { get; set; }
        //public string icono { get; set; }
    }

    public class PokemonViewModel
    {
        public string descripcion { get; set; }
        public float altura { get; set; }
        public float peso { get; set; }
        public string categoria { get; set; }
        public string tipo1 { get; set; }
        public string tipo2 { get; set; }
        public Preevolucion preevolucion { get; set; }
        public Evolucion evolucion { get; set; }
        //public string imagen { get; set; }
        public int numero { get; set; }
        public string nombre { get; set; }
        //public string icono { get; set; }
    }
}
