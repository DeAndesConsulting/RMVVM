using RelevaMVVM.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RelevaMVVM.Services
{
    class ProductosService
    {
        public ObservableCollection<ListaProductos> Productos { get; set; }

        public ProductosService()
        {
            if (Productos == null)
            {
                Productos = new ObservableCollection<ListaProductos>();
            }
        }

        public ObservableCollection<ListaProductos> Consultar(int Opcion)
        {
            using (SQLite.SQLiteConnection conexion = new SQLiteConnection(App.RutaBD))
            {

                var listaProductos = conexion.Query<ListaProductos>("select * from ListaProductos where TipoProducto = ?", Opcion);
                foreach (ListaProductos item in listaProductos)
                {
                    Productos.Add(item);
                }
                return Productos;
            }

        }
    }
}
