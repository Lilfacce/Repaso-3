using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso_3
{
    internal class Reporte
    {
        string name;
        string second_name;
        int casa;
        decimal cuotaMan;

        public string Name { get => name; set => name = value; }
        public string Second_name { get => second_name; set => second_name = value; }
        public int Casa { get => casa; set => casa = value; }
        public decimal CuotaMan { get => cuotaMan; set => cuotaMan = value; }
    }
}
