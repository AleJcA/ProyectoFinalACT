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
    public class ViewModelMostrarVehiculoTerre : INotifyPropertyChanged
    {

        public ViewModelMostrarVehiculoTerre() {

            try
            {

                byte[] data = File.ReadAllBytes(ruta);
                MemoryStream memory = new MemoryStream(data);
                BinaryFormatter formater = new BinaryFormatter();
                listaTerrestre = (ObservableCollection<Terrestre>)formater.Deserialize(memory);
                memory.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Sin archivo por cargar de Medios de Transporte");

            }

            NavegarHacerRecorrido = new Command(() => {

                var paginaRecorridoTerrestre = new HacerRecorridoTerrestre();
                var viewModel = new ViewModelTerrestreHacerRecorrido(terrestreseleccionado, listaTerrestre);
                paginaRecorridoTerrestre.BindingContext = viewModel;
                Application.Current.MainPage.Navigation.PushAsync(paginaRecorridoTerrestre);

                Application.Current.MainPage.DisplayAlert("Area de recorridos", "En este apartado podra hacer un recorrido al auto", "Ok");

            });

        }

        public ObservableCollection<Terrestre> listaTerrestre { get; set; } = new ObservableCollection<Terrestre>();
        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MediosTerrestres.bin");

        Terrestre TerrestreSeleccionado;
        public Terrestre terrestreseleccionado
        {

            get => TerrestreSeleccionado;
            set
            {
                TerrestreSeleccionado = value;
                var args = new PropertyChangedEventArgs(nameof(terrestreseleccionado));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command NavegarHacerRecorrido { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
