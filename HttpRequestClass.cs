using System.Net.Http;
using System.Text.Json;
using System.Windows;

namespace TankstellenApp
{
    // Diese Klasse enthält Methoden für HTTP-Anfragen an die Geocoding- und Tankerkönig-API.
    public static class HttpRequestClass
    {
        /// <summary>
        /// Holt Geokoordinaten für einen Ort von der Geocoding-API.
        /// Prüft auf Fehler und gibt die Koordinaten per out-Parameter zurück.
        /// </summary>
        public static void JsonString(string urlGeoString, out string lat, out string lon)
        {
            lat = null;
            lon = null;
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage httpResponse = httpClient.GetAsync(urlGeoString).Result;

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("GeoApiKey ungültig! Bitte überprüfen Sie Ihren GeoApiKey.", "Authentifizierungsfehler", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Zugriff verweigert! Ihr GeoApiKey ist möglicherweise gesperrt oder ungültig.", "Authentifizierungsfehler", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (!httpResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Fehler beim Abrufen der Geodaten: {httpResponse.StatusCode}", "API-Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string Json = httpResponse.Content.ReadAsStringAsync().Result;
                var places = JsonSerializer.Deserialize<JsonClassGeo[]>(Json);

                if (places == null || places.Length == 0)
                {
                    MessageBox.Show("Keine Ergebnisse von der Geocoding-API erhalten.", "API-Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var germanyPlace = places.FirstOrDefault(p => p.display_name != null &&
                    (p.display_name.Contains("Germany") || p.display_name.Contains("Deutschland")));

                if (germanyPlace == null)
                {
                    MessageBox.Show("Keine Adresse in Deutschland gefunden!", "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                lat = germanyPlace.lat;
                lon = germanyPlace.lon;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Netzwerkfehler: " + ex.Message, "Verbindungsfehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (JsonException ex)
            {
                MessageBox.Show("Fehler beim Verarbeiten der API-Antwort: " + ex.Message, "Datenfehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unbekannter Fehler: " + ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Holt die Tankerkönig-API-Antwort als JSON-String.
        /// Prüft das ok-Flag und gibt ggf. eine Fehlermeldung aus.
        /// </summary>
        public static void JsonString(string urlTankeString, out string Json)
        {
            Json = null;
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage httpResponse = httpClient.GetAsync(urlTankeString).Result;
                Json = httpResponse.Content.ReadAsStringAsync().Result;

                // Deserialisieren
                var response = JsonSerializer.Deserialize<Root>(Json);

                if (response != null && response.ok == false)
                {
                    MessageBox.Show("Tankerkönig-Fehler: " + response.message, "API-Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Json = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unbekannter Fehler: " + ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
