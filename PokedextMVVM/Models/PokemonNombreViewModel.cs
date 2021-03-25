using System;
using System.Collections.Generic;
using System.Text;

namespace PokedextMVVM.Models
{
    public class PokemonNombreViewModel
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Icono { get; set; }

        public override string ToString()
        {
            return Nombre ?? ""; 
        }
    }
}
