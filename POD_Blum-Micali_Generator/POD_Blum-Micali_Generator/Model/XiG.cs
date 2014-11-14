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
        public BigInteger Xi(BigInteger a, BigInteger p, BigInteger xi)
        {

            BigInteger xn;
            xn = (BigInteger.ModPow(a, xi, p));
            //xn = (((Int64)(Math.Pow(a, xi))) % p);
            return xn;
        }
    }
}
