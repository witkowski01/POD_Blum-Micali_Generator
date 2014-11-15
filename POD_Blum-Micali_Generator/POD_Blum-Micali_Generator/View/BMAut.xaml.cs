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
using System.Windows.Shapes;
using System.Xml.Linq;
using POD_Blum_Micali_Generator.Model;


namespace POD_Blum_Micali_Generator.View
{
    /// <summary>
    /// Interaction logic for BMAut.xaml
    /// </summary>
    public partial class BMAut : Window
    {
        private RandBlumMicali blummicali = null;
        public BMAut()
        {
            InitializeComponent();
            
        }
        private BMG bmg = new BMG();
        private SiG si = new SiG();

        private void GenerujAut(object sender, RoutedEventArgs e)
        {
            BigInteger a, p, xi;
            BigInteger x0;
            StreamWriter SW,SW01;
            BigInteger[] tab01 = new BigInteger[20005];
            var i01 = 0;
         
            UInt64 sn;

            //SW01 = File.AppendText("klucz2.txt");
            //SW01.Close();

            UInt64 numerP, numerA;
            StanTextBox.Text = "Pracuję";
            numerP = (UInt64)Convert.ToInt32(PTextBox.Text);
            //numerA = (UInt64)Convert.ToInt32(ATextBox.Text);
            GenerujLP();
            p = BigInteger.Parse(PTextBox.Text);
           // p = numerP;
            //p = bmg.genP(numerP);
           // a = bmg.genA(numerA);
            x0 = bmg.genX0(numerP);

            
            //a few 20 digit safe primes to play with:
            var safePrime = BigInteger.Parse("45792590961032426879") + (p*8) ;
            var someValue = BigInteger.Parse("97484683765418940923") + x0;


            var generator = PrimitiveRoots.GetPrimitiveRootOfSafePrime(safePrime);

            if (generator == 0) throw new Exception("Could not find a primitive root of this prime!  Try using a safe prime where P % 8 = 3 or 7.");

            blummicali = new RandBlumMicali(someValue, safePrime, generator);
            //var _intermed = BigInteger.ModPow(generator, someValue, safePrime);   // tu  obliczamy x1 ale tylko by je pokazać w starcie tam
            t1.Text = someValue.ToString(); // x0
            t2.Text = safePrime.ToString(); // p
            t3.Text = generator.ToString(); // a


            string btss;

            btss = blummicali.GetNextRandomBit().ToString();
            SW = File.CreateText("klucz");
            //SW = File.AppendText("klucz");
            SW.Write(btss);
            SW.Close();

            for (int i = 0; i < 19998; i++)
            {
                btss = blummicali.GetNextRandomBit().ToString();
                SW = File.AppendText("klucz");
                SW.Write(btss);
                SW.Close();
            }
            Wczytaj wczytaj=new Wczytaj();

            klucz.Text = wczytaj.odczyt_zawartosci("klucz");


            ///////////////////////////////////////////////////////////////////////////
            /// ////////////////////////////////////////////////////////////////////////


            // Artefakt którego nie używam już bo nie jest taki jak bym chciał
            /*
            sn=(ulong) si.Si((UInt64)x0, p);
            SW = File.CreateText("klucz");
           // SW = File.AppendText("klucz");
            SW.Write(sn.ToString());
            tab01[i01] = sn;
            i01++;
            SW.Close();

            xi=  bmg.genXi(a, p, (Int64)x0);
            sn = (ulong) si.Si(xi, p);
            tab01[i01] = sn;
            i01++;
            SW = File.AppendText("klucz");
            SW.Write(sn.ToString());
            SW.Close();

            for (int i = 0; i < 20000; i++)
            {
                xi = bmg.genXi(a, p, (Int64)xi);
                sn = (ulong) si.Si(xi, p);
                tab01[i01] = sn;
                i01++;
                SW = File.AppendText("klucz");
                SW.Write(sn.ToString());
                SW.Close();
            }
           // GenerujHex(tab01,SW01);

            */
            StanTextBox.Text = "Koniec";

        }

        private void btnGenerate(BigInteger p, BigInteger x0)
        {

            //a few 20 digit safe primes to play with:
            var safePrime = BigInteger.Parse("45792590961032426879" + p);
            var someValue = BigInteger.Parse("97484683765418940923" + x0);


            var generator = PrimitiveRoots.GetPrimitiveRootOfSafePrime(safePrime);

            if (generator == 0) throw new Exception("Could not find a primitive root of this prime!  Try using a safe prime where P % 8 = 3 or 7.");

            blummicali = new RandBlumMicali(someValue, safePrime, generator);
            var _intermed = BigInteger.ModPow(generator, someValue, safePrime);   // tu  obliczamy x0 ale tylko by je pokazać w starcie tam
            t1.Text = someValue.ToString(); // x0
            t2.Text = safePrime.ToString(); // p
            t3.Text = generator.ToString(); // a


            string btss=null;

            for (int i = 0; i < 20000; i++)
            {
                btss = blummicali.GetNextRandomBit().ToString();
            }
            var bts = blummicali.GetRandomBytes(20000).ToList();
            //show the bytes generated
            klucz.Text = btss.ToString();
            //klucz.Text = string.Join(",", bts.Select(s => s.ToString()).ToArray());

        }

        private void GenerujLP()
        {
            bmg.genLP();
            IlośćLpTextBox.Text= (bmg.retIloscLP()).ToString();
        }

        private void GenerujHex(UInt64[] tab, StreamWriter SW01)
        {
            int j = 0;
            UInt64[][] tab1 = new UInt64[5001][];
            for (int i = 0; i < 5000; i++)
            {
                for (int k = 0; k < 4; k++)
                {
                    tab1[i][k] = tab[i + k];
                }
                SW01 = File.AppendText("klucz2.txt");
                SW01.WriteLine(tab1[i][1].ToString());
                SW01.Close();
            }
        }

        private void Minimalize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
