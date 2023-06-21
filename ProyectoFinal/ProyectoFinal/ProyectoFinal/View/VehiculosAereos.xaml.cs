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
	public partial class VehiculosAereos : ContentPage
	{
		public VehiculosAereos ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            this.BindingContext = new ViewModels.ViewModelMostrarVehiculoAereo();

            // Actualiza los datos necesarios aquí
        }

    }
}