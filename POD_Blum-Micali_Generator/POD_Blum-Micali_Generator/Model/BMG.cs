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

        public Int64 genX0( UInt64 p)
        {
            X0G x0=new X0G();
            return x0.X0(p);
        }


        public long genBM(long x_n)
        {
            

        }

        public int rS1()
        {
            return s1;
        }
    }
}
