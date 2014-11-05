using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POD_Blum_Micali_Generator.Model
{
    // Generator liczby x0
    class X0G
    {
        public Random rnd = new Random();
       

        public int X0(int p)
        {
           return (rnd.Next(0, (p-1)));
        }
    }
}
