using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using POD_Blum_Micali_Generator.Model;
using POD_Blum_Micali_Generator.View;

namespace POD_Blum_Micali_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      BMG bmg=new BMG();
      RandBlumMicali blummicali = null;

        private string kluczString;

        public void genLP()
        {
            /*
            int n;
            OknoTextBox.Text = "Podaj liczbe: ";
            n = Convert.ToInt32(396);
            int iloscLP=0;
            bool[] tab = new bool[n + 1];
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
            OknoTextBox.Text ="Liczby pierwsze z zakresu [0," + n + "]: "+iloscLP+"   ";
            for (int i = 2; i <= n; i++)
            {
                if (tab[i] == false)
                {
                   klucz.Text= (i.ToString());
                    iloscLP++;
                }
            }
            OknoTextBox.Text = "Liczby pierwsze z zakresu [0," + n + "]: " + iloscLP + "   ";
            
             */
        }
  
        public MainWindow()
        {
            InitializeComponent();
/*
            //a few 20 digit safe primes to play with:
            var safePrime = BigInteger.Parse("45792590961032426879");
            var someValue = BigInteger.Parse("97484683765418940923");

            //a few 50 digit safe primes to play with:
            //var v1 = BigInteger.Parse("35707516168479785771797981373542410151981709510147");
            //var v2 = BigInteger.Parse("67900515765101717201431937816070398614160355475187");

            //a few 100 digit safe primes to play with:
            //var v1 = BigInteger.Parse("3089014570559104071319006923413060128665200110584708220833159771123973154612557115837845252375278767");
            //var v2 = BigInteger.Parse("9570534401487121496467970925158867173311659260360449216698291705369543311625846657862708743879011967");

            //calculate a primitive root
            var generator = PrimitiveRoots.GetPrimitiveRootOfSafePrime(safePrime);

            if (generator == 0) throw new Exception("Could not find a primitive root of this prime!  Try using a safe prime where P % 8 = 3 or 7.");

            //initialize the blum micali algorithm
            blummicali = new RandBlumMicali(someValue, safePrime, generator);
            var _intermed = BigInteger.ModPow(generator, someValue, safePrime);
            t1.Text = someValue.ToString();
            t2.Text = safePrime.ToString();
            t3.Text = generator.ToString();
            t4.Text = _intermed.ToString();
 */

        }

        private void generuj_Click(object sender, RoutedEventArgs e)  // Zapisz do pliku
        {
            Wczytaj wczyt = new Wczytaj();
            kluczString = wczyt.odczyt_zawartosci("klucz");
            var save = new Zapisz(kluczString);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var i = new BMGen();
            i.Show();
        }

        private void Automatycznie(object sender, RoutedEventArgs e)
        {
            var i = new BMAut();
            i.Show();
        }

        private void Minimalize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void PodgladKlucza(object sender, RoutedEventArgs e)
        {
            Wczytaj wczyt=new Wczytaj();
            kluczString = wczyt.odczyt_zawartosci("klucz");
            klucz.Text = wczyt.odczyt_zawartosci("klucz");
        }

        private void Autor(object sender, RoutedEventArgs e)
        {
            var i = new Autor();
            i.Show();
        }

        /* Teraz zbędne i wyłączone, ale jeśli kiedyś miało by sie przydać to proszę bardzo można odblokować
          
                 private void WczytajButton(object sender, RoutedEventArgs e)  // Wczytaj z pliku   
        {
            var wczyt = new Wczytaj();
            klucz.Text = wczyt.odczyt_zawartosci();
        }
          
          
          
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            //a few 20 digit safe primes to play with:
            var safePrime = BigInteger.Parse("45792590961032426879");
            var someValue = BigInteger.Parse("97484683765418940923");

            //a few 50 digit safe primes to play with:
            //var v1 = BigInteger.Parse("35707516168479785771797981373542410151981709510147");
            //var v2 = BigInteger.Parse("67900515765101717201431937816070398614160355475187");

            //a few 100 digit safe primes to play with:
            //var v1 = BigInteger.Parse("3089014570559104071319006923413060128665200110584708220833159771123973154612557115837845252375278767");
            //var v2 = BigInteger.Parse("9570534401487121496467970925158867173311659260360449216698291705369543311625846657862708743879011967");

            //calculate a primitive root
            var generator = PrimitiveRoots.GetPrimitiveRootOfSafePrime(safePrime);

            if (generator == 0) throw new Exception("Could not find a primitive root of this prime!  Try using a safe prime where P % 8 = 3 or 7.");

            blummicali = new RandBlumMicali(someValue, safePrime, generator);
            var _intermed = BigInteger.ModPow(generator, someValue, safePrime);   // tu  obliczamy x0 ale tylko by je pokazać w starcie tam
            t1.Text = someValue.ToString(); // x0
            t2.Text = safePrime.ToString(); // p
            t3.Text = generator.ToString(); // a



            //request a few bytes
            var btss = blummicali.GetNextRandomBit().ToString();
            var bts = blummicali.GetRandomBytes(20000).ToList();
            //show the bytes generated
           // klucz.Text = btss;
            klucz.Text = string.Join(",", bts.Select(s => s.ToString()).ToArray());
        }

        */
    }
}
