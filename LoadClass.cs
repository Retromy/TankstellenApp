using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;
using System.IO;
using Microsoft.Win32;

namespace TankstellenApp
{
    // lädt die CSV-Datei mit einem Dialog
    public static class LoadClass
    {
        public static List<JsonClassTankstellen> DateiLadenMitDialog()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV-Dateien (*.csv)|*.csv|Alle Dateien (*.*)|*.*";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (openFileDialog.ShowDialog() == true)
            {
                using (var reader = new StreamReader(openFileDialog.FileName))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<JsonClassTankstellen>();
                    return new List<JsonClassTankstellen>(records);
                }
            }
            return null;
        }
    }
}
