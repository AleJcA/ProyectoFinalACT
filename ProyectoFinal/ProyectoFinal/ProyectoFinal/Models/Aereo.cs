using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.Models
{
    [Serializable]
    public class Aereo : MedioDeTransporte
    {
        public short CantHelices { get; set; }
        public short CantAlas { get; set; }
        public double KmsRecorrer { get; set; }
        public double CombustibleG { get; set; }

        public Aereo()
        {

        }
        public override void CosumoCombustible()
        {
            CombustibleG = KmsRecorrer * 1.54;
            kmR += KmsRecorrer;
            
        }

        public string MostrarInfo()
        {
            return "El combustible gastado es de: " + CombustibleG + " Y los kilometros recorridos fueron de " + KmsRecorrer
                + "kms El nuevo Kilometraje del medio es de " + kmR +"Kmr";
        }

        public override string ToString()
        {
            return $"\n***Medios Aereos***\n- Nombre Del Transporte: {NombreA} \n- Modelo: {ModeloA} \n- Año: {AñoL} \n- Color: {ColorA} " +
                $"\n- kilometros: {kmR} \n- Cantidad de Helices: {CantHelices} \n- Cantidad de Alas: {CantAlas}";
        }
    }
}
