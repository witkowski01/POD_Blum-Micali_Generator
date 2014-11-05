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
        private int a = 0, p = 0, x0 = 0, xn = 0, s1 = 0;
        LPG Lp = new LPG();
        X0G Xo=new X0G();
        XnG Xn=new XnG();
        SiG Si=new SiG();

        public int genX0()
        {
            return x0;
        }

        public void genBMG()
        {
            p = Lp.LPgen(4000);
            a = Lp.LPgen(1350);
            x0 = Xo.X0(p);
            
        }

        public BMG()
        {
            genBMG();

        }

        public int genBM(int x_n)
        {
            
            xn = Xn.Xn(a, x_n, p);

            s1 = Si.Sig(xn, p);

            return xn;
        }

        public int rS1()
        {
            return s1;
        }
    }
}
