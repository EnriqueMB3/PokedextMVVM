using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PokedextMVVM.Views;
using PokedextMVVM.Models;

namespace PokedextMVVM
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

      
            MainPage = new MainPage();
        }
        public static Pokedex Pokedex { get; set; } = new Pokedex();

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
