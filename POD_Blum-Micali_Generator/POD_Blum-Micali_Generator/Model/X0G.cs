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
       

        public Int64 X0(UInt64 p)
        {
            int minValue = 0;
            UInt64 maxValue = p - 1;
            return (rnd.Next(minValue, (int) maxValue));
        }
    }
}
