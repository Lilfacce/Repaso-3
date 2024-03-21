using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_3
{
    internal class Propiedades
    {
        int numeroCasa;
        int dpi;
        decimal cuota;

        public int NumeroCasa { get => numeroCasa; set => numeroCasa = value; }
        public int Dpi { get => dpi; set => dpi = value; }
        public decimal Cuota { get => cuota; set => cuota = value; }
    }
}
