using RelevaMVVM.Model;
using RelevaMVVM.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace RelevaMVVM.ViewModel
{
    class AguasPageViewModel
    {
        ProductosService servicio = new ProductosService();
        public ObservableCollection<ListaProductos> ListaAguas { get; set; }
        public INavigation Navigation { get; set; }
        public AguasPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            int Aguas = 1;
            ListaAguas = servicio.Consultar(Aguas);
        }
    }
}
