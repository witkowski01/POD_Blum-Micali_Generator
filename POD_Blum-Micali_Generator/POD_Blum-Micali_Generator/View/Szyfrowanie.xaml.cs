using System;
using System.Collections.Generic;
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
using POD_Blum_Micali_Generator.Model;

namespace POD_Blum_Micali_Generator.View
{
    /// <summary>
    /// Interaction logic for Szyfrowanie.xaml
    /// </summary>
    public partial class Szyfrowanie : Window
    {
        public Szyfrowanie()
        {
            InitializeComponent();
        }

        private XOR zmiennaXor;

        private void Minimalize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Szyfrowanie_xor(object sender, RoutedEventArgs e)
        {
            zmiennaXor.Xor();
            zmiennaXor.zapis_binarny();
        }

    }
}
