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
    public class ViewModelTerrestre : INotifyPropertyChanged
    {

        public ViewModelTerrestre()
        {
            Terrestre medioTerrestre = new Terrestre();

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

            crearTerrestre = new Command(() => {

                medioTerrestre = new Terrestre()
                {
                    NombreA = this.nombreTerrestre,
                    ModeloA = this.modeloTerrestre,
                    AñoL = this.AñoLTerrestre,
                    ColorA = this.ColorTerrestre,
                    CantRuedas = this.CantidadRTerrestre,
                    placa = this.PlacaTerrestre,
                    
                    
                    



                };

                listaTerrestre.Add(medioTerrestre);

                Application.Current.MainPage.DisplayAlert("Aviso", "Vehiculo Terrestre Creado", "Ok");

                BinaryFormatter formateador = new BinaryFormatter();
                MemoryStream memoria = new MemoryStream();
                formateador.Serialize(memoria, listaTerrestre);
                byte[] datoSerializados = memoria.ToArray();
                memoria.Close();

                File.WriteAllBytes(ruta, datoSerializados);

                nombreterrestre = String.Empty;
                modeloterrestre = String.Empty;
                añolterrestre = 0;
                colorterrestre = String.Empty;
                cantidadrterrestre = 0;
                placaterrestre = String.Empty;


                Application.Current.MainPage.Navigation.PopAsync();

            });

            NavegarHacerRecorrido = new Command(()=>{

                var paginaRecorridoTerrestre = new HacerRecorridoTerrestre();
                Application.Current.MainPage.Navigation.PushAsync(paginaRecorridoTerrestre);

                Application.Current.MainPage.DisplayAlert("Area de recorridos", "En este apartado podra hacer un recorrido al auto", "Ok");

            });

            Recorrer = new Command(() => {


                medioTerrestre.KmsRecorrer = KmRTerrestre;
                medioTerrestre.CosumoCombustible();
                Application.Current.MainPage.DisplayAlert("Aviso", medioTerrestre.MostrarInfo(), "Ok");
            
            
            });

            
            

        }

        public ObservableCollection<Terrestre> listaTerrestre { get; set; } = new ObservableCollection<Terrestre>();

        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "MediosTerrestres.bin");

        string nombreTerrestre;

        public string nombreterrestre
        {

            get => nombreTerrestre;
            set
            {
                nombreTerrestre = value;
                var args = new PropertyChangedEventArgs(nameof(nombreterrestre));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string modeloTerrestre;

        public string modeloterrestre
        {

            get => modeloTerrestre;
            set
            {
                modeloTerrestre = value;
                var args = new PropertyChangedEventArgs(nameof(modeloterrestre));
                PropertyChanged?.Invoke(this, args);
            }
        }

        short AñoLTerrestre;

        public short añolterrestre
        {

            get => AñoLTerrestre;
            set
            {
                AñoLTerrestre = value;
                var args = new PropertyChangedEventArgs(nameof(añolterrestre));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string ColorTerrestre;

        public string colorterrestre
        {

            get => ColorTerrestre;
            set
            {
                ColorTerrestre = value;
                var args = new PropertyChangedEventArgs(nameof(colorterrestre));
                PropertyChanged?.Invoke(this, args);
            }
        }

        short CantidadRTerrestre;

        public short cantidadrterrestre
        {

            get => CantidadRTerrestre;
            set
            {
                CantidadRTerrestre = value;
                var args = new PropertyChangedEventArgs(nameof(cantidadrterrestre));
                PropertyChanged?.Invoke(this, args);
            }
        }

        string PlacaTerrestre;

        public string placaterrestre
        {

            get => PlacaTerrestre;
            set
            {
                PlacaTerrestre = value;
                var args = new PropertyChangedEventArgs(nameof(placaterrestre));
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


        public Command crearTerrestre { get; }
        public Command NavegarHacerRecorrido { get; }
        public Command Recorrer { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
