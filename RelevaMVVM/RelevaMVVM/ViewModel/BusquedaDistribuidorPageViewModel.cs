using RelevaMVVM.Model;
using RelevaMVVM.Services;
using RelevaMVVM.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RelevaMVVM.ViewModel
{
    class BusquedaDistribuidorPageViewModel: INotifyPropertyChanged
    {
        public Command ComercioCommand { get; set; }
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

        #region var

        private bool listVisible=true;

        public bool ListVisible
        {
            get { return listVisible; }
            set { listVisible = value;
                RaisePropertyChanged();
            }
        }


        private Distribuidora _selectedItem;
        public Distribuidora SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                OnPropertyChanged("SelectedItem");
                _selectedItem = value;
                Comercio(_selectedItem);
            }
        }

        private ObservableCollection<Distribuidora> _items;

        public ObservableCollection<Distribuidora> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged();
            }
        }
        private bool distribuidorList = false;
        public bool DistribuidorList
        {
            get { return distribuidorList; }
            set
            {
                distribuidorList = value;

            }
        }
        private string busquedaDistribuidor;

        public string BusquedaDistribuidor
        {
            get { return busquedaDistribuidor; }
            set { busquedaDistribuidor = value; }
        }

        private bool stackVisible = false;

        public bool StackVisible
        {
            get { return stackVisible; }
            set { stackVisible = value;
                RaisePropertyChanged();

            }
        }

        private string nombreFantasia;

        public string NombreFantasia
        {
            get { return nombreFantasia; }
            set { nombreFantasia = value; }
        }

        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        #endregion


        public ObservableCollection<Distribuidora> ListaDistribuidores { get; set; }
        DistribuidorService servicio=new DistribuidorService();
        BusquedaDistribuidorModel Distribuidora;
        public INavigation Navigation { get; set; }
        public BusquedaDistribuidorPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ListaDistribuidores = servicio.Consultar();
            ComercioCommand = new Command(async () => await Comercios(SelectedItem));
        }
        private async Task Comercios(Distribuidora DistribuidorSeleccionado)
        {
                await Navigation.PushAsync(new ComercioPage(DistribuidorSeleccionado));
        }
        void Comercio(object _selectedItem)
        {
            if (_selectedItem != null)
            {
                ListVisible = false;
                StackVisible = true;

            }

        }
        private string _searchedText;
        public string SearchedText
        {
            get
            {
                return _searchedText;
            }
            set
            {
                _searchedText = value;
                OnPropertyChanged("SearchedText");
                SearchCommandExecute();
            }
        }

        private void SearchCommandExecute()
        {
            if (ListaDistribuidores != null && ListaDistribuidores.Count > 0)
            {
                var tempRecords = ListaDistribuidores.Where(x => x.FormattedText.ToLower().Contains(SearchedText.ToLower()));
                Items = new ObservableCollection<Distribuidora>();
                foreach (Distribuidora item in tempRecords)
                {
                    Items.Add(item);
                }
                if(Items.Count>0)
                {
                    StackVisible = true;
                }
            }
        }
    }
}
