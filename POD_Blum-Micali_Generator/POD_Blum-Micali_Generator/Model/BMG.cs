using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace POD_Blum_Micali_Generator.Model
{
    class BMG
    {
        private LPG ap = new LPG();
        public Int64 genX0( UInt64 p)
        {
            X0G x0=new X0G();
            return x0.X0(p);
        }


        public BigInteger genXi(BigInteger a, BigInteger p, BigInteger x_n)
        {
            BigInteger xi;
            var XI=new XiG();
            xi = XI.Xi(a, p, x_n);
            return xi;
        }

        public BigInteger genA(BigInteger numer)
        {
            return ap.retLP(numer);
        }

        public BigInteger genP(BigInteger numer)
        {
            
            return ap.retLP(numer);
        }

        public void genLP()
        {
            ap.genLP(1000);
        }

        public int retIloscLP()
        {
            return ap.retIloscLP();
        }
        
    }
}
