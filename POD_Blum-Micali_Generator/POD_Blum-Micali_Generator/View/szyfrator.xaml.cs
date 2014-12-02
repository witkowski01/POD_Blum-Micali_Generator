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
using POD_Blum_Micali_Generator.Model;


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

        private string wej_string, klucz_string, wyj_string;
        private bool[] wej_bool, wyj_bool;
        private const int bity = 16;
       
        private void Szyfruj(object sender, RoutedEventArgs e)
        {
            try
            {
                wej_string = System.IO.File.ReadAllText(ZamienPola.IsChecked == false? wej.Text:wyj.Text);
                klucz_string = System.IO.File.ReadAllText(klucz.Text);
                
                wej_bool = new bool[wej_string.Length * bity];
                wyj_bool = new bool[wej_bool.Length];

                for(var i = 0; i< wej_string.Length; i++)
                {
                    wej_bool = getBool(wej_string[i], i, wej_bool);       //Zamiana char na bool[]
                }

                xor();     //Xorowanie bool[] klucza i pliku wejściowego

                for (var i = 0; i < wej_string.Length; i++)
                {
                    wyj_string += getChar(wyj_bool, i);      //Zamiana bool[] na char
                }

                var plik = new StreamWriter("posredni.txt", false, Encoding.GetEncoding("UTF-8"));
                foreach (var b in wyj_bool)
                {
                    if(b== true)
                    plik.Write("1");
                    else
                    {
                        plik.Write("0");
                    }
                }
                plik.Close();

                File.WriteAllText(wyj.Text, wyj_string,Encoding.UTF32);
                
               // System.IO.File.WriteAllText(ZamienPola.IsChecked == false ? wyj.Text : wej.Text, wyj_string);  //nie wiem dlaczego tylko 58 znaków koduje
               
                MessageBox.Show("Koniec.\nZaszyfrowana wiadomość:\n" + wyj_string ,"Szyfrowanie zakończone",
                    MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }



            catch (Exception err)
            {
                MessageBox.Show("Błąd:\n" + err, "Błąd krytyczny", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            wyj_string = null;
        }

        private bool[] getBool(char znak, int k, bool[] tablica)
        {
            int nr = Convert.ToInt32(znak);
            for (var i = 0; i < bity; i++)
            {
                if (nr >= Math.Pow(2, (bity -1) - i))
                {
                    tablica[i + bity*k] = true;
                    nr = nr - (int)Math.Pow(2, (bity - 1) - i);
                }
                else
                {
                    tablica[i + bity * k] = false;
                }
            }

            return tablica;
        }

        private void xor()
        {
            var j = 0;

            foreach (var element in wej_bool)              
            {
                        if (klucz_string.Length < wej_string.Length)
                        {
                            MessageBox.Show("Za długi tekst lub \nZa krótki wygenerowany ciąg",
                            " To błąd krytyczny", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        }

                if ((wej_bool[j] == false && klucz_string[j] == '0') || (wej_bool[j] == true && klucz_string[j] == '1'))
                {
                    wyj_bool[j] = false;
                }
                else
                {
                    wyj_bool[j] = true;
                }
                j++;
            }  
        }
        private string getChar(bool[] tablica, int k){
            var znak = 0;
            for (var i = 0; i < bity; i++)
            {
                if (tablica[i + k*bity])
                {
                    znak += (int)Math.Pow(2, (bity - 1) - i);
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
    
