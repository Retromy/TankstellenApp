using Newtonsoft.Json;

namespace TankstellenApp
{
    public class ListClass
    {
        internal static List<TankstellenClass> listeErzeugen(string Ort, string Strecke, string type)
        {
            // Geocatcher Url erzeugen
            string urlGeoString = UrlClass.UrlErzeugen(Ort, "660f9badcf82c796643356cao717caa");

            // lat und lon erzeugen
            JsonClass.JsonString(urlGeoString, out string lat, out string lon);

            // Tankerkönig Url erzeugen
            string urlTankeString = UrlClass.UrlErzeugen(lat, lon, "d15b506d-7f13-2856-0cbb-f9b6251a5580", Strecke, type);

            //Tankerkönig Json Holen, Deserialisieren und Liste erzeugen
            JsonClass.JsonString(urlTankeString, out string Json);
            Root root = JsonConvert.DeserializeObject<Root>(Json);
            List<TankstellenClass> stations = root.stations;
            return stations;
        }
    }
}
