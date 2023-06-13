using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal.Models
{
    [Serializable]
    public class MedioDeTransporte
    {
        List<string> Tripulantes = new List<string>();
        public string NombreA { get; set; }
        public string ModeloA { get; set; }
        public short AñoL { get; set; }
        public string ColorA { get; set; }

        public double kmR {get; set; }

        //metodo//
        public virtual void CosumoCombustible()
        {

        }

        public virtual string ToString()
        {
            return $"\n- Nombre Del Transporte: {NombreA} \n- Modelo: {ModeloA} \n- Año: {AñoL} \n- Color: {ColorA} " +
                $"\n- kilometros: {kmR}";
        }
    }
}
