namespace TankstellenApp
{
    // Klasse zum verarbeiten der Tankerkönig Json-Daten
    public class JsonClassTankstellen
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Street { get; set; }
        public string Place { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public double Dist { get; set; }
        public double? Price { get; set; }
        public bool IsOpen { get; set; }
        public string HouseNumber { get; set; }
        public int PostCode { get; set; }
    }
    public class Root
    {
        public bool ok { get; set; }
        public string license { get; set; }
        public string data { get; set; }
        public string status { get; set; }
        public string? message { get; set; }

        public List<JsonClassTankstellen> stations { get; } = new List<JsonClassTankstellen>();

    }
}
