using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;


namespace POD_Blum_Micali_Generator.Model
{
    class Wczytaj
    {
    private string filename;

        public Wczytaj()
        {
            
        }

        public string odczyt_zawartosci()
        {
            var dlg = new Microsoft.Win32.OpenFileDialog { DefaultExt = ".txt", Filter = "Text documents (.txt)|*.txt" };



            // Set filter for file extension and default file extension 


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                filename = dlg.FileName;
                var plik = new StreamReader(filename, Encoding.GetEncoding("Unicode"));
                return plik.ReadToEnd();
            }
            else
            {
                MessageBox.Show("Problem z otwarciem pliku");
                return "Błąd";
            }
        }


        public string odczyt_zawartosci(string nazwa)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog { DefaultExt = ".txt", Filter = "Text documents (.txt)|*.txt" };



            // Set filter for file extension and default file extension 


            // Display OpenFileDialog by calling ShowDialog method 
            //Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            
                // Open document 
                filename = nazwa;
                var plik = new StreamReader(filename, Encoding.GetEncoding("UTF-8"));
                return plik.ReadToEnd();
           
               
            
        }

        

    }
}

