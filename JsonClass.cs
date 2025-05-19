using System.Net.Http;
using System.Text.Json;

namespace TankstellenApp
{
    public static class JsonClass
    {

        public static void JsonString(string urlGeoString, out string lat, out string lon)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponse = httpClient.GetAsync(urlGeoString).Result;
            string Json = httpResponse.Content.ReadAsStringAsync().Result;

            //MessageBox.Show(Json);

            var places = JsonSerializer.Deserialize<JsonClassGeo[]>(Json);

            lat = places[0].lat;
            lon = places[0].lon;
        }

        public static void JsonString(string urlTankeString, out string Json)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponse = httpClient.GetAsync(urlTankeString).Result;
            Json = httpResponse.Content.ReadAsStringAsync().Result;
        }
    }
}
