using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POD_Blum_Micali_Generator.Model
{
    class Zapisz
    {
        public string filename;

        public Zapisz(string zawartosc)
        {
            zapis_zawartosci(zawartosc);
        }

        void zapis_zawartosci(string zawartosc)
        {
            var dlg = new Microsoft.Win32.SaveFileDialog { DefaultExt = ".txt", Filter = "Text documents (.txt)|*.txt" };
            
            // Set filter for file extension and default file extension 


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                filename = dlg.FileName;
                var plik = new StreamWriter(filename, false, Encoding.GetEncoding("UTF-8"));
                plik.Write(zawartosc);
                plik.Close();
            }
            else
            {
                MessageBox.Show("Problem z zapisaniem pliku");
            }
        }


    }
}
