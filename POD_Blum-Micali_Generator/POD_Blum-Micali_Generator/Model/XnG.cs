using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POD_Blum_Micali_Generator.Model
{
    //Generator liczby Xi
    class XnG
    {
        private int xn = 0;
        public int Xn(int a, int x_n,int p)
        {
            return xn=((int)(Math.Pow(a,x_n)) % p);
            //return xn;
        }
    }
}
