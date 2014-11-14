using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace POD_Blum_Micali_Generator.Model
{
    class LPG
    {

       private int ii = 0;
       private BigInteger[] tab2 = new BigInteger[1000];

       

        //Funkcja zwracająca liczby pierwsze
        public void genLP (UInt64 max)
        {
            UInt64 n = 0;

          //  klucz.Text = "Podaj liczbe: ";
            n = max;
            //n = Convert.ToInt32(max);
            bool[] tab = new bool[n+1];
            for (UInt64 i = 2; i * i <= n; i++)
            {
                if (tab[i] == true)
                {
                    continue;
                }
                for (UInt64 j = 2 * i; j <= n; j += i)
                {
                    tab[j] = true;
                }
            }
           // Console.WriteLine("Liczby pierwsze z zakresu [0," + n + "]: ");

            for (UInt64 i = 2; i <= n; i++)
            {
                if (tab[i] == false)
                {
                    tab2[ii] = i;
                    ii++;
                }
            }
      
        }


       public int retIloscLP()
        {
            return ii;
        }
       public BigInteger retLP(BigInteger numer)
        {
            return tab2[(UInt64)numer];
        }
    }


}
