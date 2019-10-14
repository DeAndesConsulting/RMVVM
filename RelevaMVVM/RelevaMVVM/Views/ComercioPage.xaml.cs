using RelevaMVVM.Model;
using RelevaMVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RelevaMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ComercioPage : ContentPage
    {
        public ComercioPage(Distribuidora DistribuidorSeleccionado)
        {
            InitializeComponent();
            BindingContext = new ComercioPageViewModel(Navigation, DistribuidorSeleccionado);
        }
    }
}