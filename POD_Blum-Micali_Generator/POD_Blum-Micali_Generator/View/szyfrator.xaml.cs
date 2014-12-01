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
                ///
                if (Krokowy.IsChecked == true)
                {
                    MessageBoxResult wynik = MessageBox.Show("Tryb prezentacji krokowej"  + "\n\nTekst przed procesem:\n" + in_s, "Tryb prezentacji krokowej");
                    if (wynik == MessageBoxResult.Cancel) Krokowy.IsChecked = false;
                }
                ///

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
                MessageBox.Show("Gotowe!\nZakodowana wiadomość:\n" + out_s ,"Kodowanie zakończone",
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
            ///
            if (Krokowy.IsChecked == true && krok1 == true)
            {
                string mess = "Rozkład znaku nr: " + (k + 1) + "\nZnak wejściowy: " + znak + "\nNumer znaku w UTF: " +
                    Convert.ToInt32(znak) + "\n\nWyjściowy kod binarny:\n";
                for (int j = 0; j < bits; j++)
                {
                    if (bits - j < 10)
                        mess += 0;
                    mess += bits - j + " ";
                }
                mess += "    Potęgi 2\n ";
                for (int i = 0; i < bits; i++)
                {
                    mess += tablica[bits * k + i] ? "1" : "0";
                    mess += "   ";
                }
                mess += "\n\nNastępny znak?";
                wynik = MessageBox.Show(mess, "Tryb prezentacji krokowej", MessageBoxButton.YesNoCancel, 
                    MessageBoxImage.Information);

                if (wynik == MessageBoxResult.Cancel) Krokowy.IsChecked = false;
                if (wynik == MessageBoxResult.No) krok1 = false;
            }
            ///
            return tablica;
        }

        private MessageBoxResult wynik;
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
                ///
                if (Krokowy.IsChecked == true && krok2 == true)
                {
                    string mess = "Numer bitu: "+ (j+1) +"\nXORowanie tekstu z wygenerowanym ciagiem\n\nBit tekstu: ";
                    mess += in_b[j] ? "1" : "0";
                    mess += "\nBit z generatora: " + gen_s[j] + "\nBit wynikowy: ";
                    mess += out_b[j] ? "1" : "0";
                    wynik = MessageBox.Show(mess, "Tryb prezentacji krokowej", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);
                    if (wynik == MessageBoxResult.Cancel) Krokowy.IsChecked = false;
                    if (wynik == MessageBoxResult.No) krok2 = false;
                }
                ///
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
            ///
            if (Krokowy.IsChecked == true && krok3 == true)
            {
                string mess = "Składanie znaku nr: " + (k + 1) + "\nBity wejściowe:\n";
                for (int j = 0; j < bits; j++)
                {
                    if (bits - j < 10)
                        mess += 0;
                    mess += bits - j + " ";
                }
                mess += "    Potęgi 2\n ";
                for (int j = 0; j < bits; j++)
                {
                    mess += tablica[bits * k + j] ? "1" : "0";
                    mess += "   ";
                }
                mess += "\nNumer znaku w UTF: " + (int)znak + "\nZnak wyjściowy: " + Convert.ToChar(znak).ToString() + "\n\nNastępny znak?";
                wynik = MessageBox.Show(mess, "Tryb prezentacji krokowej", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);
                if (wynik == MessageBoxResult.Cancel) Krokowy.IsChecked = false;
                if (wynik == MessageBoxResult.No) krok3 = false;
            }
            ///
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
    
