using System;
using System.Collections.Generic;
using System.Linq;
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


        public UInt64 genXi(UInt64 a, UInt64 p, Int64 x_n)
        {
            UInt64 xi;
            var XI=new XiG();
            xi = XI.Xi((Int64)a, (Int64)p, (UInt64)x_n);
            return xi;
        }

        public UInt64 genA(int numer)
        {
            return ap.retLP(numer);
        }

        public UInt64 genP(int numer)
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
