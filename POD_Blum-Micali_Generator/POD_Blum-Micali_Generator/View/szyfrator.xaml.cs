using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace POD_Blum_Micali_Generator.View
{
    /// <summary>
    /// Interaction logic for szyfrator.xaml
    /// </summary>
    public partial class szyfrator : Window
    {
        public szyfrator()
        {
            InitializeComponent();
        }
        const int bits = 16;
        string in_s, gen_s, out_s;
        bool[] in_b, out_b;
        bool krok1, krok2, krok3;
        
        private void krokowyClick(object sender, RoutedEventArgs e)
        {
            krok1 = true;
            krok2 = true;
            krok3 = true;
        }

        private void Szyfruj(object sender, RoutedEventArgs e)
        {
            try
            {
                in_s = System.IO.File.ReadAllText(ZamienPola.IsChecked == false? wej.Text:wyj.Text, Encoding.UTF8);
                gen_s = System.IO.File.ReadAllText(klucz.Text);
                out_s = "";
                in_b = new bool[in_s.Length * bits];
                out_b = new bool[in_b.Length];


                for(int i = 0; i< in_s.Length; i++)
                {
                    in_b = getBool(in_s[i], i, in_b);       //Zamiana char na bool[]
                }


                xor();                                      //Xorowanie bool[] klucza i pliku wejściowego

                for (int i = 0; i < in_s.Length; i++)
                {
                    out_s += getChar(out_b, i);             //Zamiana bool[] na char
                }

                System.IO.File.WriteAllText(ZamienPola.IsChecked == false ? wyj.Text : wej.Text, out_s);
                Krokowy.IsChecked = false;
                MessageBox.Show("Gotowe!\nZakodowana wiadomość:\n" + out_s, "Kodowanie wykonane bardzo dobrze",
                    MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            catch (Exception err)
            {
                MessageBox.Show("Błąd:\n" + err, "Błąd krytyczny", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool[] getBool(char znak, int k, bool[] tablica)
        {
            int nr = Convert.ToInt32(znak);
            for (int i = 0; i < bits; i++)
            {
                if (nr >= Math.Pow(2, (bits -1) - i))
                {
                    tablica[i + bits*k] = true;
                    nr = nr - (int)Math.Pow(2, (bits - 1) - i);
                }
                else
                {
                    tablica[i + bits * k] = false;
                }
            }

            return tablica;
        }
        private void xor()
        {
            int j = 0;

            foreach (bool element in in_b)              
            {
                if (gen_s.Length < j)
                {
                    MessageBox.Show("Za długi tekst\nZa krótki wygenerowany ciąg", "Błąd krytyczny", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                }
                if ((in_b[j] == false && gen_s[j] == '0') || (in_b[j] == true && gen_s[j] == '1'))
                {
                    out_b[j] = false;
                }
                else
                {
                    out_b[j] = true;
                }

                j++;
            }  
        }
        private string getChar(bool[] tablica, int k){
            int znak = 0;
            for (int i = 0; i < bits; i++)
            {
                if (tablica[i + k*bits])
                {
                    znak += (int)Math.Pow(2, (bits - 1) - i);
                }
            }

            return Convert.ToChar(znak).ToString();
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
    
