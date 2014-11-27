﻿///<Author> Konrad Witkowski 14-11-2014</Author>


using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace POD_Blum_Micali_Generator
{
    public class PrimitiveRoots
    {
        /// <summary>
        /// Finds a primitive root of the specified safe prime (with residues of 3 or 7 mod 8)
        /// </summary>
        /// <param name="primegroup"></param>
        /// <returns>primitive root or 0 if one couldn't be found</returns>
        public static BigInteger GetPrimitiveRootOfSafePrime(BigInteger safePrime)
        {
            //safe primes are either (+2 or -2) % safePrime
            var md = safePrime % 8;

            if (md == 3) return 2;
            if (md == 7) return safePrime - 2;

            return 0;  //we just don't know what it is
        }
    }
}
