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
        public BMGen()
        {
            InitializeComponent();
        }

        private void Generuj(object sender, RoutedEventArgs e)
        {
            BigInteger a, p, x0, xi;
            StreamWriter SW,SW01;
            BMG bmg = new BMG();
            SiG si = new SiG();
            UInt64 sn;
            BigInteger[] tab01 = new BigInteger[20005];
            var i01 = 0;
         
            a = Convert.ToUInt64(ATextBox.Text);
            p = Convert.ToUInt64(PTextBox.Text);
            x0 = Convert.ToUInt64(X0TextBox.Text);

            // Nie wiem czemu ale to się nie wyświetla
            StanTextBox.Text = "Pracuję sobie";



            sn=(ulong) si.Si(x0, p);
            SW = File.AppendText("klucz");
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
                xi = bmg.genXi(a, p, (Int64)xi);
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
