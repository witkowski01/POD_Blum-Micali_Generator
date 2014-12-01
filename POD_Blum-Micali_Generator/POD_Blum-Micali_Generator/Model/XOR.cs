using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;


//To będzie klasa do xorowania pliku wejściowego za pomocą generowanego klucza
    

namespace POD_Blum_Micali_Generator.Model
{
    class XOR
    {
        private FileStream filename;
        private byte[] plik_byte;
        //  private  string klucz_strig;
        
        private char pli = new char();
        private Int32 plikint;

        public string odczyt_zawartosci_pliku()
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Open File...";
            OpenFileDialog.Filter = "Binary File (*.bin)|*.bin";
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
                return "Błąd";
            }
            return " ";
        }

        public string odczyt_zawartosci_klucza()
        {
            var dlg = new Microsoft.Win32.OpenFileDialog { DefaultExt = ".txt", Filter = "Text documents (.txt)|*.txt" };
            var plik = new StreamReader(filename, Encoding.GetEncoding("UTF-8"));
             
            return plik.ReadToEnd();
           
        }

        public bool[] plik_na_bool()
        {
            bool[] tmp2 = new bool[plik_byte.Length * 8];
            int iterator = 0;
            foreach (var b in plik_byte)
            {
                bool[] tmp = new bool[8];
                byte tmpB = b;

                for (int i = 0; i < 7; i++)
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
            string klucz=odczyt_zawartosci_klucza();
            bool[] tmp2 = new bool[klucz.Length];

            foreach (var b in klucz)
            {
              tmp2[iterator]= b =='1' ? true : false;
                iterator++;
            }
            return tmp2;
        }

        public bool[] Xor()
        {
            bool[] klucz = klucz_na_bool();
            bool[] plik = plik_na_bool();

            bool[] wynik = new bool[plik.Length];

            for (int i = 0; i < plik.Length; i++)
            {
                wynik[i] = klucz[i] ^ plik[i];
            }

            return wynik;
        }

        public byte[] zapis_binarny()
        {
            bool[] wejscie = Xor();

            byte[] temp=new byte[(wejscie.Length/8)];
            for (int i = 0; i < wejscie.Length; i++)
            {
                temp[i/8] += wejscie[i] == true ? (byte)Math.Pow((int)2,(int) i) : (byte)0;
            }
            return temp;

        }

        private void zapis_do_pliku()
        {
            byte[] wyjsice = zapis_binarny();
            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.Title = "Save As...";
            SaveFileDialog.Filter = "Binary File (*.bin)|*.bin";
            SaveFileDialog.InitialDirectory = @"C:\";

                FileStream fs = new FileStream(SaveFileDialog.FileName, FileMode.Create);
                // Create the writer for data.
                BinaryWriter bw = new BinaryWriter(fs);
            
                bw.Write(wyjsice);
                
                fs.Close();
                bw.Close();
            
        }

    }
}
