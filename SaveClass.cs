using CsvHelper;
using System.Globalization;
using System.IO;

namespace TankstellenApp
{
    public static class SaveClass
    {
        // speichert eine Liste von JsonClassTankstellen in eine CSV-Datei
        public static void DateiSpeichern(List<JsonClassTankstellen> neueListe)
        {
            List<JsonClassTankstellen> liste = neueListe;
            Int32 unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

            string csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyyMMdd") + ".csv");
            //MessageBox.Show(csvFilePath);
            using (var writer = new StreamWriter(csvFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(neueListe);
            }
        }
    }

}
