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
using POD_Blum_Micali_Generator.Model;


namespace POD_Blum_Micali_Generator.View
{
    /// <summary>
    /// Interaction logic for BMGen.xaml
    /// </summary>
    public partial class BMGen : Window
    {
        private RandBlumMicali blummicali = null;
        public BMGen()
        {
            InitializeComponent();
        }

        private void Generuj(object sender, RoutedEventArgs e)
        {
            string a, p, x0, xi;
            StreamWriter SW,SW01;
            BMG bmg = new BMG();
            SiG si = new SiG();
            UInt64 sn;
            BigInteger[] tab01 = new BigInteger[20005];
            var i01 = 0;

            //BigInteger bi = new BigInteger(Encoding.UTF8.GetBytes(ATextBox.Text));
/*
            a = new BigInteger(Encoding.UTF8.GetBytes(ATextBox.Text));
            p = new BigInteger(Encoding.UTF8.GetBytes(PTextBox.Text));
            x0 = new BigInteger(Encoding.UTF8.GetBytes(X0TextBox.Text)); 
*/
            a = ATextBox.Text;
            p = PTextBox.Text;
            x0 = X0TextBox.Text;
            // Nie wiem czemu ale to się nie wyświetla
            StanTextBox.Text = "Pracuję sobie";




            //a few 20 digit safe primes to play with:
            var safePrime = BigInteger.Parse(p);
            var someValue = BigInteger.Parse(x0);


            var generator = BigInteger.Parse(a);

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
            Wczytaj wczytaj = new Wczytaj();

            klucz.Text = wczytaj.odczyt_zawartosci("klucz");





            /*  artefakt już

            sn=(ulong) si.Si(x0, p);
            SW = File.CreateText("klucz");  // Chcemy tworzyć przy każdym obiegu inny plik/nadpisywać poprzedni
            //SW = File.AppendText("klucz");
            SW.Write(sn.ToString());
            tab01[i01] = sn;
            i01++;
            SW.Close();

            //bmg.genX0(p);
            xi=  bmg.genXi(a, p, x0);
            sn = (ulong) si.Si(xi, p);

            SW = File.AppendText("klucz");
            SW.Write(sn.ToString());
            tab01[i01] = sn;
            i01++;
            SW.Close();

            for (int i = 0; i < 20000; i++)
            {
                xi = bmg.genXi(a, p, xi);
                sn = (ulong) si.Si(xi, p);
                tab01[i01] = sn;
                i01++;
                SW = File.AppendText("klucz");
                SW.Write(sn.ToString());
                SW.Close();
            }
            /*
            SW01 = File.AppendText("klucz2.txt");
            SW01.WriteLine(tab01.GetValue(20000));
            SW01.Close();  
             */
            
            StanTextBox.Text = "Koniec";

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
