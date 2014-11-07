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
            StreamWriter SW;

            UInt64 sn;

            UInt64 numerP, numerA;
            StanTextBox.Text = "Pracuję";
            numerP = (UInt64)Convert.ToInt32(PTextBox.Text);
            numerA = (UInt64)Convert.ToInt32(ATextBox.Text);

            p = bmg.genP((int)numerP);
            a = bmg.genA((int) numerA);
            x0 = bmg.genX0(numerP);

            sn=(ulong) si.Si((UInt64)x0, p);
            SW = File.AppendText("klucz.txt");
            SW.WriteLine(sn.ToString());
            SW.Close();

            xi=  bmg.genXi(a, p, (Int64)x0);
            sn = (ulong) si.Si(xi, p);

            SW = File.AppendText("klucz.txt");
            SW.WriteLine(sn.ToString());
            SW.Close();

            for (int i = 0; i < 20000; i++)
            {
                xi = bmg.genXi(a, p, (Int64)xi);
                sn = (ulong) si.Si(xi, p);

                SW = File.AppendText("klucz.txt");
                SW.WriteLine(sn.ToString());
                SW.Close();
            }
            StanTextBox.Text = "Koniec";

        }

        private void GenerujLP(object sender, RoutedEventArgs e)
        {
            bmg.genLP();
            IlośćLpTextBox.Text= (bmg.retIloscLP()).ToString();
        }
    }
}
