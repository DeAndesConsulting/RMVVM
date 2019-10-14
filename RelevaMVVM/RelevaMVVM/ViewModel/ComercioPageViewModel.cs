using RelevaMVVM.Model;
using RelevaMVVM.Services;
using RelevaMVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RelevaMVVM.ViewModel
{
    class ComercioPageViewModel : INotifyPropertyChanged
    {
        #region botones
        public Command SiguienteCommand { get; set; }
        public Command AgregarCommand { get; set; }
        public Command CancelarCommand { get; set; }

        #endregion

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

        #region variables
        public ObservableCollection<Local> ListaLocales { get; set; }
        ComercioService servicio = new ComercioService();

        private ObservableCollection<Local> _items;

        public ObservableCollection<Local> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged();
            }
        }
        private string provincia;

        public string Provincia
        {
            get { return provincia; }
            set { provincia = value;
                RaisePropertyChanged();
            }
        }

        private string tipoLocal;

        public string TipoLocal
        {
            get { return tipoLocal; }
            set { tipoLocal = value;
                RaisePropertyChanged();
            }
        }

        private string distribuidor;

        public string Distribuidor
        {
            get { return distribuidor; }
            set { distribuidor = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
                RaisePropertyChanged();
            }
        }
        private string calle;

        public string Calle
        {
            get { return calle; }
            set { calle = value;
                RaisePropertyChanged();
            }
        }
        private string numero;

        public string Numero
        {
            get { return numero; }
            set { numero = value;
                RaisePropertyChanged();
            }
        }
        private string localidad;

        public string Localidad
        {
            get { return localidad; }
            set { localidad = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public ComercioPageViewModel(INavigation navigation, Distribuidora DistribuidorSeleccionado)
        {
            Navigation = navigation;
            ListaLocales = servicio.Consultar();
            SiguienteCommand = new Command(async () => await Siguiente());
            AgregarCommand = new Command(async () => await Agregar());
            CancelarCommand = new Command(async () => await Cancelar());
        }
        private async Task Agregar()
        {
            Local nuevoLocal = new Local()
            {
                Provincia = Provincia,
                TipoLocal = TipoLocal,
                Distribuidor = Distribuidor,
                Nombre = Nombre,
                Calle = Calle,
                Numero = Numero,
                Localidad = Localidad,
            };
            using (SQLite.SQLiteConnection conexion = new SQLite.SQLiteConnection(App.RutaBD))
            {
                var result = conexion.Insert(nuevoLocal);
                if (result > 0)
                {
                    //await DisplayAlert("ATENCION", "Local agregado con exito", "Ok");
                }
                //else await DisplayAlert("ERROR", "Intente nuevamente", "Ok");
            }
            await Navigation.PushAsync(new RelevamientoPage());
        }


        private async Task Cancelar()
        {

            await Navigation.PopAsync();

        }

        private async Task Siguiente()
        {

            await Navigation.PushAsync(new RelevamientoPage());

        }

    }
}
