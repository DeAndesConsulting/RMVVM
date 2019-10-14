using RelevaMVVM.Model;
using RelevaMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace RelevaMVVM.ViewModel
{
    class JugosPageViewModel : INotifyPropertyChanged
    {
        #region inotify
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public INavigation Navigation { get; set; }
        #endregion

        ProductosService servicio = new ProductosService();
        public ObservableCollection<ListaProductos> ListaJugos { get; set; }

        public JugosPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            int Aguas = 1;
            ListaJugos = servicio.Consultar(Aguas);
        }
    }
}
