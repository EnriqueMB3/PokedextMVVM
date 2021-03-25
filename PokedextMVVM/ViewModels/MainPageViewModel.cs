
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using PokedextMVVM.Models;
using PokedextMVVM.Views;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PokedextMVVM.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
	{
		//Pokedex pokedex = new Pokedex(); - Se movio a App.Xaml.cs para que todos los viewmodels lo puedan utilizar

		public event PropertyChangedEventHandler PropertyChanged;

		void Actualizar([CallerMemberName]string nombre = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
		}

		private double valor;
		private string error;
		private bool running;

		public double Valor
		{
			get { return valor; }
			set { valor = value; Actualizar(); }
		}

		public string Error
		{
			get { return error; }
			set { error = value; Actualizar(); }
		}

		public bool Running
		{
			get { return running; }
			set { running = value; Actualizar(); }
		}

		public MainPageViewModel()
		{
			App.Pokedex.ActualizarProgreso += Pokedex_ActualizarProgreso;
			//Descargar();
			Task.Run(Descargar);
		}

		private void Pokedex_ActualizarProgreso(int arg1, int arg2)
		{
			

			Valor = arg1 / (double)arg2;
		}


		
		public async void Descargar()
		{
			if (Connectivity.NetworkAccess != NetworkAccess.Internet)
			{
				Error = "No hay conexión a internet.";
				return;
			}

			try
			{
				Running = true;

				await App.Pokedex.DescargarInfoGeneral();

				Running = false;

				//Tenemos que desuscribir al evento para que pueda entrar a la siguiente pagina.
				App.Pokedex.ActualizarProgreso -= Pokedex_ActualizarProgreso;

				//Cambiar de pagina
				Application.Current.MainPage = new NavigationPage(new PokedextMVVM.Views.ListaPokemonView());
				//Application.Current.MainPage = null;
				//Application.Current.MainPage = new NavigationPage(new ListaPokemonView());
				//Actualizar();
				//ListaPokemonView listaPokemonView = new ListaPokemonView();
				//await Application.Current.MainPage.Navigation.PushAsync(listaPokemonView);
			}
			catch (Exception ex)
			{
				Error = ex.Message;
			}
		}
	}
}
