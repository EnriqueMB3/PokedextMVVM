using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
namespace PokedextMVVM.Models
{
    public class Pokemon: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		void Actualizar([CallerMemberName]string nombre = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
		}

		private int numero;
		private string nombre;
		private string descripcion;
		private float? altura;
		private float? peso;
		private string categoria;
		private string tipo1;
		private string tipo2;
		private int? evolucion;
		private int? preevolucion;

		#region Propiedades
        [PrimaryKey]
		public int Numero
		{
			get { return numero; }
			set { numero = value; Actualizar(); }
		}

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; Actualizar(); }
		}

		public string Descripcion
		{
			get { return descripcion; }
			set { descripcion = value; Actualizar(); }
		}

		public float? Altura
		{
			get { return altura; }
			set { altura = value; Actualizar(); }
		}

		public float? Peso
		{
			get { return peso; }
			set { peso = value; Actualizar(); }
		}

		public string Categoria
		{
			get { return categoria; }
			set { categoria = value; Actualizar(); }
		}

		public string Tipo1
		{
			get { return tipo1; }
			set { tipo1 = value; Actualizar(); }
		}

		public string Tipo2
		{
			get { return tipo2; }
			set { tipo2 = value; Actualizar(); }
		}

		public int? Evolucion
		{
			get { return evolucion; }
			set { evolucion = value; Actualizar(); }
		}

		public int? Preevolucion
		{
			get { return preevolucion; }
			set { preevolucion = value; Actualizar(); }
		}
		#endregion

	}
}
