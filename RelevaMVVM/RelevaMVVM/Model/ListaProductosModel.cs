using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RelevaMVVM.Model
{
    public class ListaProductosModel : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }


        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string produco;

        public string Producto
        {
            get { return produco; }
            set { produco = value; }
        }

        private int precio;

        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private bool existe;

        public bool Existe
        {
            get { return existe; }
            set { existe = value; }
        }

        private int tipoProducto;

        public int TipoProducto
        {
            get { return tipoProducto; }
            set { tipoProducto = value; }
        }
    }

    public class TipoLocalModel : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

    }
    public class DistribuidoraModel : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string provincia;

        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        public string FormattedText
        {
            get
            {
                return String.Format("({0}) ({1})", Id, Nombre);
            }
        }
    }


    public class LocalModel : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string provincia;

        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        private string tipoLocal;

        public string TipoLocal
        {
            get { return tipoLocal; }
            set { tipoLocal = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string distribuidor;

        public string Distribuidor
        {
            get { return distribuidor; }
            set { distribuidor = value; }
        }

        private string calle;

        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }

        private string numero;

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private string localidad;

        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }



        public string Direccion
        {
            get
            {
                return String.Format("{0} {1}, ({2})", Calle, Numero, Localidad);
            }
        }
        public string FormattedText
        {
            get
            {
                return String.Format("Local: {0} - Direccion: {1}, ({2})", Nombre, Direccion, Provincia);
            }
        }
        //[OneToMany(CascadeOperations = CascadeOperation.CascadeInsert)]
        //public List<ListaProductos> ListadoProductos { get; set; }

    }

    public class TipoProductosModel : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string tipoProducto;

        public string TipoProducto
        {
            get { return tipoProducto; }
            set { tipoProducto = value; }
        }

    }

    public class RelevadoModel : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        } // Id del dato

        private string tipoLocal;

        public string TipoLocal
        {
            get { return tipoLocal; }
            set { tipoLocal = value; }
        }

        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private string provincia;

        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        private string nombreDistribuidor;

        public string NombreDistribuidor
        {
            get { return nombreDistribuidor; }
            set { nombreDistribuidor = value; }
        }

        private string latitud;

        public string Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }

        private string longitud;

        public string Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }

        private DateTime fechaRelevado;

        public DateTime FechaRelevado
        {
            get { return fechaRelevado; }
            set { fechaRelevado = value; }
        }

        private bool status;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }




        //public string TipoLocal { get; set; } // tipo de local relevado
        //public string Direccion { get; set; } // Direccion del local relevado
        //public string Provincia { get; set; } // PRovincia del comercio relevado
        //public string NombreDistribuidor { get; set; } // Nombre del distribuidor
        //public string Latitud { get; set; }
        //public string Longitud { get; set; }
        //public DateTime FechaRelevado { get; set; }
        //public bool Status { get; set; }

    }
    public class ProvinciaModel : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        private int id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string prov;

        public string Prov
        {
            get { return prov; }
            set { prov = value; }
        }



    }
}
