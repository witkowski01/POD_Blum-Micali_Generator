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


        private void WczytajButton(object sender, RoutedEventArgs e)  // Wczytaj z pliku   
        {
            var wczyt = new Wczytaj();
            klucz.Text = wczyt.odczyt_zawartosci();
        }

        private void PodgladKlucza(object sender, RoutedEventArgs e)
        {
            Wczytaj wczyt=new Wczytaj();
            kluczString = wczyt.odczyt_zawartosci("klucz.txt");
            klucz.Text = wczyt.odczyt_zawartosci("klucz.txt");
        }

        private void Autor(object sender, RoutedEventArgs e)
        {
            var i = new Autor();
            i.Show();
        }


    }
}
