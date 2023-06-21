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
    public class ViewModelTerrestreHacerRecorrido : INotifyPropertyChanged
    {
        public ViewModelTerrestreHacerRecorrido() { }
        public ViewModelTerrestreHacerRecorrido(Terrestre T, ObservableCollection<Terrestre> ListaV)
        {
            listaTerrestre = ListaV;

            terrestreseleccionado = T;


            Recorrer = new Command(() => {


                terrestreseleccionado.KmsRecorrer = kmrTerrestre;
                terrestreseleccionado.CosumoCombustible();
                Application.Current.MainPage.DisplayAlert("Aviso", terrestreseleccionado.MostrarInfo(), "Ok");

                BinaryFormatter formateador = new BinaryFormatter();
                MemoryStream memoria = new MemoryStream();
                formateador.Serialize(memoria, listaTerrestre);
                byte[] datoSerializados = memoria.ToArray();
                memoria.Close();

                File.WriteAllBytes(ruta, datoSerializados);

                

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

        double KmRTerrestre;

        public double kmrTerrestre
        {

            get => KmRTerrestre;
            set
            {
                KmRTerrestre = value;
                var args = new PropertyChangedEventArgs(nameof(kmrTerrestre));
                PropertyChanged?.Invoke(this, args);
            }
        }



        
        public Command Recorrer { get; }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
