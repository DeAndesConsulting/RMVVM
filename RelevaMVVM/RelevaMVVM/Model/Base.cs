using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RelevaMVVM.Model
{

    public class Usuario
    {
        public string NombreUsuario { get; set; }
        public string NumeroImei { get; set; }
    }
    public class Provincia
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Prov { get; set; }

    }

    public class TipoLocal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Tipo { get; set; }

    }
    public class Distribuidora
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Provincia { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string FormattedText
        {
            get
            {
                return String.Format("({0}) ({1})", Id, Nombre);
            }
        }
    }


    public class Local
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Provincia { get; set; }
        public string TipoLocal { get; set; }
        public string Distribuidor { get; set; }
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Localidad { get; set; }

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

    public class TipoProductos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string TipoProducto { get; set; }

    }

    public class ListaProductos
    {
        [PrimaryKey, AutoIncrement]
        //[ForeignKey(typeof(Local))]
        public int Id { get; set; }

        public string Producto { get; set; }
        public int Precio { get; set; }
        public bool Existe { get; set; }
        public int TipoProducto { get; set; }
    }

    public class Relevado
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } // Id del dato
        public string TipoLocal { get; set; } // tipo de local relevado
        public string Direccion { get; set; } // Direccion del local relevado
        public string Provincia { get; set; } // PRovincia del comercio relevado
        public string NombreDistribuidor { get; set; } // Nombre del distribuidor
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public DateTime FechaRelevado { get; set; }
        public bool Status { get; set; }

    }

    //public class TbTipoDeComercio
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int tco_id { get; set; }
    //    public string tco_descripcion { get; set; }
    //}

    //public class TbComercio
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int com_id { get; set; }
    //    public int tco_id { get; set; }
    //    public string com_nombre { get; set; }
    //    public string com_calle { get; set; }
    //    public int com_numero { get; set; }
    //    public string com_localidad { get; set; }
    //    public string com_provincia { get; set; }
    //    public string com_latitud { get; set; }
    //    public string com_longitud { get; set; }
    //}

    //public class TbArticulo
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int art_id { get; set; }
    //    public int tar_id { get; set; }
    //    public string art_descripcion { get; set; }
    //}

    //public class TbTipoDeArticulo
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int tar_id { get; set; }
    //    public string tar_desciripcion { get; set; }
    //}

    //public class TbRelevamientoArticulo
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int rel_id { get; set; }
    //    public int art_id { get; set; }
    //    public int com_id { get; set; }
    //    public bool rar_existe { get; set; }
    //    public int rar_precio { get; set; }
    //}

    //public class TbRelevamiento
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int rel_id { get; set; }
    //    public int dis_id { get; set; }
    //    public int ven_id { get; set; }
    //    public string rel_codigo { get; set; }
    //    public DateTime rel_fecha { get; set; }

    //}
}
