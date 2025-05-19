namespace TankstellenApp
{
    public static class UrlClass
    {
        public static string UrlErzeugen(string Ort, string ApiKey)
        {
            // key = "660f9badcf82c796643356cao717caa";
            string urlGeoString = @"https://geocode.maps.co/search?q=" + Ort + "&api_key=" + ApiKey;
            return urlGeoString;
        }

        public static string UrlErzeugen(string lat, string lon, string ApiKey, string Strecke, string type)
        {
            // key = "d15b506d-7f13-2856-0cbb-f9b6251a5580";

            string urlTankeString = @"https://creativecommons.tankerkoenig.de/json/list.php?lat=" + lat + "&lng=" + lon + "&rad=" + Strecke + "&sort=price&type=" + type + "&apikey=" + ApiKey;
            return urlTankeString;
        }
    }
}
