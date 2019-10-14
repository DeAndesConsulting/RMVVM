using RelevaMVVM.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;

namespace RelevaMVVM.Services
{
    class DistribuidorService
    {
        public ObservableCollection<Distribuidora> DistribuidoresList { get; set; }

        public DistribuidorService()
        {
            if (DistribuidoresList == null)
            {
                DistribuidoresList = new ObservableCollection<Distribuidora>();
            }
        }

        public ObservableCollection<Distribuidora> Consultar()
        {
            using (SQLite.SQLiteConnection conexion = new SQLiteConnection(App.RutaBD))
            {
                //DistribuidoresList = conexion.Table<Distribuidora>().ToList();
                //DistribuidoresList = conexion.Query<Distribuidora>("select * from Distribuidora where Id = ?", id).ToList();
                var listaLocales = conexion.Table<Distribuidora>();
                foreach (Distribuidora item in listaLocales)
                {
                    DistribuidoresList.Add(item);
                }
                return DistribuidoresList;
            }

        }
    }
}
