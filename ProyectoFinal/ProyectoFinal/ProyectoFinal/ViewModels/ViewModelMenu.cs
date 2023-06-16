using ProyectoFinal.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ProyectoFinal.ViewModels
{
    public class ViewModelMenu : INotifyPropertyChanged
    {
        public ViewModelMenu() {

            navegarCrearAereo = new Command(() =>
            {

                var paginaAereo = new CrearAereo();
                Application.Current.MainPage.Navigation.PushAsync(paginaAereo);

            });

            navegarCrearTerrestre = new Command(() =>
            {

                var paginaTerrestre = new Page1();
                Application.Current.MainPage.Navigation.PushAsync(paginaTerrestre);

            });

            navegarMostrarTerrestre = new Command(() =>
            {

                var paginaMostrarVehiculosTerrestres = new VehiculosTerrestres();
                Application.Current.MainPage.Navigation.PushAsync(paginaMostrarVehiculosTerrestres);

            });

            navegarMostrarAereo = new Command(() =>
            {

                var paginaMostrarVehiculosAereo = new VehiculosAereos();
                Application.Current.MainPage.Navigation.PushAsync(paginaMostrarVehiculosAereo);

            });



        }

        public Command navegarCrearAereo { get; }
        public Command navegarCrearTerrestre { get; }
        public Command navegarMostrarTerrestre { get; }
        public Command navegarMostrarAereo { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
