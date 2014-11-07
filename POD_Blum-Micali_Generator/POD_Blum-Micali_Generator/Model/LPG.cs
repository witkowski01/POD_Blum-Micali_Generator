using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POD_Blum_Micali_Generator.Model
{
    class LPG
    {

        int ii = 0;
        Int64[] tab2 = new long[1000];

       

        //Funkcja zwracająca liczby pierwsze
        public void genLP (Int64 max)
        {
            Int64 n = 0;

          //  klucz.Text = "Podaj liczbe: ";
            n = max;
            //n = Convert.ToInt32(max);
            bool[] tab = new bool[n+1];
            for (int i = 2; i * i <= n; i++)
            {
                if (tab[i] == true)
                {
                    continue;
                }
                for (int j = 2 * i; j <= n; j += i)
                {
                    tab[j] = true;
                }
            }
           // Console.WriteLine("Liczby pierwsze z zakresu [0," + n + "]: ");

            for (int i = 2; i <= n; i++)
            {
                if (tab[i] == false)
                {
                    tab2[ii] = i;
                    ii++;
                }
            }
      
        }


        int retIloscLP()
        {
            return ii;
        }
        Int64 retLP(int numer)
        {
            return tab2[numer];
        }
    }


}
