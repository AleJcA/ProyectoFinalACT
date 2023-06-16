using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VehiculosTerrestres : ContentPage
	{
		public VehiculosTerrestres ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            this.BindingContext = new ViewModels.ViewModelMostrarVehiculoTerre();

            // Actualiza los datos necesarios aquí
        }
    }
}