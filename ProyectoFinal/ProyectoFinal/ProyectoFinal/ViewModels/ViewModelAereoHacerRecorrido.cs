using ProyectoFinal.Models;
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
    public class ViewModelAereoHacerRecorrido : INotifyPropertyChanged
    {

        public ViewModelAereoHacerRecorrido() { }

        public ViewModelAereoHacerRecorrido(Aereo A, ObservableCollection<Aereo> listaA) {


            listaAereo = listaA;

            Aereoseleccionado = A;

            Recorrer = new Command(() => {


                Aereoseleccionado.KmsRecorrer = kmrAereo;
                Aereoseleccionado.CosumoCombustible();
                Application.Current.MainPage.DisplayAlert("Aviso", Aereoseleccionado.MostrarInfo(), "Ok");

                BinaryFormatter formateador = new BinaryFormatter();
                MemoryStream memoria = new MemoryStream();
                formateador.Serialize(memoria, listaAereo);
                byte[] datoSerializados = memoria.ToArray();
                memoria.Close();

                File.WriteAllBytes(ruta, datoSerializados);

                


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

        double KmRAereo;

        public double kmrAereo
        {

            get => KmRAereo;
            set
            {
                KmRAereo = value;
                var args = new PropertyChangedEventArgs(nameof(kmrAereo));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command Recorrer { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
