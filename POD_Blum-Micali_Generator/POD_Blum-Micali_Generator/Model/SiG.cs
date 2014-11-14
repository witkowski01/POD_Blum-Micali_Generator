﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace POD_Blum_Micali_Generator.Model
{
    //Generator 0 1
    class SiG
    {
        public int Si(BigInteger xn, BigInteger p)
        {
            if (xn > ((p - 1) / 2))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
