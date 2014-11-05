using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POD_Blum_Micali_Generator.Model
{
    class LPG
    {

        private int lp;

        //Funkcja zwracająca liczby pierwsze
        public int LPgen(int max)
        {
            int n = 0;

          //  klucz.Text = "Podaj liczbe: ";
            n = Convert.ToInt32(max);
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
                    lp=i;
                }
            }
            return lp;
        }
    }
}
