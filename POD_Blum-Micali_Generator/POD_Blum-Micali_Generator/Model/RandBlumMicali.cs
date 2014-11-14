﻿///<Author>David Joseph Conner, 9-22-2014</Author>
///<Modifier> Konrad Witkowski 14-11-2014</Modifier>
///<Comment>
///This code is provided to you as-is.  The
///only thing that I ask is that you place my
///name as the original author of this code
///in the header of the class file containing 
///the code.
///</Comment>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using POD_Blum_Micali_Generator.View;

namespace POD_Blum_Micali_Generator
{
    public class RandBlumMicali
    {
        BigInteger _seed, _safePrime, _primitiveRoot;
        BigInteger _intermed;

        /// <summary>
        /// Seeds the Blum Micali CSPRNG
        /// </summary>
        /// <param name="seed">any value</param>
        /// <param name="safePrime">a safe prime</param>
        /// <param name="primitiveRoot">root to use as a generator of the cyclic group</param>
        public RandBlumMicali(BigInteger seed, BigInteger safePrime, BigInteger primitiveRoot)
        {
            _seed = seed;
            _safePrime = safePrime;
            _primitiveRoot = primitiveRoot;
            _intermed = BigInteger.ModPow(_primitiveRoot, _seed, _safePrime);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>random 0 or 1</returns>
        public byte GetNextRandomBit()
        {
            _intermed = BigInteger.ModPow(_primitiveRoot, _intermed, _safePrime);
            if (_intermed < ((_safePrime - 1) / 2)) return 1;
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>random byte 0 thru 255</returns>
        public byte GetNextRandomByte()
        {
            var xx = 0;
            byte res = 0;
            while (xx < 8)
            {
                var b = GetNextRandomBit();
                res += (byte)(b * Math.Pow(2, xx));
                xx++;
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">number requested</param>
        /// <returns>random number of bytes requested</returns>
        public byte[] GetRandomBytes(int num)
        {
            var res = new List<byte>();
            while (res.Count < num) res.Add(GetNextRandomByte());
            return res.ToArray();
        }
    }
}
