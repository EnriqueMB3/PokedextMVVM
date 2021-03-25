using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokedextMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPokemonView : ContentPage
    {
        public ListaPokemonView()
        {
            InitializeComponent();
           
        }

        private void search1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(search1.Text))
            {
                search1.SearchCommand.Execute("");
            }
        }
    }
}