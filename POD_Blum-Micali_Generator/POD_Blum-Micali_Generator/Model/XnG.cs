using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace POD_Blum_Micali_Generator.Model
{
    //Generator liczby Xi
    class XnG
    {
        private BigInteger xn = 0;
        public BigInteger Xn(int a, BigInteger x_n, int p)
        {
            xn=BigInteger.Pow(a, x_n);
            return xn = ((BigInteger)(Math.Pow(a, x_n)) % p);
            //return xn;
        }
    }
}
