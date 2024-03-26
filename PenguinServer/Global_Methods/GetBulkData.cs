using PenguinServer.DB_Class;

namespace PenguinServer.Global_Methods
{
    public class GetBulkData
    {
        public List<PenguinData> ReadDataFile()
        {
            string filePath = "./AllCounts.csv";
            List<PenguinData> bulkPenguinDataList = new List<PenguinData>();

            try
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines.Skip(1)) // Skip the header row
                {
                    var values = line.Split(',');

                    PenguinData penguinData = new PenguinData
                    {
                        SiteName = values[0],
                        SiteId = values[1],
                        Longitude = double.Parse(values[3]),
                        Latitude = double.Parse(values[4]),
                        CommonName = values[5],
                        Year = string.IsNullOrEmpty(values[8]) ? 0 : int.Parse(values[8]),
                        PenguinCount = string.IsNullOrEmpty(values[10]) ? 0 : int.Parse(values[10]),
                    };

                    bulkPenguinDataList.Add(penguinData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
            }

            return bulkPenguinDataList;
        }


    }
}
