using Newtonsoft.Json;

namespace TankstellenApp
{
    // Diese Klasse kapselt die Logik zum Erzeugen und Laden der Tankstellenliste.
    public class ListClass
    {
        /// <summary>
        /// Erstellt eine Liste von Tankstellen basierend auf Ort, Radius und Kraftstofftyp.
        /// Holt dazu Geokoordinaten und ruft die Tankerkönig-API auf.
        /// </summary>
        internal static List<JsonClassTankstellen> listeErzeugen(string Ort, string Strecke, string type)
        {
            // Geocatcher Url erzeugen
            string urlGeoString = UrlBuilderClass.UrlErzeugen(Ort);

            // lat und lon erzeugen
            HttpRequestClass.JsonString(urlGeoString, out string lat, out string lon);

            // Tankerkönig Url erzeugen
            string urlTankeString = UrlBuilderClass.UrlErzeugen(lat, lon, Strecke, type);

            if (urlTankeString == null)
            {
            // Vorgang abbrechen, da kein API-Key vorhanden
            return new List<JsonClassTankstellen>();
            }

            //Tankerkönig Json Holen, Deserialisieren und Liste erzeugen
            HttpRequestClass.JsonString(urlTankeString, out string Json);
            if(Json == null)
            {
                return null;
            }
            Root root = JsonConvert.DeserializeObject<Root>(Json);
            List<JsonClassTankstellen> stations = root.stations;
            return stations;
        }
    }
}
