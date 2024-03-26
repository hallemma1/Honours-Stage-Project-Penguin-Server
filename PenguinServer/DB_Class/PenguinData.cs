namespace PenguinServer.DB_Class
{
    public class PenguinDataObject
    {
        public PenguinData[] DataObject { get; set; }
    }
    public class PenguinData
    {
        public string SiteName { get; set; }
        public string SiteId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string CommonName { get; set; }
        public int Year { get; set; }
        public int PenguinCount { get; set; }
    }
}
