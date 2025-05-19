namespace TankstellenApp
{
    internal class TankstellenClass
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
    internal class Root
    {
        public string ok { get; set; }
        public string license { get; set; }
        public string data { get; set; }
        public string status { get; set; }
        public List<TankstellenClass> stations { get; } = new List<TankstellenClass>();

    }
}
