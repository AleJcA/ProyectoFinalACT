using ProyectoFinal.Models;
using ProyectoFinal.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace ProyectoFinal.ViewModels
{
    public class ViewModelMostrarVehiculoAereo : INotifyPropertyChanged
    {

        public ViewModelMostrarVehiculoAereo() {


            try
            {

                byte[] data = File.ReadAllBytes(ruta);
                MemoryStream memory = new MemoryStream(data);
                BinaryFormatter formater = new BinaryFormatter();
                listaAereo = (ObservableCollection<Aereo>)formater.Deserialize(memory);
                memory.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Sin archivo por cargar de Medios de Transporte");

            }

            NavegarHacerRecorrido = new Command(() => {

                var paginaRecorridoAereo = new HacerRecorridoAereo();
                var viewModel = new ViewModelAereoHacerRecorrido(Aereoseleccionado, listaAereo);
                paginaRecorridoAereo.BindingContext = viewModel;
                Application.Current.MainPage.Navigation.PushAsync(paginaRecorridoAereo);

                Application.Current.MainPage.DisplayAlert("Area de recorridos", "En este apartado podra hacer un recorrido al auto", "Ok");

            });


        }

        public ObservableCollection<Aereo> listaAereo { get; set; } = new ObservableCollection<Aereo>();

        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MediosAereos.bin");

        Aereo AereoSeleccionado;
        public Aereo Aereoseleccionado
        {

            get => AereoSeleccionado;
            set
            {
                AereoSeleccionado = value;
                var args = new PropertyChangedEventArgs(nameof(Aereoseleccionado));
                PropertyChanged?.Invoke(this, args);
            }
        }

       

        public Command NavegarHacerRecorrido { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
