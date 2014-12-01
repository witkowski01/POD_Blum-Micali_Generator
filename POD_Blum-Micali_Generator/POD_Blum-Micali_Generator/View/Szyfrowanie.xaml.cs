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
using Microsoft.Win32;
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

       // private XOR zmiennaXor;

        private FileStream filename;
        private string filename1;
        private byte[] plik_byte;
        //  private  string klucz_strig;
        bool[] wynik;
        private char pli = new char();
        private Int32 plikint;



        private byte[] plik,klucz;
       
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
            //zmiennaXor.Xor();
            //zapis_binarny();
            zapis_do_pliku();
        }

        private void wczyt_kluczyk(object sender, RoutedEventArgs e)
        {
            klucz = odczyt_zawartosci_klucza();
        }

        private void wczyt_pliki(object sender, RoutedEventArgs e)
        {

           plik =  odczyt_zawartosci_pliku();
        }


        public byte[] odczyt_zawartosci_pliku()
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Open File...";
            OpenFileDialog.Filter = "Text File (*.*)|*.*";
            //  OpenFileDialog.InitialDirectory = @"C:\";
            if (OpenFileDialog.ShowDialog() == true)
            {
                FileStream fs = new FileStream(OpenFileDialog.FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                // plik = br.ReadString();
                plik_byte = br.ReadBytes((int)br.BaseStream.Length);
                fs.Close();
                br.Close();
            }
            else
            {
                MessageBox.Show("Problem z otwarciem pliku");
            }
            return plik_byte;
        }

        public byte[] odczyt_zawartosci_klucza()
        {


            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Open KEY File...";
            OpenFileDialog.Filter = "Text File (*.*)|*.*";
            //  OpenFileDialog.InitialDirectory = @"C:\";
            if (OpenFileDialog.ShowDialog() == true)
            {
                FileStream fs = new FileStream(OpenFileDialog.FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                // plik = br.ReadString();
                plik = br.ReadBytes((int)br.BaseStream.Length);
                fs.Close();
                br.Close();
            }
            else
            {
                MessageBox.Show("Problem z otwarciem pliku");
            }
            return plik;
            
        }

        public bool[] plik_na_bool()
        {
            bool[] tmp2 = new bool[plik_byte.Length * 8];
            int iterator = 0;
            foreach (var b in plik_byte)
            {
                bool[] tmp = new bool[8];
                byte tmpB = b;

                for (int i = 0; i < 8; i++)
                {
                    tmp[i] = b % 2 == 1 ? true : false;
                    tmpB /= 2;
                }
                foreach (bool b1 in tmp)
                {
                    tmp2[iterator] = b1;
                    iterator++;
                }

            }
            return tmp2;
        }

        public bool[] klucz_na_bool()
        {

            int iterator = 0;
            
            bool[] tmp2 = new bool[klucz.Length];

            foreach (var b in klucz)
            {
                tmp2[iterator] = b == '1' ? true : false;
                iterator++;
            }
            return tmp2;
        }

        public bool[] Xor()
        {
            bool[] kluczy = klucz_na_bool();
            bool[] pliky = plik_na_bool();

            wynik = new bool[pliky.Length];

            for (int i = 0; i < pliky.Length; i++)
            {
                wynik[i] = kluczy[i] ^ pliky[i];
            }

            return wynik;
        }

        public byte[] zapis_binarny()
        {
            bool[] wejscie = Xor();

            byte[] temp = new byte[(wejscie.Length)];

            for (int i = 0; i < wejscie.Length; i++)
            {
                temp[i] += wejscie[i] == true ? (byte)Math.Pow((byte)2, (byte)i%8) : (byte)0;
            }
            return temp;

        }

        private void zapis_do_pliku()
        {
            byte[] wyjsice = zapis_binarny();
            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.Title = "Save As...";
            SaveFileDialog.Filter = "Binary File (*.*)|*.*";
           // SaveFileDialog.InitialDirectory = @"C:\";

            FileStream fs = new FileStream("wyj.txt", FileMode.Create);
            // Create the writer for data.
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(wyjsice);

            fs.Close();
            bw.Close();

        }

    }
}
