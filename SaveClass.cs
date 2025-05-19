using CsvHelper;
using System.Globalization;
using System.IO;

namespace TankstellenApp
{
    public static class SaveClass
    {
        internal static void DateiSpeichern(List<TankstellenClass> neueListe)
        {
            List<TankstellenClass> liste = neueListe;
            Int32 unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

            string csvFilePath = @AppDomain.CurrentDomain.BaseDirectory.ToString() + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            //MessageBox.Show(csvFilePath);
            using (var writer = new StreamWriter(csvFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(neueListe);
            }
        }
    }
}
