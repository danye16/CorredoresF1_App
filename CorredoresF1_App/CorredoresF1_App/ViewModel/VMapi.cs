using CorredoresF1_App.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CorredoresF1_App.ViewModel
{//deberia llamarse VMcorredor como el profe
    public class VMapi : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        string _Id;
        string _Name;
        int _Number;
        string _Equipo;

        #endregion
        #region CONSTRUCTOR
        public VMapi(INavigation navigation)
        {
            Navigation = navigation;

        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public string Id
        {
            get { return _Id; }
            set { SetValue(ref _Id, value); }
        }
        public string Nombre
        {
            get { return _Name; }
            set { SetValue(ref _Name, value); }
        }
        public int Numero
        {
            get { return _Number; }
            set { SetValue(ref _Number, value); }
        }
        public string Equipo
        {
            get { return _Equipo; }
            set { SetValue(ref _Equipo, value); }
        }

        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        } 
        public async Task Insertar()
        {
            Mcorredor mcorredor = new Mcorredor
            {
              //  Id = Id,
                Name = Nombre,
                Number = Numero,
                Team = Equipo

            };
            Uri RequestUri = new
                Uri("http://www.CorredoresFor3.somee.com/Api/Divers");
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(mcorredor);
            var contenJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, 
                contenJson);
            if (response.StatusCode ==HttpStatusCode.Created)
            {
                await DisplayAlert("Mensaje", "Registrado", "Ok");
            }
            else
            {
                await DisplayAlert("Mensaje", "No se registro", "Ok");
            }

        }
        public void procesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcomand => new Command(procesoSimple);
        public ICommand InsertarCorredor => new Command(async () => await Insertar());

        #endregion
    }
}
