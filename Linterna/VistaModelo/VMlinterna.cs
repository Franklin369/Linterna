using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
namespace Linterna.VistaModelo
{
  public  class VMlinterna:BaseViewModel
    {
        #region VARIABLES
        bool _encendido;
        string iconoon = "on.png";
        string iconoof = "of.png";
        string focoOn = "focoon.png";
        string focoOf = "focoof.png";
        string _Texto;
        public string OnOficon { get => _encendido ? iconoof : iconoon; }
        public string OnOffoco { get => _encendido ? focoOn : focoOf; }
        #endregion
        #region CONSTRUCTOR
        public VMlinterna()
        {
           
        }
        #endregion
        #region OBJETOS
        public bool Encendido
        {
            get { return _encendido; }
            set { SetValue(ref _encendido, value);
                OnPropertyChanged(nameof(OnOficon));
                OnPropertyChanged(nameof(OnOffoco));
            }
        }
        #endregion
        #region PROCESOS
        public async Task Onluz()
        {
            Vibrar();
            await Flashlight.TurnOnAsync();
        }
        public async Task Ofluz()
        {
            await Flashlight.TurnOffAsync();
        }
        private void  Vibrar()
        {
            Vibration.Vibrate();
            var duracion = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duracion);
        }
        private async Task OnOf()
        {
            if(_encendido==true)
            {
                Encendido = false;
               await Ofluz();
            }
            else
            {
                Encendido = true;
              await Onluz();
            }
        }
        #endregion
        #region COMANDOS
        public ICommand OnOfcommand => new Command(async()=>await OnOf());
        #endregion
    }
}
