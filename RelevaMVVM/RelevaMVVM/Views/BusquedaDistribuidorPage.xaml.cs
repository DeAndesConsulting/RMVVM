using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RelevaMVVM.ViewModel;
using RelevaMVVM.Model;
using System.Collections.ObjectModel;

namespace RelevaMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusquedaDistribuidorPage : ContentPage
    {
        public BusquedaDistribuidorPage()
        {
            InitializeComponent();
            BindingContext = new BusquedaDistribuidorPageViewModel(Navigation);
        }
    }
}