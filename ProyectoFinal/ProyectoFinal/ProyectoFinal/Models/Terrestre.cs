using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.Models
{
    [Serializable]
    public class Terrestre : MedioDeTransporte
    {
        public short CantRuedas { get; set; }
        public string placa { get; set; }

        public double KmsRecorrer { get; set; }
        public double CombustibleG { get; set; }

        public Terrestre()
        {

        }
        public override void CosumoCombustible()
        {

            CombustibleG = KmsRecorrer * 0.89;
            kmR += KmsRecorrer;
            
        }

        public string MostrarInfo() {
            return "El combustible gastado es de: " + CombustibleG + " Y los kilometros recorridos fueron de " + KmsRecorrer
                  + "kms El nuevo Kilometraje del medio es de " + kmR +"Kmr";

        }

        public override string ToString()
        {
            return $"\n***Medios Terrestres***\n- Nombre Del Transporte: {NombreA} \n- Modelo: {ModeloA} \n- Año: {AñoL} \n- Color: {ColorA} " +
                $"\n- kilometros: {kmR} \n- Cantidad de ruedas: {CantRuedas} \n- Placa: {placa}";
        }
    }
}
