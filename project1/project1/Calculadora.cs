using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Calculadora
    {
        public float Numero1 { get; set; }
        public float Numero2 { get; set; }

        public Calculadora(float n1, float n2)
        {
            Numero1 = n1;
            Numero2 = n2;
        }
        
        public float Soma()
        {
            return Numero1 + Numero2;
        }
    }
}
