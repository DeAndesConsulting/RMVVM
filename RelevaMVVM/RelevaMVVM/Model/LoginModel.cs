using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RelevaMVVM.Model
{
    public class LoginModel : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string nombre="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }

        private string nombreUsuario;

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value;
                OnPropertyChanged();
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value;
                OnPropertyChanged();
            }
        }

        private int imei;

        public int Imei
        {
            get { return imei; }
            set { imei = value; }
        }

        private string mensajeBienvenida;

        public  string MensajeBienvenida
        {
            get { return mensajeBienvenida; }
            set { mensajeBienvenida = value; }
        }


    }
}
