using RelevaMVVM.Model;
using RelevaMVVM.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RelevaMVVM.ViewModel
{
    class PrincipalPageViewModel
    {
        public Command RelevamientoCommand { get; set; }
        public Command EstadoCommand { get; set; }
        public INavigation Navigation { get; set; }
        public PrincipalPageViewModel(INavigation navigation, LoginModel usuario)
        {
            Navigation = navigation;
            RelevamientoCommand = new Command(async () => await Relevamiento());
            EstadoCommand = new Command(async () => await Estado());
        }



        private async Task Relevamiento()
        {
            await Navigation.PushAsync(new BusquedaDistribuidorPage());
        }

        private async Task Estado()
        {

        }

    }
}
