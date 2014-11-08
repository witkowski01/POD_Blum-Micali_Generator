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


        public void genLP()
        {
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
            
        }
  
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void generuj_Click(object sender, RoutedEventArgs e)
        {
          
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


    }
}
