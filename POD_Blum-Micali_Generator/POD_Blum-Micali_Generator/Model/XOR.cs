using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Microsoft.Win32;


//To będzie klasa do xorowania pliku wejściowego za pomocą generowanego klucza
    

namespace POD_Blum_Micali_Generator.Model
{
    class XOR
    {
        private FileStream filename;
        private string plik, plik2;
        private char pli = new char();
        private Int32 plikint;
        public XOR()
        {
            
        }

        public string odczyt_zawartosci()
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Open File...";
            OpenFileDialog.Filter = "Binary File (*.bin)|*.bin";
          //  OpenFileDialog.InitialDirectory = @"C:\";
            if (OpenFileDialog.ShowDialog() == true)
            {
                FileStream fs = new FileStream(OpenFileDialog.FileName, FileMode.Open);
                BinaryReader br = new BinaryReader(fs);

                plik = br.ReadString();
                plik2 = br.ReadInt32().ToString();

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

        public string odczyt_zawartosci(string nazwa)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog { DefaultExt = ".txt", Filter = "Text documents (.txt)|*.txt" };

                filename = new FileStream(nazwa, FileMode.OpenOrCreate, FileAccess.ReadWrite);
          
                var plik = new BinaryReader(filename);
                return "coś";
           
               
            
        }

/*
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.Title = "Save As...";
            SaveFileDialog.Filter = "Binary File (*.bin)|*.bin";
            SaveFileDialog.InitialDirectory = @"C:\";
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(SaveFileDialog.FileName, FileMode.Create);
                // Create the writer for data.
                BinaryWriter bw = new BinaryWriter(fs);

                string Name = Convert.ToString(txtName.Text);
                int Age = Convert.ToInt32(txtAge.Text);
                bw.Write(Name);
                bw.Write(Age);

                fs.Close();
                bw.Close();
            }
        }
*/
        

    }
}
