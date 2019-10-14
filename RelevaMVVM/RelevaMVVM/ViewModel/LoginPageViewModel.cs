using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using RelevaMVVM.Model;
using RelevaMVVM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace RelevaMVVM.ViewModel
{
    public class LoginPageViewModel : LoginModel
    {

        public Command LoginCommand { get; set; }
        LoginModel usuario;
        public INavigation Navigation { get; set; }

        public LoginPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            LoginCommand = new Command(async () => await Login());
        }
        async Task<string> GetImei()
        {
            //Verify Permission
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Phone);
            if (status != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Phone);
                //Best practice to always check that the key exists
                if (results.ContainsKey(Permission.Phone))
                    status = results[Permission.Phone];
            }
            //Get Imei
            string imei = DependencyService.Get<IServiceImei>().GetImei();
            return imei;
        }
        private async Task Login()
        {
            usuario = new LoginModel()
            {
                NombreUsuario = NombreUsuario,
                Imei = Imei,
                Password = Password
            };
            if (string.IsNullOrEmpty(usuario.NombreUsuario))
            {
                await Application.Current.MainPage.DisplayAlert("ATENCION", "No ingreso un suario", "Ok");
            }
            if (string.IsNullOrEmpty(usuario.Password))
            {
                await Application.Current.MainPage.DisplayAlert("ATENCION", "No ingreso una contraseña", "Ok");
            }
            if (usuario.NombreUsuario == "a" && usuario.Password == "a")
            {
                await Navigation.PushAsync(new PrincipalPage(usuario));
            }

        }
    }
}