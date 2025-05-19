using System.Windows;

namespace TankstellenApp
{
    // Diese Klasse stellt Methoden zum Erzeugen von API-URLs für Geocoding und Tankerkönig bereit.
    public static class UrlBuilderClass
    {
        /// <summary>
        /// Erzeugt die URL für die Geocoding-API basierend auf dem angegebenen Ort.
        /// </summary>
        public static string UrlErzeugen(string Ort)
        {
            string urlGeoString = @"https://geocode.maps.co/search?q=" + Ort + "&api_key=" + VariablenClass.GetUserEnvironmentVariable("GeoApiKey");
            return urlGeoString;
        }

        /// <summary>
        /// Erzeugt die URL für die Tankerkönig-API basierend auf Koordinaten, Radius und Kraftstofftyp.
        /// Prüft, ob ein API-Key vorhanden ist.
        /// </summary>
        public static string UrlErzeugen(string lat, string lon, string Strecke, string type)
        {
            string apiKey = VariablenClass.GetUserEnvironmentVariable("TankerkoenigApiKey");
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                MessageBox.Show("Es wurde kein Tankerkönig API-Key gefunden! Bitte hinterlegen Sie einen gültigen Key in den Einstellungen.", "API-Key fehlt", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }

            string urlTankeString = @"https://creativecommons.tankerkoenig.de/json/list.php?lat=" + lat +
                                    "&lng=" + lon +
                                    "&rad=" + Strecke +
                                    "&sort=price&type=" + type +
                                    "&apikey=" + apiKey;
            return urlTankeString;
        }
    }
}
