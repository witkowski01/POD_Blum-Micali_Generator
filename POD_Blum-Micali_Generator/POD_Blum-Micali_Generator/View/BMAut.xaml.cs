using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public BMAut()
        {
            InitializeComponent();
            
        }
        private BMG bmg = new BMG();
        private SiG si = new SiG();

        private void GenerujAut(object sender, RoutedEventArgs e)
        {
            UInt64 a, p, xi;
            Int64 x0;
            StreamWriter SW,SW01;
            UInt64[] tab01 = new UInt64[20005];
            var i01 = 0;
         
            UInt64 sn;

            //SW01 = File.AppendText("klucz2.txt");
            //SW01.Close();

            UInt64 numerP, numerA;
            StanTextBox.Text = "Pracuję";
            numerP = (UInt64)Convert.ToInt32(PTextBox.Text);
            numerA = (UInt64)Convert.ToInt32(ATextBox.Text);

            p = bmg.genP((int)numerP);
            a = bmg.genA((int) numerA);
            x0 = bmg.genX0(numerP);

            sn=(ulong) si.Si((UInt64)x0, p);
            SW = File.AppendText("klucz");
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
            StanTextBox.Text = "Koniec";

        }

        private void GenerujLP(object sender, RoutedEventArgs e)
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
