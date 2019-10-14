using RelevaMVVM.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace RelevaMVVM.Services
{
    class ComercioService
    {
        public ObservableCollection<Local> Comercios { get; set; }

        public ComercioService()
        {
            if (Comercios == null)
            {
                Comercios = new ObservableCollection<Local>();
            }
        }

        public ObservableCollection<Local> Consultar()
        {
            using (SQLite.SQLiteConnection conexion = new SQLiteConnection(App.RutaBD))
            {

                var listaLocales = conexion.Table<Local>();
                //conexion.Query<Local>("select * from Local where Distribuidor = ?", id).ToList();
                foreach (Local item in listaLocales)
                {
                    Comercios.Add(item);
                }
                return Comercios;
            }

        }
    }
}
