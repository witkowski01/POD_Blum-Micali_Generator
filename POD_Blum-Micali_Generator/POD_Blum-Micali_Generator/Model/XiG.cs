using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace POD_Blum_Micali_Generator.Model
{
    //Generator liczby Xi
    class XiG
    {
        public UInt64 Xi(Int64 a, Int64 p, UInt64 xi)
        {
            Int64 xn;
            xn = (((Int64)(Math.Pow(a, xi))) % p);
            return (UInt64)xn;
        }
    }
}
